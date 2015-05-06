// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestQuery.cs" company="Lead Pipe Software">
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
	/// A query used for unit testing.
	/// </summary>
	public class TestQuery : IQuery<string>
	{
		/// <summary>
		/// The answer.
		/// </summary>
		public const string Answer = "Hooray!";

		/// <summary>
		/// Executes this instance.
		/// </summary>
		/// <returns>The query result.</returns>
		public string Execute()
		{
			return Answer;
		}

		/// <summary>
		/// Explodes this instance.
		/// </summary>
		/// <returns>The query result.</returns>
		public string Explode()
		{
			throw new Exception("Kaboom!");
		}
	}
}