// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
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
    }
}