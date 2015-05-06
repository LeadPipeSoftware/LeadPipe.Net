// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsExtendedCharacterShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.StringExtensionsTests
{
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// StringExtensions IsExtendedCharacterShould tests.
	/// </summary>
	[TestFixture]
	public class IsExtendedCharacterShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that true is returned when the string has only extended characters.
		/// </summary>
		/// <param name="stringWithExtendedCharacter">The string with extended Character.</param>
		[TestCase("±")]
		[TestCase("°")]

		public void ReturnTrueGivenStringWithExtendedCharacter(string stringWithExtendedCharacter)
		{
			Assert.IsTrue(stringWithExtendedCharacter.IsExtendedCharacter());
		}

		/// <summary>
		/// Test to make sure that false is returned when the string is empty.
		/// </summary>
		[Test]
		public void ReturnFalseGivenEmptyString()
		{
			Assert.IsFalse(string.Empty.IsExtendedCharacter());
		}

		/// <summary>
		/// Tests to make sure that false is returned when the string contains printable characters.
		/// </summary>
		/// <param name="stringWithPrintableCharacter">The string that has printable character.</param>
		[TestCase("123±")]
		[TestCase("ABC°")]
		public void ReturnFalseGivenStringWithExtendedCharcaters(string stringWithPrintableCharacter)
		{
			Assert.IsFalse(stringWithPrintableCharacter.IsExtendedCharacter());
		}

		#endregion
	}
}