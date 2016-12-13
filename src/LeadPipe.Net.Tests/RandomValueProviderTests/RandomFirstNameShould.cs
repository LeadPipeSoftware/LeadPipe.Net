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
    /// The random first name tests.
    /// </summary>
    [TestFixture]
    public class RandomFirstNameShould
    {
        [Test]
        public void ReturnRandomFemaleFirstName()
        {
            var randomValue = RandomValueProvider.RandomFirstName(Gender.Female);

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }

        [Test]
        public void ReturnRandomFirstName()
        {
            var randomValue = RandomValueProvider.RandomFirstName();

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }

        [Test]
        public void ReturnRandomMaleFirstName()
        {
            var randomValue = RandomValueProvider.RandomFirstName(Gender.Male);

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }
    }
}