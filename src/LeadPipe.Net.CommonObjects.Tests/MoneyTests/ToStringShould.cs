// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.CommonObjects.CommonObjects;
using NUnit.Framework;

namespace LeadPipe.Net.CommonObjects.Tests.MoneyTests
{
    /// <summary>
    /// The ToStringShould tests.
    /// </summary>
    [TestFixture]
    public class ToStringShould
    {
        [Test]
        public void ReturnWithoutCurrencySymbol()
        {
            // Arrange

            var amount = 10.00M;

            var expected = amount.ToString();

            var money = new Money(amount);

            // Act

            var moneyAsString = money.ToString();

            // Assert

            Assert.That(moneyAsString.Equals(expected));
        }
    }
}