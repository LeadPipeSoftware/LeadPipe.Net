// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetOccurrencesShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.StringExtensionsTests
{
	using System.Linq;

	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// StringExtensions GetOccurrences tests.
	/// </summary>
	[TestFixture]
	public class GetOccurrencesShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure all occurrences matching a pattern are returned.
		/// </summary>
		[Test]
		public void ReturnOccurrencesMatchingPattern()
		{
			const string Pattern = "[sdbt]ay";
			const string Input = "say day bay toy";

			var knownMatches = new[] { "say", "day", "bay" };

			Assert.IsTrue(Input.GetOccurrences(Pattern).SequenceEqual(knownMatches));
		}

		#endregion
	}
}