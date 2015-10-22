// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomEmailAddressShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
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
        #region Public Methods

        [Test]
        public void ReturnRandomEmailAddress()
        {
            var randomEmailAddress = RandomValueProvider.RandomEmailAddress();

            Console.WriteLine(randomEmailAddress);

            Assert.That(randomEmailAddress.IsNotNullOrEmpty());
        }

        #endregion
    }
}