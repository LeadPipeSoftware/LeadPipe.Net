// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.DecimalExtensionsTests
{
    /// <summary>
    /// PercentageOf extension method tests.
    /// </summary>
    public class PercentageOfShould
    {
        /// <summary>
        /// Tests to ensure that the percentage of a decimal is returned.
        /// </summary>
        [Test]
        public void ReturnPercentageOfDecimal()
        {
            Assert.AreEqual(33.3M, 100.0M.PercentageOf(33.3M));
        }

        /// <summary>
        /// Tests to ensure that the percentage of an integer is returned.
        /// </summary>
        [Test]
        public void ReturnPercentageOfInt()
        {
            Assert.AreEqual(33.0M, 100.0M.PercentageOf(33));
        }

        /// <summary>
        /// Tests to ensure that the percentage of a long is returned.
        /// </summary>
        [Test]
        public void ReturnPercentageOfLong()
        {
            Assert.AreEqual(200.0M, 100.0M.PercentageOf((long)200));
        }
    }
}