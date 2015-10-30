// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AmountShould.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.CommonObjects.CommonObjects;
using NUnit.Framework;

namespace LeadPipe.Net.CommonObjects.Tests.MoneyTests
{
    /// <summary>
    /// The Amount tests.
    /// </summary>
    [TestFixture]
    public class AmountShould
    {
        #region Public Methods

        [TestCase(0.00)]
        [TestCase(0.01)]
        [TestCase(0.001)]
        [TestCase(1.00)]
        [TestCase(1.01)]
        [TestCase(100.00)]
        [TestCase(100.01)]
        public void ReturnValue(decimal amount)
        {
            // Arrange & Act

            var money = new Money(amount);

            // Assert

            Assert.That(money.Amount.Equals(amount));
        }

        #endregion Public Methods
    }
}