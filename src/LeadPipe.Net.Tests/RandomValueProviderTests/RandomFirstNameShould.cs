// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomFirstNameShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
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
        #region Public Methods

        [Test]
        public void ReturnRandomFirstName()
        {
            var randomValue = RandomValueProvider.RandomFirstName();

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }

        [Test]
        public void ReturnRandomFemaleFirstName()
        {
            var randomValue = RandomValueProvider.RandomFirstName(Gender.Female);

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

        #endregion
    }
}