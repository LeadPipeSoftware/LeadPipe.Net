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
    /// ObjectExtensions ToDictionary tests.
    /// </summary>
    [TestFixture]
    public class ToDictionaryShould
    {
        /// <summary>
        /// Tests to make sure that a dictionary representing the objects properties is returned.
        /// </summary>
        [Test]
        public void ReturnDictionary()
        {
            var testObject = DateTime.Now.ToDictionary();

            Assert.IsTrue(testObject.Keys.Contains("Day"));
        }
    }
}