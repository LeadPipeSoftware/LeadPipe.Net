// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExplodingTestCommand.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.CommandTests
{
	using LeadPipe.Net.Core.Commands;
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// A command that throws an exception for unit testing.
	/// </summary>
	public class ExplodingTestCommand : ICommand<UnitType>
	{
		/// <summary>
		/// Gets or sets the exception message.
		/// </summary>
		/// <value>The exception message.</value>
		public string ExceptionMessage { get; set; }
	}
}