// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainsTrailingWhiteSpaceShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.StringExtensionsTests
{
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// StringExtensions ContainsTrailingWhiteSpace tests.
	/// </summary>
	[TestFixture]
	public class ContainsTrailingWhiteSpaceShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that true is returned when the string contains trailing whitespace.
		/// </summary>
		/// <param name="stringWithTrailingWhitespace">The string with trailing whitespace.</param>
		[TestCase("SINGLETRAILINGSPACE ")]
		[TestCase(" LEADINGANDTRAILINGSPACE ")]
		[TestCase(" ")]
		[TestCase("A STRING WITH WHITESPACE ")]
		[TestCase("Just a normal, mixed-case string. Nothing fancy. ")]
		[TestCase("  ")]
		[TestCase("SINGLETRAILINGTAB\t")]
		[TestCase("\tLEADINGANDTRAILINGTABS\t")]
		[TestCase("\t")]
		[TestCase("\t\tA STRING WITH WHITESPACE AND TABS \t")]
		[TestCase("\t Just a normal, mixed-case string with tabs. Nothing fancy.\t\t")]
		public void ReturnTrueGivenStringWithTrailingWhiteSpace(string stringWithTrailingWhitespace)
		{
			Assert.IsTrue(stringWithTrailingWhitespace.ContainsTrailingWhiteSpace());
		}

		/// <summary>
		/// Test to make sure that false is returned when the string is empty.
		/// </summary>
		[Test]
		public void ReturnFalseGivenEmptyString()
		{
			Assert.IsFalse(string.Empty.ContainsTrailingWhiteSpace());
		}

		/// <summary>
		/// Tests to make sure that true is returned when the string does not contain trailing whitespace.
		/// </summary>
		/// <param name="stringWithoutTrailingWhitespace">The string without trailing whitespace.</param>
		[TestCase("A")]
		[TestCase("LONGERSTRING")]
		[TestCase(" LONGERSTRINGWITHLEADINGSPACE")]
		[TestCase("\tLONGERSTRINGWITHLEADINGTAB")]
		[TestCase("\t LONGERSTRINGWITHLEADINGTABANDSPACE")]
		public void ReturnFalseGivenStringWithoutLeadingWhiteSpace(string stringWithoutTrailingWhitespace)
		{
			Assert.IsFalse(stringWithoutTrailingWhitespace.ContainsTrailingWhiteSpace());
		}

		#endregion
	}
}