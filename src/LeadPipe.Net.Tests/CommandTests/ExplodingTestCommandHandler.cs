// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExplodingTestCommandHandler.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.CommandTests
{
	using System;

	using LeadPipe.Net.Core.Commands;
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

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