// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainsUpperCaseCharactersShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.StringExtensionsTests
{
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// StringExtensions ContainsUpperCaseCharacters tests.
	/// </summary>
	[TestFixture]
	public class ContainsUpperCaseCharactersShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that true is returned when the string contains upper case characters.
		/// </summary>
		/// <param name="stringWithUpperCaseCharacters">The string with upper case characters.</param>
		[TestCase("A")]
		[TestCase("ABC")]
		[TestCase(" abcdE ")]
		[TestCase(" A ")]
		[TestCase("Just a normal, mixed-case string. Nothing fancy.")]
		[TestCase("\tABC")]
		[TestCase("ABC\t")]
		[TestCase("\tabcdEFGH\t")]
		[TestCase("\taB")]
		[TestCase("\t\tA bcD S \t")]
		[TestCase("\tJust a normal, mixed-case string with tabs. Nothing fancy.\t\t")]
		public void ReturnTrueGivenStringWithWhiteSpace(string stringWithUpperCaseCharacters)
		{
			Assert.IsTrue(
				stringWithUpperCaseCharacters.ContainsUpperCaseCharacters());
		}

		/// <summary>
		/// Test to make sure that false is returned when the string is empty.
		/// </summary>
		[Test]
		public void ReturnFalseGivenEmptyString()
		{
			Assert.IsFalse(string.Empty.ContainsUpperCaseCharacters());
		}

		/// <summary>
		/// Tests to make sure that true is returned when the string does not contain upper case characters.
		/// </summary>
		/// <param name="stringWithoutUpperCaseCharacters">The string without upper case characters.</param>
		[TestCase("a")]
		[TestCase("longerstring")]
		[TestCase("123")]
		[TestCase("abc123")]
		public void ReturnFalseGivenStringWithoutLowerCaseCharacters(string stringWithoutUpperCaseCharacters)
		{
			Assert.IsFalse(stringWithoutUpperCaseCharacters.ContainsUpperCaseCharacters());
		}

		#endregion
	}
}