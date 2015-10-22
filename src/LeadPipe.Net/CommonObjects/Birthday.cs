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
    public class Birthday
    {
        #region Private Properties

        /// <summary>
        /// The calculated age.
        /// </summary>
        private int age;

        /// <summary>
        /// The birthdate.
        /// </summary>
        private DateTime birthdate;

        #endregion Private Properties

        #region Public Properties

        /// <summary>
        /// Gets the calculated age.
        /// </summary>
        /// <value>The calculated age.</value>
        public virtual int Age
        {
            get { return age; }
        }

        /// <summary>
        /// Gets the birthdate.
        /// </summary>
        /// <value>The birthdate.</value>
        public virtual DateTime Birthdate
        {
            get { return birthdate; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Updates the birthdate.
        /// </summary>
        /// <param name="birthdate">The birthdate.</param>
        public virtual void UpdateBirthday(DateTime birthdate)
        {
            this.birthdate = birthdate;

            this.age = CalculateAge();
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Calculates the age based on the birthdate.
        /// </summary>
        /// <returns>An integer representing the calculated age.</returns>
        protected virtual int CalculateAge()
        {
            var today = DateTime.Today;

            var calculatedAge = today.Year - birthdate.Year;

            if (birthdate > today.AddYears(-calculatedAge)) calculatedAge--;

            return calculatedAge;
        }

        #endregion Protected Methods
    }
}