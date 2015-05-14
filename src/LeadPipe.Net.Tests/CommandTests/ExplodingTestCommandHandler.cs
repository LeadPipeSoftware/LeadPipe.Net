// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExplodingTestCommandHandler.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using LeadPipe.Net.Commands;

namespace LeadPipe.Net.Tests.CommandTests
{
	/// <summary>
	/// Handles execution of the test command by exploding.
	/// </summary>
	public class ExplodingTestCommandHandler : CommandHandler<ExplodingTestCommand>
	{
		/// <summary>
		/// Called when the command is handled.
		/// </summary>
		/// <param name="command">The message.</param>
		protected override void OnHandle(ExplodingTestCommand command)
		{
			throw new Exception(command.ExceptionMessage);
		}
	}
}