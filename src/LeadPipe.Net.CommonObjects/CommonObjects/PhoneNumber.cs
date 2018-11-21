// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace LeadPipe.Net.CommonObjects.CommonObjects
{
    /// <summary>
    /// A struct representing a North American phone number that conforms to the North American
    /// Numbering Plan (NANP).
    /// </summary>
    public struct PhoneNumber
    {
        /// <summary>
        /// The area code.
        /// </summary>
        private readonly string areaCode;

        /// <summary>
        /// The exchange code.
        /// </summary>
        private readonly string exchangeCode;

        /// <summary>
        /// The subscriber number.
        /// </summary>
        private readonly string subscriberNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumber"/> struct.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The NANP does not allow phone numbers with more than ten (10) digits.
        /// </exception>
        public PhoneNumber(string phoneNumber)
        {
            var numbersOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());

            if (numbersOnly.Length > 10) throw new ArgumentOutOfRangeException(nameof(phoneNumber), "The NANP does not allow phone numbers with more than ten (10) digits.");

            this.areaCode = numbersOnly.Substring(0, 3);
            this.exchangeCode = numbersOnly.Substring(3, 3);
            this.subscriberNumber = numbersOnly.Substring(6, 4);

            ValidateAreaCode(this.areaCode);
            ValidateExchangeCode(this.exchangeCode);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumber"/> struct.
        /// </summary>
        /// <param name="areaCode">The area code.</param>
        /// <param name="exchangeCode">The exchange code.</param>
        /// <param name="subscriberNumber">The subscriber number.</param>
        public PhoneNumber(string areaCode, string exchangeCode, string subscriberNumber)
        {
            this.areaCode = areaCode;
            this.exchangeCode = exchangeCode;
            this.subscriberNumber = subscriberNumber;

            ValidateAreaCode(this.areaCode);
            ValidateExchangeCode(this.exchangeCode);
        }

        /// <summary>
        /// The area code.
        /// </summary>
        /// <remarks>
        /// This is the first part of the phone number. It allows 2-9 for the first digit and 0-9
        /// for the second and third digits.
        /// </remarks>
        public string AreaCode
        {
            get { return areaCode; }
        }

        /// <summary>
        /// The exchange code.
        /// </summary>
        /// <remarks>
        /// This is the second part of the phone number. It allows for 2-9 for the first digit and
        /// 0-9 for the second and third digits.
        /// </remarks>
        public string ExchangeCode
        {
            get { return exchangeCode; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is easily recognizable code (ERC).
        /// </summary>
        /// <remarks>
        /// When the second and third digits of an area code are the same, it is referred to as an
        /// easily recognizable code (ERC). These typically designate special services such as 888
        /// for toll free service.
        /// </remarks>
        /// <value><c>true</c> if this instance is easily recognizable code; otherwise, <c>false</c>.</value>
        public bool IsEasilyRecognizableAreaCode
        {
            get { return this.areaCode.ElementAt(2).Equals(this.areaCode.ElementAt(3)); }
        }

        /// <summary>
        /// The subscriber number.
        /// </summary>
        /// <remarks>
        /// This is the third part of the phone number. It allows for 0-9 for each digit.
        /// </remarks>
        public string SubscriberNumber
        {
            get { return subscriberNumber; }
        }

        /// <summary>
        /// Implements the !=.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(PhoneNumber a, PhoneNumber b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Implements the ==.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(PhoneNumber a, PhoneNumber b)
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
            if (!(obj is PhoneNumber)) return false;

            var other = (PhoneNumber)obj;

            return Equals(other);
        }

        /// <summary>
        /// Determines if two PhoneNumber objects are equal.
        /// </summary>
        /// <param name="other">The other phone number.</param>
        /// <returns><c>true</c> if equal, <c>false</c> otherwise.</returns>
        public bool Equals(PhoneNumber other)
        {
            return AreaCode.Equals(other.AreaCode) && ExchangeCode.Equals(other.ExchangeCode) && SubscriberNumber.Equals(other.SubscriberNumber);
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
            return AreaCode.GetHashCode() + ExchangeCode.GetHashCode() + SubscriberNumber.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Concat(this.areaCode, this.exchangeCode, this.subscriberNumber);
        }

        /// <summary>
        /// Validates the area code.
        /// </summary>
        /// <param name="areaCodeToValidate">The area code.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The NANP does not allow area codes to start with zero (0). or The NANP does not allow
        /// area codes to start with one (1). or The NANP does not allow area codes with nine (9) as
        /// the second digit.
        /// </exception>
        private void ValidateAreaCode(string areaCodeToValidate)
        {
            if (areaCodeToValidate.StartsWith("0")) throw new ArgumentOutOfRangeException(nameof(areaCodeToValidate), "The NANP does not allow area codes to start with zero (0).");
            if (areaCodeToValidate.StartsWith("1")) throw new ArgumentOutOfRangeException(nameof(areaCodeToValidate), "The NANP does not allow area codes to start with one (1).");
            if (areaCodeToValidate.ElementAt(2).Equals('9')) throw new ArgumentOutOfRangeException(nameof(areaCodeToValidate), "The NANP does not allow area codes with nine (9) as the second digit.");
        }

        /// <summary>
        /// Validates the exchange code.
        /// </summary>
        /// <param name="exchangeCodeToValidate">The exchange code to validate.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The NANP does not allow exchange codes to start with zero (0). or The NANP does not
        /// allow exchange codes to start with one (1).
        /// </exception>
        private void ValidateExchangeCode(string exchangeCodeToValidate)
        {
            if (exchangeCodeToValidate.StartsWith("0")) throw new ArgumentOutOfRangeException(nameof(exchangeCodeToValidate), "The NANP does not allow exchange codes to start with zero (0).");
            if (exchangeCodeToValidate.StartsWith("1")) throw new ArgumentOutOfRangeException(nameof(exchangeCodeToValidate), "The NANP does not allow exchange codes to start with one (1).");
        }
    }
}
