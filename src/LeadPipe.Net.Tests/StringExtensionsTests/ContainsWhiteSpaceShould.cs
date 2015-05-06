// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainsWhiteSpaceShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.StringExtensionsTests
{
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// StringExtensions ContainsWhiteSpace tests.
	/// </summary>
	[TestFixture]
	public class ContainsWhiteSpaceShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that true is returned when the string contains whitespace.
		/// </summary>
		/// <param name="stringWithWhitespace">The string with whitespace.</param>
		[TestCase(" SINGLELEADINGSPACE")]
		[TestCase("SINGLETRAILINGSPACE ")]
		[TestCase(" LEADINGANDTRAILINGSPACE ")]
		[TestCase(" ")]
		[TestCase("A STRING WITH WHITESPACE")]
		[TestCase("Just a normal, mixed-case string. Nothing fancy.")]
		[TestCase("  ")]
		[TestCase("\tSINGLELEADINGTAB")]
		[TestCase("SINGLETRAILINGTAB\t")]
		[TestCase("\tLEADINGANDTRAILINGTABS\t")]
		[TestCase("\t")]
		[TestCase("\t\tA STRING WITH WHITESPACE AND TABS \t")]
		[TestCase("\tJust a normal, mixed-case string with tabs. Nothing fancy.\t\t")]
		public void ReturnTrueGivenStringWithWhiteSpace(string stringWithWhitespace)
		{
			Assert.IsTrue(stringWithWhitespace.ContainsWhiteSpace());
		}

		/// <summary>
		/// Test to make sure that false is returned when the string is empty.
		/// </summary>
		[Test]
		public void ReturnFalseGivenEmptyString()
		{
			Assert.IsFalse(string.Empty.ContainsWhiteSpace());
		}

		/// <summary>
		/// Tests to make sure that false is returned when the string does not contain whitespace.
		/// </summary>
		/// <param name="stringWithoutWhitespace">The string without whitespace.</param>
		[TestCase("A")]
		[TestCase("LONGERSTRING")]
		public void ReturnFalseGivenStringWithoutWhiteSpace(string stringWithoutWhitespace)
		{
			Assert.IsFalse(stringWithoutWhitespace.ContainsWhiteSpace());
		}

		#endregion
	}
}