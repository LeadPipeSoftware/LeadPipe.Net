// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomAgeShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.RandomValueProviderTests
{
    /// <summary>
    /// The random age tests.
    /// </summary>
    [TestFixture]
    public class RandomAgeShould
    {
        #region Public Methods

        [Test]
        public void ReturnRandomAge()
        {
            Assert.That(RandomValueProvider.RandomAge().IsBetween(0, 120));
        }

        [Test]
        public void ReturnRandomTeenAge()
        {
            Assert.That(RandomValueProvider.RandomAge(AgeGroup.Teen).IsBetween(12, 18));
        }

        #endregion
    }
}