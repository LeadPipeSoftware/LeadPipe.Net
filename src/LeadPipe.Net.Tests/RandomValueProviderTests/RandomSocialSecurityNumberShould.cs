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
    /// The random social security number tests.
    /// </summary>
    [TestFixture]
    public class RandomSocialSecurityNumberShould
    {
        [Test]
        public void ReturnRandomPhoneNumber()
        {
            var randomValue = RandomValueProvider.RandomSocialSecurityNumber();

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }
    }
}