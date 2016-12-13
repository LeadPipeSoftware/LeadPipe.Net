// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;
using System;

namespace LeadPipe.Net.Tests.RandomValueProviderTests
{
    /// <summary>
    /// The random IP V4 tests.
    /// </summary>
    [TestFixture]
    public class RandomIpV4Should
    {
        [Test]
        public void ReturnRandomIpV4()
        {
            var randomValue = RandomValueProvider.RandomIpV4();

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }
    }
}