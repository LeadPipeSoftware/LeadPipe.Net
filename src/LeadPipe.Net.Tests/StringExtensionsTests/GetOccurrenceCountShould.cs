// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions GetOccurrenceCount tests.
    /// </summary>
    [TestFixture]
    public class GetOccurrenceCountShould
    {
        /// <summary>
        /// Tests to make sure that the correct count of occurrences is returned.
        /// </summary>
        [Test]
        public void ReturnCorrectOccurrenceCount()
        {
            const string Pattern = "[sdbt]ay";
            const string Input = "say day bay toy";

            var knownMatches = new[] { "say", "day", "bay" };

            Assert.IsTrue(Input.GetOccurrenceCount(Pattern).Equals(3));
        }
    }
}