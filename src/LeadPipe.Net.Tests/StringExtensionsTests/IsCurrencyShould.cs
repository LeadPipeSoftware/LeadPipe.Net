// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions IsCurrency tests.
    /// </summary>
    [TestFixture]
    public class IsCurrencyShould
    {
        /// <summary>
        /// Test to make sure that false is returned when the string is empty.
        /// </summary>
        [Test]
        public void ReturnFalseGivenEmptyString()
        {
            Assert.IsFalse(string.Empty.IsCurrency());
        }

        /// <summary>
        /// Tests to make sure that false is returned when the string is not currency.
        /// </summary>
        /// <param name="nonCurrencyString">The string that is not currency.</param>
        [TestCase(" ")]
        [TestCase("\t")]
        [TestCase("#")]
        [TestCase("ABC")]
        [TestCase(",")]
        [TestCase(";")]
        [TestCase("@")]
        [TestCase("#*7A65s")]
        public void ReturnFalseGivenNonNumericString(string nonCurrencyString)
        {
            Assert.IsFalse(nonCurrencyString.IsCurrency());
        }

        /// <summary>
        /// Tests to make sure that true is returned when the string is currency.
        /// </summary>
        /// <param name="currencyString">The string that is currency.</param>
        [TestCase("$1,000,000.150")]
        [TestCase("$10000000.199")]
        [TestCase("$10000")]
        [TestCase("1,000,000.150")]
        [TestCase("100000.123")]
        [TestCase("10000")]
        public void ReturnTrueGivenNumericString(string currencyString)
        {
            Assert.IsTrue(currencyString.IsCurrency());
        }
    }
}