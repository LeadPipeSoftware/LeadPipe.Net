// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.BoolExtensionsTests
{
    /// <summary>
    /// BoolExtensions IsTrue tests.
    /// </summary>
    [TestFixture]
    public class IsTrueShould
    {
        /// <summary>
        /// Tests to make sure true is returned if the Boolean value is true.
        /// </summary>
        [Test]
        public void ReturnFalseGivenBoolIsFalse()
        {
            var falseBool = false;

            Assert.IsFalse(falseBool.IsTrue());
        }

        /// <summary>
        /// Tests to make sure true is returned if the Boolean value is true.
        /// </summary>
        [Test]
        public void ReturnTrueGivenBoolIsTrue()
        {
            var trueBool = true;

            Assert.IsTrue(trueBool.IsTrue());
        }
    }
}