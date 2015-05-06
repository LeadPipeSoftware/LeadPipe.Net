// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetLetterIndexShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.EnglishAlphabetProviderTests
{
	using LeadPipe.Net.Core.Extensions;

	using LeadPipeSoftware.Net.Core;

	using NUnit.Framework;

	/// <summary>
	/// GetLetterIndex tests.
	/// </summary>
	[TestFixture]
	public class GetLetterIndexShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure we get the correct index of a letter in the English alphabet.
		/// </summary>
		/// <param name="alphabetLetter">
		/// The alphabet letter.
		/// </param>
		/// <param name="expectedIndex">
		/// The expected index.
		/// </param>
		[TestCase('A', 1)]
		[TestCase('G', 7)]
		[TestCase('Z', 26)]
		public void ReturnCorrectIndexGivenIndexInRange(char alphabetLetter, int expectedIndex)
		{
			// Arrange
			IAlphabetProvider provider = new EnglishAlphabetProvider();

			// Act
			int result = provider.GetLetterIndex(alphabetLetter);

			// Assert
			Assert.AreEqual(expectedIndex, result);
		}

		#endregion
	}
}