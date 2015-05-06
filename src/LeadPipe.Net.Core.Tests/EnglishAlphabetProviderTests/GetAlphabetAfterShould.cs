// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAlphabetAfterShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.EnglishAlphabetProviderTests
{
	using System.Linq;

	using LeadPipe.Net.Core.Extensions;

	using LeadPipeSoftware.Net.Core;

	using NUnit.Framework;

	/// <summary>
	/// GetAlphabetAfter tests.
	/// </summary>
	[TestFixture]
	public class GetAlphabetAfterShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that we can get all alphabet characters after a specific character.
		/// </summary>
		/// <param name="specifiedCharacter">
		/// The specified character.
		/// </param>
		/// <param name="expectedCharacters">
		/// The expected characters.
		/// </param>
		[TestCase('R', "STUVWXYZ")]
		[TestCase('Z', "")]
		[TestCase('A', "BCDEFGHIJKLMNOPQRSTUVWXYZ")]
		public void ReturnAllCharactersAfterSpecifiedCharacterGivenValidCharacter(
			char specifiedCharacter, string expectedCharacters)
		{
			// Arrange
			IAlphabetProvider provider = new EnglishAlphabetProvider();

			// Act
			var result = new string(provider.GetAlphabetAfter(specifiedCharacter).ToArray());

			// Assert
			Assert.AreEqual(expectedCharacters, result);
		}

		/// <summary>
		/// Tests to make sure we can PROVIDE DESCRIPTION HERE.
		/// </summary>
		[Test]
		public void ReturnNullGivenLastLetterInAlphabet()
		{
			// Arrange

			// Act

			// Assert
			Assert.Inconclusive("This unit test is not complete.");
		}

		/// <summary>
		/// Tests to make sure we can PROVIDE DESCRIPTION HERE.
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