// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomPhoneNumberShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
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
        #region Public Methods

        [Test]
        public void ReturnRandomPhoneNumber()
        {
            var randomValue = RandomValueProvider.RandomPhoneNumber();

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }

        #endregion
    }
}