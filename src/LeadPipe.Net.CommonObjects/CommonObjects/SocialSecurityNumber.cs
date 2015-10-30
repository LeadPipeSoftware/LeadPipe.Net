// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SocialSecurityNumber.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using System;
using System.Linq;

namespace LeadPipe.Net.CommonObjects.CommonObjects
{
    /// <summary>
    /// A struct representing a Social Security Number.
    /// </summary>
    public struct SocialSecurityNumber
    {
        /// <summary>
        /// The area number.
        /// </summary>
        private readonly string areaNumber;

        /// <summary>
        /// The group number.
        /// </summary>
        private readonly string groupNumber;

        /// <summary>
        /// The serial number.
        /// </summary>
        private readonly string serialNumber;

        public SocialSecurityNumber(string socialSecurityNumber)
        {
            var numbersOnly = new string(socialSecurityNumber.Where(char.IsDigit).ToArray());

            Guard.Will.ThrowExceptionOfType<ArgumentException>("The supplied value is not a valid Social Security Number.").When(numbersOnly.IsValidSocialSecurityNumber().IsFalse());

            this.areaNumber = numbersOnly.Substring(0, 2);
            this.groupNumber = numbersOnly.Substring(3, 4);
            this.serialNumber = numbersOnly.Substring(5, 8);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumber"/> struct.
        /// </summary>
        /// <param name="areaNumber">The area code.</param>
        /// <param name="groupNumber">The exchange code.</param>
        /// <param name="serialNumber">The subscriber number.</param>
        public SocialSecurityNumber(string areaNumber, string groupNumber, string serialNumber)
        {
            var numbersOnly = string.Concat(areaNumber, groupNumber, serialNumber);

            Guard.Will.ThrowExceptionOfType<ArgumentException>("The supplied value is not a valid Social Security Number.").When(numbersOnly.IsValidSocialSecurityNumber().IsFalse());

            this.areaNumber = areaNumber;
            this.groupNumber = groupNumber;
            this.serialNumber = serialNumber;
        }

        /// <summary>
        /// The area number.
        /// </summary>
        public string AreaNumber
        {
            get { return areaNumber; }
        }

        /// <summary>
        /// The group number.
        /// </summary>
        public string GroupNumber
        {
            get { return groupNumber; }
        }

        /// <summary>
        /// The serial number.
        /// </summary>
        public string SerialNumber
        {
            get { return serialNumber; }
        }

        /// <summary>
        /// Implements the !=.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(SocialSecurityNumber a, SocialSecurityNumber b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Implements the ==.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(SocialSecurityNumber a, SocialSecurityNumber b)
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
            if (!(obj is SocialSecurityNumber)) return false;

            var other = (SocialSecurityNumber)obj;

            return Equals(other);
        }

        /// <summary>
        /// Determines if two SocialSecurityNumber objects are equal.
        /// </summary>
        /// <param name="other">The other number.</param>
        /// <returns><c>true</c> if equal, <c>false</c> otherwise.</returns>
        public bool Equals(SocialSecurityNumber other)
        {
            return AreaNumber.Equals(other.AreaNumber) && GroupNumber.Equals(other.GroupNumber) && SerialNumber.Equals(other.SerialNumber);
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
            return AreaNumber.GetHashCode() + GroupNumber.GetHashCode() + SerialNumber.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Concat(this.areaNumber, this.groupNumber, this.serialNumber);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance with dashes.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance with dashes.</returns>
        public string ToStringWithDashes()
        {
            return string.Concat(this.areaNumber, "-", this.groupNumber, "-", this.serialNumber);
        }
    }
}