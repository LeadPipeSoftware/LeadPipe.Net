// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
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

                //Console.WriteLine(moneyAsString);

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

                //Console.WriteLine($"Culture Name: {cultureInfo.Name}\t\tCurrency Symbol: {currencySymbol}\t\tToString: {moneyAsString}");

                // Assert

                Assert.That(moneyAsString.Equals(expected));
            }
        }
    }
}