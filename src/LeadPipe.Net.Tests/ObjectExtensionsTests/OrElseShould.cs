// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.ObjectExtensionsTests
{
    /// <summary>
    /// ObjectExtensions OrElse tests.
    /// </summary>
    [TestFixture]
    public class OrElseShould
    {
        /// <summary>
        /// Tests to make sure that the object itself is returned if it is not null.
        /// </summary>
        [Test]
        public void ReturnObjectGivenObjectIsNotNull()
        {
            string notNullString = "I think the past is behind us. It'd be real confusing if not. But anyway.";

            Assert.IsTrue(notNullString.OrElse("ABC").Equals(notNullString));
        }

        /// <summary>
        /// Tests to make sure that the first not null object is returned if the object itself is null.
        /// </summary>
        [Test]
        public void ReturnsFirstNotNullObjectGivenObjectIsNull()
        {
            string nullString = null;

            Assert.IsTrue(nullString.OrElse("ABC").Equals("ABC"));
        }
    }
}