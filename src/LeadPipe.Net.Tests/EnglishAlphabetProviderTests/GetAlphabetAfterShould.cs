// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System.Linq;

namespace LeadPipe.Net.Tests.EnglishAlphabetProviderTests
{
    /// <summary>
    /// GetAlphabetAfter tests.
    /// </summary>
    [TestFixture]
    public class GetAlphabetAfterShould
    {
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
    }
}