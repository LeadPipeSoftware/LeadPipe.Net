// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExplodingTestCommand.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Commands;

namespace LeadPipe.Net.Tests.CommandTests
{
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