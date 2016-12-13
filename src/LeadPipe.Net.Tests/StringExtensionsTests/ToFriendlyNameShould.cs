// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
    /// <summary>
    /// StringExtensions ToFriendlyName tests.
    /// </summary>
    [TestFixture]
    public class ToFriendlyNameShould
    {
        /// <summary>
        /// Tests to make sure a proper friendly name is returned.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <param name="friendlyName">The title case string.</param>
        [TestCase("ThisIsMyThing", "This Is My Thing")]
        [TestCase("APISpecification", "API Specification")]
        public void ReturnInputAsFriendlyName(string inputString, string friendlyName)
        {
            var convertedInput = inputString.ToFriendlyName();

            Assert.IsTrue(convertedInput.Equals(friendlyName));
        }
    }
}