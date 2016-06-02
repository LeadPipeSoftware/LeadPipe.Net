// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.ObjectExtensionsTests
{
    /// <summary>
    /// ObjectExtensions IsNull tests.
    /// </summary>
    [TestFixture]
    public class IsNullShould
    {
        /// <summary>
        /// Tests to make sure that false is returned if an object is not null.
        /// </summary>
        [Test]
        public void ReturnFalseGivenObjectIsNotNull()
        {
            string notNullString = "I think the past is behind us. It'd be real confusing if not. But anyway.";

            Assert.IsFalse(notNullString.IsNull());
        }

        /// <summary>
        /// Tests to make sure true is returned if an object is null.
        /// </summary>
        [Test]
        public void ReturnTrueGivenObjectIsNull()
        {
            string nullString = null;

            Assert.IsTrue(nullString.IsNull());
        }
    }
}