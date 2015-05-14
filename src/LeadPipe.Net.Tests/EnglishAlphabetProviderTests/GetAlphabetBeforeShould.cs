// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAlphabetBeforeShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.EnglishAlphabetProviderTests
{
	/// <summary>
	/// GetAlphabetBefore tests.
	/// </summary>
	[TestFixture]
	public class GetAlphabetBeforeShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that we can get all alphabet characters before a specific character.
		/// </summary>
		/// <param name="specifiedCharacter">
		/// The specified character.
		/// </param>
		/// <param name="expectedCharacters">
		/// The expected characters.
		/// </param>
		[TestCase('R', "ABCDEFGHIJKLMNOPQ")]
		[TestCase('A', "")]
		[TestCase('Z', "ABCDEFGHIJKLMNOPQRSTUVWXY")]
		public void ReturnAllCharactersBeforeSpecifiedCharacterGivenValidCharacter(
			char specifiedCharacter, string expectedCharacters)
		{
			// Arrange
			IAlphabetProvider provider = new EnglishAlphabetProvider();

			// Act
			var result = new string(provider.GetAlphabetBefore(specifiedCharacter).ToArray());

			// Assert
			Assert.AreEqual(expectedCharacters, result);
		}

		/// <summary>
		/// Tests to make sure that we receive null if we ask for characters before the first letter in the alphabet.
		/// </summary>
		[Test]
		public void ReturnNullGivenFirstLetterInAlphabet()
		{
			// Arrange

			// Act

			// Assert
			Assert.Inconclusive("This unit test is not complete.");
		}

		/// <summary>
		/// Tests to make sure an exception is thrown if we pass null as the specified character.
		/// </summary>
		[Test]
		public void ThrowExceptionGivenNullAlphabetCharacter()
		{
			// Arrange

			// Act

			// Assert
			Assert.Inconclusive("This unit test is not complete.");
		}

		#endregion
	}
}