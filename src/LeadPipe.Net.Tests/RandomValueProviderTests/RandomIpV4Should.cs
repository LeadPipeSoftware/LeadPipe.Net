// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomIpV4Should.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;
using System;

namespace LeadPipe.Net.Tests.RandomValueProviderTests
{
    /// <summary>
    /// The random IP V4 tests.
    /// </summary>
    [TestFixture]
    public class RandomIpV4Should
    {
        #region Public Methods

        [Test]
        public void ReturnRandomIpV4()
        {
            var randomValue = RandomValueProvider.RandomIpV4();

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNullOrEmpty());
        }

        #endregion
    }
}