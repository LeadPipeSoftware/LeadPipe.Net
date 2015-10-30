// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToStringWithCurrencySymbolShould.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.CommonObjects.CommonObjects;
using NUnit.Framework;
using System;
using System.Globalization;

namespace LeadPipe.Net.CommonObjects.Tests.MoneyTests
{
    /// <summary>
    /// The ToStringWithCurrencySymbol tests.
    /// </summary>
    [TestFixture]
    public class ToStringWithCurrencySymbolShould
    {
        #region Public Methods

        /// <summary>
        /// Tests every supported culture to ensure that the ToStringWithCurrencySymbol is formatted correctly when using the CultureInfo constructor.
        /// </summary>
        [Test]
        public void FormatAmountWithCorrectCurrencySymbolWhenUsingCultureInfoConstructor()
        {
            foreach (var cultureInfo in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                // Arrange

                var amount = 10.00M;

                var expected = string.Format(cultureInfo, "{0:C}", amount);

                var money = new Money(amount, cultureInfo);

                // Act

                var moneyAsString = money.ToStringWithCurrencySymbol();

                Console.WriteLine(moneyAsString);

                // Assert

                Assert.That(moneyAsString.Equals(expected));
            }
        }

        /// <summary>
        /// Tests every supported culture to ensure that the ToStringWithCurrencySymbol is formatted correctly when using the CurrencySymbol constructor.
        /// </summary>
        [Test]
        public void FormatAmountWithCorrectCurrencySymbolWhenUsingCurrencySymbolConstructor()
        {
            foreach (var cultureInfo in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                // Arrange

                if (cultureInfo.LCID.Equals(127) || cultureInfo.IsNeutralCulture)
                {
                    continue;
                }

                var amount = 10.00M;

                var regionInfo = new RegionInfo(cultureInfo.LCID);

                var currencySymbol = regionInfo.CurrencySymbol;

                var expected = string.Format(cultureInfo, "{0:C}", amount);

                var money = new Money(amount, cultureInfo.Name);

                // Act

                var moneyAsString = money.ToStringWithCurrencySymbol();

                Console.WriteLine($"Culture Name: {cultureInfo.Name}\t\tCurrency Symbol: {currencySymbol}\t\tToString: {moneyAsString}");

                // Assert

                Assert.That(moneyAsString.Equals(expected));
            }
        }

        #endregion Public Methods
    }
}