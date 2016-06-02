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
    /// The random full name tests.
    /// </summary>
    [TestFixture]
    public class RandomFullNameShould
    {
        [Test]
        public void ReturnRandomFemaleFullName()
        {
            var randomValue = RandomValueProvider.RandomFullName(Gender.Female);

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }

        [Test]
        public void ReturnRandomFullName()
        {
            var randomValue = RandomValueProvider.RandomFullName();

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }

        [Test]
        public void ReturnRandomFullNameWithPrefix()
        {
            var randomValue = RandomValueProvider.RandomFullName(includePrefix: true);

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }

        [Test]
        public void ReturnRandomFullNameWithSuffix()
        {
            var randomValue = RandomValueProvider.RandomFullName(includeSuffix: true);

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }

        [Test]
        public void ReturnRandomMaleFullName()
        {
            var randomValue = RandomValueProvider.RandomFullName(Gender.Male);

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }
    }
}