// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions IsExtendedCharacterShould tests.
    /// </summary>
    [TestFixture]
    public class IsExtendedCharacterShould
    {
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
    }
}