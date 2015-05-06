// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandExecutionStatusChangedEventArgs.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Commands
{
	using System;

	/// <summary>
	/// Holds information relating to the change of execution status for a command.
	/// </summary>
	public sealed class CommandExecutionStatusChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CommandExecutionStatusChangedEventArgs" /> class.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="commandExecutionStatus">The command execution status.</param>
		public CommandExecutionStatusChangedEventArgs(ICommand command, CommandExecutionStatus commandExecutionStatus)
		{
			this.Command = command;
			this.CommandExecutionStatus = commandExecutionStatus;
		}

		/// <summary>
		/// Gets the command execution status.
		/// </summary>
		/// <value>The command execution status.</value>
		public CommandExecutionStatus CommandExecutionStatus { get; private set; }

		/// <summary>
		/// Gets the command.
		/// </summary>
		/// <value>The command.</value>
		public ICommand Command { get; private set; }
	}
}