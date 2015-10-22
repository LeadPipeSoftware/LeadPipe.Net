// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomUnitedStateShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;
using System;

namespace LeadPipe.Net.Tests.RandomValueProviderTests
{
    /// <summary>
    /// The random United State tests.
    /// </summary>
    [TestFixture]
    public class RandomUnitedStateShould
    {
        #region Public Methods

        [Test]
        public void ReturnRandomState()
        {
            var randomValue = RandomValueProvider.RandomUnitedState();

            Console.WriteLine(randomValue);

            Assert.That(randomValue.IsNotNull());
        }

        #endregion
    }
}