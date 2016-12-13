// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions ContainsWhiteSpace tests.
    /// </summary>
    [TestFixture]
    public class IsNumericShould
    {
        /// <summary>
        /// Test to make sure that false is returned when the string is empty.
        /// </summary>
        [Test]
        public void ReturnFalseGivenEmptyString()
        {
            Assert.IsFalse(string.Empty.IsNumeric());
        }

        /// <summary>
        /// Tests to make sure that false is returned when the string contains non-numeric characters.
        /// </summary>
        /// <param name="nonNumericString">The string that is not numeric.</param>
        [TestCase(" ")]
        [TestCase("\t")]
        [TestCase("#")]
        [TestCase("ABC")]
        [TestCase(",")]
        [TestCase(";")]
        [TestCase("@")]
        [TestCase("#*7A65s")]
        public void ReturnFalseGivenNonNumericString(string nonNumericString)
        {
            Assert.IsFalse(nonNumericString.IsNumeric());
        }

        /// <summary>
        /// Tests to make sure that true is returned when the string has only numeric characters.
        /// </summary>
        /// <param name="numericString">The string that is numeric.</param>
        [TestCase("99999")]
        [TestCase("0")]
        [TestCase("123")]
        public void ReturnTrueGivenNumericString(string numericString)
        {
            Assert.IsTrue(numericString.IsNumeric());
        }
    }
}