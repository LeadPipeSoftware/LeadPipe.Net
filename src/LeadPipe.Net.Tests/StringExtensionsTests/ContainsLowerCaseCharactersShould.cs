// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions ContainsLowerCaseCharacters tests.
    /// </summary>
    [TestFixture]
    public class ContainsLowerCaseCharactersShould
    {
        /// <summary>
        /// Test to make sure that false is returned when the string is empty.
        /// </summary>
        [Test]
        public void ReturnFalseGivenEmptyString()
        {
            Assert.IsFalse(string.Empty.ContainsLowerCaseCharacters());
        }

        /// <summary>
        /// Tests to make sure that true is returned when the string does not contain lower case characters.
        /// </summary>
        /// <param name="stringWithoutLowerCaseCharacters">The string without lower case characters.</param>
        [TestCase("A")]
        [TestCase("LONGERSTRING")]
        [TestCase("123")]
        [TestCase("ABC123")]
        public void ReturnFalseGivenStringWithoutLowerCaseCharacters(string stringWithoutLowerCaseCharacters)
        {
            Assert.IsFalse(stringWithoutLowerCaseCharacters.ContainsLowerCaseCharacters());
        }

        /// <summary>
        /// Tests to make sure that true is returned when the string contains lower case characters.
        /// </summary>
        /// <param name="stringWithLowerCaseCharacters">The string with lower case characters.</param>
        [TestCase("a")]
        [TestCase("abc")]
        [TestCase(" abcdE ")]
        [TestCase(" a ")]
        [TestCase("Just a normal, mixed-case string. Nothing fancy.")]
        [TestCase("\tabc")]
        [TestCase("abcd\t")]
        [TestCase("\tabcdEFGH\t")]
        [TestCase("\taB")]
        [TestCase("\t\tA bcD S \t")]
        [TestCase("\tJust a normal, mixed-case string with tabs. Nothing fancy.\t\t")]
        public void ReturnTrueGivenStringWithWhiteSpace(string stringWithLowerCaseCharacters)
        {
            Assert.IsTrue(
                stringWithLowerCaseCharacters.ContainsLowerCaseCharacters());
        }
    }
}