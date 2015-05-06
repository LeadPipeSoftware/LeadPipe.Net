// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandExecutionResult.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Commands
{
	/// <summary>
	/// An enumeration of command execution result values.
	/// </summary>
	public enum CommandExecutionResult
	{
		/// <summary>
		/// Indicates the execution was cancelled.
		/// </summary>
		Cancelled,

		/// <summary>
		/// Indicates the execution completed successfully.
		/// </summary>
		Succeeded,

		/// <summary>
		/// Indicates the execution failed.
		/// </summary>
		Failed
	}
}