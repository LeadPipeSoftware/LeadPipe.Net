// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace LeadPipe.Net.Commands
{
    /// <summary>
    /// The CommandExecutingEventHandler delegate.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="CommandExecutionStatusChangedEventArgs"/> instance containing the event data.</param>
    public delegate void CommandExecutingEventHandler(object sender, CommandExecutionStatusChangedEventArgs e);

    public delegate object SingleInstanceFactory(Type serviceType);

    /// <summary>
    /// Mediates command execution requests and returns command responses.
    /// </summary>
    public class CommandMediator : ICommandMediator
    {
        private static ConcurrentDictionary<Tuple<Type, Type>, Func<CommandMediator, ICommand, object>> createCommandDelegates = new ConcurrentDictionary<Tuple<Type, Type>, Func<CommandMediator, ICommand, object>>();

        private readonly SingleInstanceFactory singleInstanceFactory;

        public CommandMediator(SingleInstanceFactory singleInstanceFactory, bool throwExceptionOnFailure = true)
        {
            this.singleInstanceFactory = singleInstanceFactory;
            this.ThrowExceptionOnFailure = throwExceptionOnFailure;
        }

        /// <summary>
        /// Occurs when the mediator is executing a command.
        /// </summary>
        public event CommandExecutingEventHandler CommandExecuting;

        /// <summary>
        /// Gets or sets a value indicating whether the command mediator should throw exceptions that occur during execution (default is true).
        /// </summary>
        public bool ThrowExceptionOnFailure { get; set; }

        /// <summary>
        /// Requests execution of the specified command.
        /// </summary>
        /// <typeparam name="TResponseData">The type of the response data.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns>The command response.</returns>
        [Obsolete("Please use the Submit method instead.")]
        public virtual CommandHandlerResponse<TResponseData> Request<TResponseData>(ICommand<TResponseData> command)
        {
            return Submit(command);
        }

        /// <summary>
        /// Submits the specified command for execution.
        /// </summary>
        /// <typeparam name="TResponseData">The type of the response data.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns>The command response.</returns>
        public CommandHandlerResponse<TResponseData> Submit<TResponseData>(ICommand<TResponseData> command)
        {
            var response = new CommandHandlerResponse<TResponseData>();

            Guard.Will.ProtectAgainstNullArgument(() => command);

            this.OnCommandExecuting(new CommandExecutionStatusChangedEventArgs(command, CommandExecutionStatus.Executing));

            var commandType = command.GetType();

            try
            {
                if (command is IValidatableObject)
                {
                    var validationResults = Validate((IValidatableObject)command);

                    if (validationResults.Any())
                    {
                        response.ValidationResults = validationResults;

                        response.CommandExecutionResult = CommandExecutionResult.Failed;

                        this.OnCommandExecuting(new CommandExecutionStatusChangedEventArgs(command, CommandExecutionStatus.Failing));
                    }
                    else
                    {
                        ExecuteCommand(command, commandType, response);
                    }
                }
                else
                {
                    ExecuteCommand(command, commandType, response);
                }
            }
            catch (KeyNotFoundException)
            {
                // This indicates we couldn't find a handler so we gotta bail...
                this.OnCommandExecuting(new CommandExecutionStatusChangedEventArgs(command, CommandExecutionStatus.Failing));

                response.Exception = new CommandHandlerNotFoundException();

                response.CommandExecutionResult = CommandExecutionResult.Failed;
            }
            catch (Exception ex)
            {
                this.OnCommandExecuting(new CommandExecutionStatusChangedEventArgs(command, CommandExecutionStatus.Failing));

                response.Exception = ex;

                response.CommandExecutionResult = CommandExecutionResult.Failed;
            }

            if (response.HasException() && ThrowExceptionOnFailure) throw response.Exception;

            this.OnCommandExecuting(new CommandExecutionStatusChangedEventArgs(command, CommandExecutionStatus.Finished));

            return response;
        }

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command to validate.</param>
        /// <returns>An enumeration of validation results.</returns>
        public IEnumerable<ValidationResult> Validate(IValidatableObject command)
        {
            if (command.IsNull()) return null;

            var validationResult = new List<ValidationResult>();

            Validator.TryValidateObject(command, new ValidationContext(command, null, null), validationResult, true);

            return validationResult;
        }

        /// <summary>
        /// Raises the CommandOrQueryExecuting event.
        /// </summary>
        /// <param name="e">The <see cref="CommandExecutionStatusChangedEventArgs"/> instance containing the event data.</param>
        protected void OnCommandExecuting(CommandExecutionStatusChangedEventArgs e)
        {
            this.CommandExecuting?.Invoke(this, e);
        }

        private THandler CreateHandlerInstance<THandler>()
        {
            return (THandler)singleInstanceFactory(typeof(THandler));
        }

        private void ExecuteCommand<TResponseData>(ICommand<TResponseData> command, Type commandType, CommandHandlerResponse<TResponseData> response)
        {
            var func = createCommandDelegates.GetOrAdd(Tuple.Create(commandType, typeof(TResponseData)), GenerateCommandDelegate);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            response.Data = (TResponseData)func(this, command);

            watch.Stop();

            response.ExecutionTimeInMilliseconds = watch.ElapsedMilliseconds;

            response.CommandExecutionResult = CommandExecutionResult.Succeeded;
        }

        private TResponseData ExecuteCreateCommand<TCommand, TResponseData>(TCommand command) where TCommand : ICommand<TResponseData>
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var handler = CreateHandlerInstance<ICommandHandler<TCommand, TResponseData>>();

            var id = handler.Handle(command);

            return id;
        }

        private Func<CommandMediator, ICommand, object> GenerateCommandDelegate(Tuple<Type, Type> io)
        {
            var commandType = io.Item1;

            var returnType = io.Item2;

            var mediatorParam = Expression.Parameter(typeof(CommandMediator), "mediator");

            var commandParam = Expression.Parameter(typeof(ICommand), "command");

            var castOperation = Expression.Convert(commandParam, commandType);

            var func = new Func<DummyCreateCommand, object>(ExecuteCreateCommand<DummyCreateCommand, object>);

            var mi = func.Method
                .GetGenericMethodDefinition()
                .MakeGenericMethod(commandType, returnType);

            var call = Expression.Call(mediatorParam, mi, castOperation);

            var castResult = Expression.Convert(call, typeof(object));

            var lambda = Expression.Lambda<Func<CommandMediator, ICommand, object>>(castResult, mediatorParam, commandParam);

            return lambda.Compile();
        }

        private class DummyCreateCommand : ICommand<object>
        {
        }
    }
}