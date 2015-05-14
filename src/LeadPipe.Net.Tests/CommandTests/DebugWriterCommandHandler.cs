// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebugWriterCommandHandler.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using LeadPipe.Net.Commands;

namespace LeadPipe.Net.Tests.CommandTests
{
	/// <summary>
	/// Handles execution of the debug write unit test command.
	/// </summary>
	public class DebugWriterCommandHandler : CommandHandler<DebugWriteCommand>
	{
		/// <summary>
		/// Called when the command is handled.
		/// </summary>
		/// <param name="command">The command.</param>
		protected override void OnHandle(DebugWriteCommand command)
		{
			Debug.Write(command.TextToWrite);
		}
	}
}