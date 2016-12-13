// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.BoolExtensionsTests
{
    /// <summary>
    /// BoolExtensions IsFalse tests.
    /// </summary>
    [TestFixture]
    public class IsFalseShould
    {
        /// <summary>
        /// Tests to make sure false is returned if the Boolean value is true.
        /// </summary>
        [Test]
        public void ReturnFalseGivenBoolIsFalse()
        {
            var trueBool = true;

            Assert.IsFalse(trueBool.IsFalse());
        }

        /// <summary>
        /// Tests to make sure true is returned if the Boolean value is false.
        /// </summary>
        [Test]
        public void ReturnTrueGivenBoolIsFalse()
        {
            var falseBool = false;

            Assert.IsTrue(falseBool.IsFalse());
        }
    }
}