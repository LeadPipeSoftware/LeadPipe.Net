// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;
using System.Linq;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions GetOccurrences tests.
    /// </summary>
    [TestFixture]
    public class GetOccurrencesShould
    {
        /// <summary>
        /// Tests to make sure all occurrences matching a pattern are returned.
        /// </summary>
        [Test]
        public void ReturnOccurrencesMatchingPattern()
        {
            const string Pattern = "[sdbt]ay";
            const string Input = "say day bay toy";

            var knownMatches = new[] { "say", "day", "bay" };

            Assert.IsTrue(Input.GetOccurrences(Pattern).SequenceEqual(knownMatches));
        }
    }
}