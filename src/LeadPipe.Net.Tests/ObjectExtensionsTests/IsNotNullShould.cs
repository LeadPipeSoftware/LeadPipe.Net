// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.ObjectExtensionsTests
{
    /// <summary>
    /// ObjectExtensions IsNotNullShould tests.
    /// </summary>
    [TestFixture]
    public class IsNotNullShould
    {
        /// <summary>
        /// Tests to make sure that false is returned if an object is null.
        /// </summary>
        [Test]
        public void ReturnFalseGivenObjectIsNull()
        {
            string nullString = null;

            Assert.IsFalse(nullString.IsNotNull());
        }

        /// <summary>
        /// Tests to make sure true is returned if an object is not null.
        /// </summary>
        [Test]
        public void ReturnTrueGivenObjectIsNotNull()
        {
            string notNullString = "Four score and... how does that go again?";

            Assert.IsTrue(notNullString.IsNotNull());
        }
    }
}