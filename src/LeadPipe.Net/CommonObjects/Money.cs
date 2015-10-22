// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Money.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using System;
using System.Globalization;
using System.Linq;

namespace LeadPipe.Net.CommonObjects
{
    /// <summary>
    /// A culture-aware class that represents money.
    /// </summary>
    /// <remarks>Note that this type does NOT convert currency between cultures.</remarks>
    public struct Money
    {
        /// <summary>
        /// The amount.
        /// </summary>
        private readonly decimal amount;

        /// <summary>
        /// The culture information.
        /// </summary>
        private readonly CultureInfo cultureInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public Money(decimal amount)
            : this(amount, CultureInfo.CurrentCulture)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="culture">The culture.</param>
        public Money(decimal amount, CultureInfo culture)
        {
            this.amount = amount;

            this.cultureInfo = culture.IsNull() ? CultureInfo.CurrentCulture : culture;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        public Money(decimal amount, string currencyCode)
        {
            this.amount = amount;

            this.cultureInfo = CultureInfo.CurrentCulture;

            if (currencyCode.IsNotNullOrEmpty())
            {
                this.cultureInfo = GetCultureFromCurrencyCode(currencyCode);
            }
        }

        /// <summary>
        /// Gets the zero amount.
        /// </summary>
        /// <value>The zero.</value>
        public static Money Zero
        {
            get { return new Money(0M); }
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount
        {
            get { return this.amount; }
        }

        /// <summary>
        /// The culture information.
        /// </summary>
        public CultureInfo CultureInfo
        {
            get { return cultureInfo; }
        }

        /// <summary>
        /// Gets the currency symbol.
        /// </summary>
        /// <value>The currency symbol.</value>
        public string CurrencySymbol
        {
            get { return this.cultureInfo.NumberFormat.CurrencySymbol; }
        }

        /// <summary>
        /// Implements the !=.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Implements the ==.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Money a, Money b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance;
        /// otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Money)) return false;

            var otherMoney = (Money)obj;

            return Equals(otherMoney);
        }

        /// <summary>
        /// Determines if two Money objects are equal.
        /// </summary>
        /// <param name="otherMoney">The other money.</param>
        /// <returns><c>true</c> if equal, <c>false</c> otherwise.</returns>
        public bool Equals(Money otherMoney)
        {
            return Amount.Equals(otherMoney.Amount) && CultureInfo.Equals(otherMoney.CultureInfo); // The cultures must match!
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data
        /// structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return Amount.GetHashCode() + CultureInfo.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            /*
             * We want to respect the set culture, but without a currency symbol so we clone the
             * NFI and drop the symbol. A trick from Jon Skeet.
             */

            var numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;

            numberFormatInfo = (NumberFormatInfo)numberFormatInfo.Clone();

            numberFormatInfo.CurrencySymbol = "";

            return string.Format(numberFormatInfo, "{0:c}", this.amount);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance with the currency
        /// symbol included.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance with the currency symbol included.
        /// </returns>
        public string ToStringWithCurrencySymbol()
        {
            return cultureInfo == null
                ? amount.ToString("0.00")
                : string.Format(cultureInfo, "{0:C}", amount);
        }

        #region Arithmetic Operator Overloads

        /// <summary>
        /// Implements the -.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator -(Money a, Money b)
        {
            if (a.IsNull()) throw new ArgumentNullException(nameof(a));
            if (b.IsNull()) throw new ArgumentNullException(nameof(b));

            if (!a.CultureInfo.Equals(b.CultureInfo)) throw new ArgumentException("Invalid argument. The Money.CultureInfo must be the same.");

            return new Money(a.Amount - b.Amount);
        }

        /// <summary>
        /// Implements the -.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator -(Money a, decimal b)
        {
            if (a.IsNull()) throw new ArgumentNullException(nameof(a));

            return new Money(a.Amount - b);
        }

        /// <summary>
        /// Implements the -.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator -(decimal a, Money b)
        {
            if (b.IsNull()) throw new ArgumentNullException(nameof(b));

            return new Money(a - b.Amount);
        }

        /// <summary>
        /// Implements the *.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator *(Money a, Money b)
        {
            if (a.IsNull()) throw new ArgumentNullException(nameof(a));
            if (b.IsNull()) throw new ArgumentNullException(nameof(b));

            if (!a.CultureInfo.Equals(b.CultureInfo)) throw new ArgumentException("Invalid argument. The Money.CultureInfo must be the same.");

            return new Money(a.Amount * b.Amount);
        }

        /// <summary>
        /// Implements the *.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator *(Money a, decimal b)
        {
            if (a.IsNull()) throw new ArgumentNullException(nameof(a));

            return new Money(a.Amount * b);
        }

        /// <summary>
        /// Implements the *.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator *(decimal a, Money b)
        {
            if (b.IsNull()) throw new ArgumentNullException(nameof(b));

            return new Money(a + b.Amount);
        }

        /// <summary>
        /// Implements the /.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator /(Money a, Money b)
        {
            if (a.IsNull()) throw new ArgumentNullException(nameof(a));
            if (b.IsNull()) throw new ArgumentNullException(nameof(b));

            if (!a.CultureInfo.Equals(b.CultureInfo)) throw new ArgumentException("Invalid argument. The Money.CultureInfo must be the same.");

            return new Money(a.Amount / b.Amount);
        }

        /// <summary>
        /// Implements the /.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator /(Money a, decimal b)
        {
            if (a.IsNull()) throw new ArgumentNullException(nameof(a));

            return new Money(a.Amount / b);
        }

        /// <summary>
        /// Implements the /.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator /(decimal a, Money b)
        {
            if (b.IsNull()) throw new ArgumentNullException(nameof(b));

            return new Money(a / b.Amount);
        }

        /// <summary>
        /// Implements the +.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator +(Money a, Money b)
        {
            if (a.IsNull()) throw new ArgumentNullException(nameof(a));
            if (b.IsNull()) throw new ArgumentNullException(nameof(b));

            if (!a.CultureInfo.Equals(b.CultureInfo)) throw new ArgumentException("Invalid argument. The Money.CultureInfo must be the same.");

            return new Money(a.Amount + b.Amount);
        }

        /// <summary>
        /// Implements the +.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator +(Money a, decimal b)
        {
            if (a.IsNull()) throw new ArgumentNullException(nameof(a));

            return new Money(a.Amount + b);
        }

        /// <summary>
        /// Implements the +.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator +(decimal a, Money b)
        {
            if (b.IsNull()) throw new ArgumentNullException(nameof(b));

            return new Money(a + b.Amount);
        }

        #endregion Arithmetic Operator Overloads

        #region Private Methods

        /// <summary>
        /// Gets the culture based on a currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>The matching CultureInfo.</returns>
        private CultureInfo GetCultureFromCurrencyCode(string currencyCode)
        {
            var culture = (from c in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                           let r = new RegionInfo(c.LCID)
                           where r != null
                           && r.ISOCurrencySymbol.ToUpper() == currencyCode.ToUpper()
                           select c).FirstOrDefault();

            return culture;
        }

        #endregion Private Methods
    }
}