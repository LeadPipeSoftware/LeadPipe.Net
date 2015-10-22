// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomFullNameShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
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
        #region Public Methods

        [Test]
        public void ReturnRandomFullName()
        {
            var randomValue = RandomValueProvider.RandomFullName();

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }

        [Test]
        public void ReturnRandomFemaleFullName()
        {
            var randomValue = RandomValueProvider.RandomFullName(Gender.Female);

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

        #endregion
    }
}