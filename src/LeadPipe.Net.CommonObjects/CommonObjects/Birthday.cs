// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Birthday.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.CommonObjects
{
    /// <summary>
    /// A simple representation of a birthday.
    /// </summary>
    public struct Birthday
    {
        #region Private Properties

        /// <summary>
        /// The birth date.
        /// </summary>
        private DateTime birthDate;

        #endregion Private Properties

        public Birthday(DateTime birthDate)
        {
            this.birthDate = birthDate;
        }

        #region Public Properties

        /// <summary>
        /// Gets the calculated age.
        /// </summary>
        /// <value>The calculated age.</value>
        public int Age
        {
            get
            {
                var today = DateTime.Today;

                var calculatedAge = today.Year - birthDate.Year;

                if (birthDate > today.AddYears(-calculatedAge)) calculatedAge--;

                return calculatedAge;
            }
        }

        /// <summary>
        /// Gets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        public DateTime BirthDate
        {
            get { return birthDate; }
        }

        /// <summary>
        /// Implements the !=.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Birthday a, Birthday b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Implements the ==.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Birthday a, Birthday b)
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
            if (!(obj is Birthday)) return false;

            var other = (Birthday)obj;

            return Equals(other);
        }

        /// <summary>
        /// Determines if two Birthday objects are equal.
        /// </summary>
        /// <param name="other">The other phone number.</param>
        /// <returns><c>true</c> if equal, <c>false</c> otherwise.</returns>
        public bool Equals(Birthday other)
        {
            return this.birthDate.Equals(other.birthDate);
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
            return this.birthDate.GetHashCode();
        }

        #endregion Public Properties
    }
}