// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomSocialSecurityNumberShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
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
        #region Public Methods

        [Test]
        public void ReturnRandomPhoneNumber()
        {
            var randomValue = RandomValueProvider.RandomSocialSecurityNumber();

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }

        #endregion
    }
}