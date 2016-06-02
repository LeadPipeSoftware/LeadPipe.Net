// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Tests.EnglishAlphabetProviderTests
{
    /// <summary>
    /// GetLetterIndex tests.
    /// </summary>
    [TestFixture]
    public class GetLetterIndexShould
    {
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
    }
}