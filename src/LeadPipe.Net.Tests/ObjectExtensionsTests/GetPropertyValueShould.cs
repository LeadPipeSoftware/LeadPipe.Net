// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;
using System;

namespace LeadPipe.Net.Tests.ObjectExtensionsTests
{
    /// <summary>
    /// ObjectExtensions GetPropertyValue tests.
    /// </summary>
    [TestFixture]
    public class GetPropertyValueShould
    {
        /// <summary>
        /// Tests to make sure that the value of a property is returned.
        /// </summary>
        [Test]
        public void ReturnPropertyValue()
        {
            var testObject = DateTime.Now;

            Assert.IsTrue(testObject.GetPropertyValue("Day").Equals(DateTime.Now.Day));
        }
    }
}