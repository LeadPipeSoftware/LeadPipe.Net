// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions ContainsLeadingWhiteSpace tests.
    /// </summary>
    [TestFixture]
    public class ContainsLeadingWhiteSpaceShould
    {
        /// <summary>
        /// Test to make sure that false is returned when the string is empty.
        /// </summary>
        [Test]
        public void ReturnFalseGivenEmptyString()
        {
            Assert.IsFalse(string.Empty.ContainsLeadingWhiteSpace());
        }

        /// <summary>
        /// Tests to make sure that true is returned when the string does not contain leading whitespace.
        /// </summary>
        /// <param name="stringWithoutLeadingWhitespace">The string without leading whitespace.</param>
        [TestCase("A")]
        [TestCase("LONGERSTRING")]
        [TestCase("LONGERSTRINGWITHTRAILINGSPACE ")]
        [TestCase("LONGERSTRINGWITHTRAILINGTAB\t")]
        [TestCase("LONGERSTRINGWITHTRAILINGTABANDSPACE\t ")]
        public void ReturnFalseGivenStringWithoutLeadingWhiteSpace(string stringWithoutLeadingWhitespace)
        {
            Assert.IsFalse(stringWithoutLeadingWhitespace.ContainsLeadingWhiteSpace());
        }

        /// <summary>
        /// Tests to make sure that true is returned when the string contains leading whitespace.
        /// </summary>
        /// <param name="stringWithLeadingWhitespace">The string with leading whitespace.</param>
        [TestCase(" SINGLELEADINGSPACE")]
        [TestCase(" LEADINGANDTRAILINGSPACE ")]
        [TestCase(" ")]
        [TestCase(" A STRING WITH WHITESPACE")]
        [TestCase(" Just a normal, mixed-case string. Nothing fancy.")]
        [TestCase("  ")]
        [TestCase("\tSINGLELEADINGTAB")]
        [TestCase("\tLEADINGANDTRAILINGTABS\t")]
        [TestCase("\t")]
        [TestCase("\t\tA STRING WITH WHITESPACE AND TABS \t")]
        [TestCase("\t Just a normal, mixed-case string with tabs. Nothing fancy.\t\t")]
        public void ReturnTrueGivenStringWithLeadingWhiteSpace(string stringWithLeadingWhitespace)
        {
            Assert.IsTrue(stringWithLeadingWhitespace.ContainsLeadingWhiteSpace());
        }
    }
}