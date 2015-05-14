// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetOccurrenceCountShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
	/// <summary>
	/// StringExtensions GetOccurrenceCount tests.
	/// </summary>
	[TestFixture]
	public class GetOccurrenceCountShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that the correct count of occurrences is returned.
		/// </summary>
		[Test]
		public void ReturnCorrectOccurrenceCount()
		{
			const string Pattern = "[sdbt]ay";
			const string Input = "say day bay toy";

			var knownMatches = new[] { "say", "day", "bay" };

			Assert.IsTrue(Input.GetOccurrenceCount(Pattern).Equals(3));
		}

		#endregion
	}
}