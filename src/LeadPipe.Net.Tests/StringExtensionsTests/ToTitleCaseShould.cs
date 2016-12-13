// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions ToTitleCase tests.
    /// </summary>
    [TestFixture]
    public class ToTitleCaseShould
    {
        /// <summary>
        /// Tests to make sure a proper title case is returned.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <param name="titleCaseString">The title case string.</param>
        [TestCase("this is a title", "This Is A Title")]
        [TestCase("ThisIsTechnicallyTitleCased", "Thisistechnicallytitlecased")]
        [TestCase("CoMe and lIsT3n 70 my 5Tory 4B0u7 A MAN nAmEd Jed", "Come And List3n 70 My 5Tory 4B0u7 A MAN Named Jed")]
        public void ReturnInputAsTitleCase(string inputString, string titleCaseString)
        {
            var convertedInput = inputString.ToTitleCase();

            Assert.IsTrue(convertedInput.Equals(titleCaseString));
        }
    }
}