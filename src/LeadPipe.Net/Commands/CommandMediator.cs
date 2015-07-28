// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandMediator.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Reflection;
using Microsoft.Practices.ServiceLocation;

namespace LeadPipe.Net.Commands
{
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
		/// <summary>
		/// The handler method name.
		/// </summary>
		public const string HandlerMethodName = "Handle";

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

			try
			{
				var handler = this.GetHandler(command);

				response.Data = ProcessCommandWithHandler(command, handler);

				response.CommandExecutionResult = CommandExecutionResult.Succeeded;
			}
			catch (Exception ex)
			{
				this.OnCommandExecuting(new CommandExecutionStatusChangedEventArgs(command, CommandExecutionStatus.Failing));

				// TODO: The exception thrown should be a reflection exception, need to look at the inner exception to get the actual exception from the handler.
				response.Exception = ex;

				if (ex.InnerException != null)
				{
					response.Exception = ex.InnerException;
				}

				response.CommandExecutionResult = CommandExecutionResult.Failed;
			}

			this.OnCommandExecuting(new CommandExecutionStatusChangedEventArgs(command, CommandExecutionStatus.Finished));

			return response;
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

		/// <summary>
		/// Gets the handler method.
		/// </summary>
		/// <param name="handler">The handler.</param>
		/// <param name="query">The query.</param>
		/// <param name="name">The name.</param>
		/// <returns>The handler method info.</returns>
		private static MethodInfo GetHandlerMethod(object handler, object query, string name)
		{
			return handler.GetType().GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, CallingConventions.HasThis, new[] { query.GetType() }, null);
		}

		/// <summary>
		/// Processes the command with handler.
		/// </summary>
		/// <typeparam name="TResponseData">The type of the T response data.</typeparam>
		/// <param name="command">The command.</param>
		/// <param name="handler">The handler.</param>
		/// <returns>The response data.</returns>
		private static TResponseData ProcessCommandWithHandler<TResponseData>(ICommand<TResponseData> command, object handler)
		{
			return (TResponseData)GetHandlerMethod(handler, command, HandlerMethodName).Invoke(handler, new object[] { command });
		}

		/// <summary>
		/// Gets the command handler.
		/// </summary>
		/// <typeparam name="TResponseData">The type of the T response data.</typeparam>
		/// <param name="command">The command.</param>
		/// <returns>The command handler.</returns>
		private object GetHandler<TResponseData>(ICommand<TResponseData> command)
		{
			var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResponseData));

			/*
			 * TODO: Using a service locator is hardly ideal. Implement a better solution.
			 */
			
			var handler = ServiceLocator.Current.GetInstance(handlerType);

			return handler;
		}
	}
}