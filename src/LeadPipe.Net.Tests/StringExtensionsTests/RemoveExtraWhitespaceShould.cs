// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions RemoveExtraWhitespace tests.
    /// </summary>
    [TestFixture]
    public class RemoveExtraWhitespaceShould
    {
        /// <summary>
        /// Tests to make sure a string without extra whitespace is returned.
        /// </summary>
        /// <param name="stringWithExtraWhitespace">The string with whitespace.</param>
        /// <param name="stringWithoutExtraWhitespace">The string without whitespace.</param>
        [TestCase("A B", "A B")]
        [TestCase(" A ", "A")]
        [TestCase("    A    ", "A")]
        [TestCase("  1 2     3  4     5 6 7    8 9 0  ", "1 2 3 4 5 6 7 8 9 0")]
        public void ReturnStringWithExtraWhitespaceRemoved(string stringWithExtraWhitespace, string stringWithoutExtraWhitespace)
        {
            Assert.That(stringWithExtraWhitespace.RemoveExtraWhitespace(), Is.EqualTo(stringWithoutExtraWhitespace));
        }
    }
}