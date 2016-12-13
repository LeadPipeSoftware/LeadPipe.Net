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
    /// The random email address tests.
    /// </summary>
    [TestFixture]
    public class RandomEmailAddressShould
    {
        [Test]
        public void ReturnRandomEmailAddress()
        {
            var randomEmailAddress = RandomValueProvider.RandomEmailAddress();

            Console.WriteLine(randomEmailAddress);

            Assert.That(randomEmailAddress.IsNotNullOrEmpty());
        }
    }
}