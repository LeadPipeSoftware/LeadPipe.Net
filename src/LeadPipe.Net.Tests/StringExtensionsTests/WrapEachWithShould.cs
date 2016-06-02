// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions WrapEachWithShould Tests.
    /// </summary>
    [TestFixture]
    public class WrapEachWithShould
    {
        /// <summary>
        /// Test to ensure that a string is returned with the provided separator character inserted.
        /// </summary>
        /// <param name="original">The original string.</param>
        /// <param name="separated">The separated string.</param>
        [TestCase("ABC", @"A\B\C")]
        [TestCase("2-12345-02", @"2\-\1\2\3\4\5\-\0\2")]
        public void ReturnStringWithSeparators(string original, string separated)
        {
            // Arrange

            // Act
            var result = original.WrapEachWith(string.Empty, string.Empty, @"\");

            // Assert
            Assert.That(result, Is.EqualTo(separated));
        }
    }
}