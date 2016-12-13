// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.IntExtensionsTests
{
    /// <summary>
    /// IntExtensions IsBetween tests.
    /// </summary>
    [TestFixture]
    public class IsBetweenShould
    {
        /// <summary>
        /// Tests to make sure that the correct return value is given.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lowerValue">The lower value.</param>
        /// <param name="upperValue">The upper value.</param>
        /// <param name="expectedResult">if set to <c>true</c> [expected result].</param>
        [TestCase(1, 0, 2, true)]
        [TestCase(1, 1, 2, false)]
        [TestCase(10, 9, 11, true)]
        [TestCase(1, 1, 1, false)]
        [TestCase(10, 1, 3, false)]
        [TestCase(50, 1, 100, true)]
        public void ReturnCorrectValue(int value, int lowerValue, int upperValue, bool expectedResult = false)
        {
            Assert.IsTrue(value.IsBetween(lowerValue, upperValue) == expectedResult);
        }
    }
}