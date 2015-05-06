// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebugWriteCommand.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.CommandTests
{
	using LeadPipe.Net.Core.Commands;
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// A command that writes to the debug console for unit testing.
	/// </summary>
	public class DebugWriteCommand : ICommand<UnitType>
	{
		/// <summary>
		/// Gets or sets the text to write.
		/// </summary>
		/// <value>The text to write.</value>
		public string TextToWrite { get; set; }
	}
}