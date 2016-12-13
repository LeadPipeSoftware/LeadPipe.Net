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
    /// The random phone number tests.
    /// </summary>
    [TestFixture]
    public class RandomPhoneNumberShould
    {
        [Test]
        public void ReturnRandomPhoneNumber()
        {
            var randomValue = RandomValueProvider.RandomPhoneNumber();

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }
    }
}