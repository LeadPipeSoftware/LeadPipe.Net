// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandMediator.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace LeadPipe.Net.Commands
{

    public delegate object SingleInstanceFactory(Type serviceType);

    /// <summary>
    /// The CommandExecutingEventHandler delegate.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="CommandExecutionStatusChangedEventArgs"/> instance containing the event data.</param>
    public delegate void CommandExecutingEventHandler(object sender, CommandExecutionStatusChangedEventArgs e);

	/// <summary>
	/// Mediates command execution requests and returns command responses.
	/// </summary>
	public class CommandMediator : ICommandMediator
	{

        private static ConcurrentDictionary<Tuple<Type, Type>, Func<CommandMediator, ICommand, object>> _createCommandDelegates = new ConcurrentDictionary<Tuple<Type, Type>, Func<CommandMediator, ICommand, object>>();

        private readonly SingleInstanceFactory singleInstanceFactory;

	    public CommandMediator(SingleInstanceFactory singleInstanceFactory)
	    {
	        this.singleInstanceFactory = singleInstanceFactory;
	    }


		/// <summary>
		/// Occurs when the mediator is executing a command.
		/// </summary>
		public event CommandExecutingEventHandler CommandExecuting;

		/// <summary>
		/// Requests execution of the specified command.
		/// </summary>
		/// <typeparam name="TResponseData">The type of the response data.</typeparam>
		/// <param name="command">The command.</param>
		/// <returns>The command response.</returns>
		public virtual CommandHandlerResponse<TResponseData> Request<TResponseData>(ICommand<TResponseData> command)
		{
            this.OnCommandExecuting(new CommandExecutionStatusChangedEventArgs(command, CommandExecutionStatus.Executing));
            var response = new CommandHandlerResponse<TResponseData>();

            if (command == null) throw new ArgumentNullException(nameof(command));
            var commandType = command.GetType();

            try
            {
                var func = _createCommandDelegates.GetOrAdd(Tuple.Create(commandType, typeof(TResponseData)), GenerateCommandDelegate);

                response.Data = (TResponseData) func(this, command);

                response.CommandExecutionResult = CommandExecutionResult.Succeeded;
            }
            catch (Exception ex)
            {
                this.OnCommandExecuting(new CommandExecutionStatusChangedEventArgs(command, CommandExecutionStatus.Failing));

                response.Exception = ex;

                response.CommandExecutionResult = CommandExecutionResult.Failed;
            }

            this.OnCommandExecuting(new CommandExecutionStatusChangedEventArgs(command, CommandExecutionStatus.Finished));
            return response;
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

        private TResponseData ExecuteCreateCommand<TCommand, TResponseData>(TCommand command) where TCommand : ICommand<TResponseData>
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            var handler = CreateInstance<ICommandHandler<TCommand, TResponseData>>();
            var id = handler.Handle(command);
            return id;
        }

        private THandler CreateInstance<THandler>()
        {
            return (THandler)singleInstanceFactory(typeof(THandler));
        }


        private class DummyCreateCommand : ICommand<object>
        {
        }


        /// <summary>
        /// Raises the CommandOrQueryExecuting event.
        /// </summary>
        /// <param name="e">The <see cref="CommandExecutionStatusChangedEventArgs"/> instance containing the event data.</param>
        protected void OnCommandExecuting(CommandExecutionStatusChangedEventArgs e)
		{
			if (this.CommandExecuting != null)
			{
				this.CommandExecuting(this, e);
			}
		}

	}
}