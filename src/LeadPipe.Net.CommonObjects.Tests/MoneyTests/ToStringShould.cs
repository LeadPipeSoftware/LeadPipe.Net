// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToStringShould.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
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
        #region Public Methods

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

        #endregion Public Methods
    }
}