// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveExtraWhitespaceShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.StringExtensionsTests
{
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// StringExtensions RemoveExtraWhitespace tests.
	/// </summary>
	[TestFixture]
	public class RemoveExtraWhitespaceShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure a string without extra whitespace is returned.
		/// </summary>
		/// <param name="stringWithExtraWhitespace">The string with whitespace.</param>
		/// <param name="stringWithoutExtraWhitespace">The string without whitespace.</param>
		[TestCase("A B", "A B")]
		[TestCase(" A ", "A")]
		[TestCase("    A    ", "A")]
		[TestCase("  1 2     3  4     5 6 7    8 9 0  ", "1 2 3 4 5 6 7 8 9 0")]
		public void ReturnStringWithExtraWhitespaceRemoved(string stringWithExtraWhitespace, string stringWithoutExtraWhitespace)
		{
			Assert.That(stringWithExtraWhitespace.RemoveExtraWhitespace(), Is.EqualTo(stringWithoutExtraWhitespace));
		}

		#endregion
	}
}