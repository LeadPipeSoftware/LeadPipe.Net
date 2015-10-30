// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.CommonObjects
{
    /// <summary>
    /// A simple representation of a person.
    /// </summary>
    public class Person
    {
        #region Private Properties

        private string Ethnicity; // TODO
        private string EmploymentStatus;
        private string Religion;
        private string DeathDate;

        /// <summary>
        /// The person's birthday.
        /// </summary>
        private Birthday birthday;

        /// <summary>
        /// The person's contact information.
        /// </summary>
        private ContactInformation contactInformation;

        /// <summary>
        /// The person's health information.
        /// </summary>
        private HealthInformation healthInformation;

        /// <summary>
        /// The person's marital status.
        /// </summary>
        private MaritalStatus maritalStatus;

        /// <summary>
        /// The person's name.
        /// </summary>
        private PersonalName name;

        /// <summary>
        /// The person's social security number.
        /// </summary>
        private SocialSecurityNumber socialSecurityNumber;

        #endregion Private Properties

        public Person()
        {
            this.birthday = new Birthday();
            this.contactInformation = new ContactInformation();
            this.name = new PersonalName();
            this.healthInformation = new HealthInformation();
        }

        #region Public Properties

        /// <summary>
        /// The person's name.
        /// </summary>
        public virtual PersonalName Name
        {
            get { return name; }
        }

        /// <summary>
        /// The person's birthday.
        /// </summary>
        public virtual Birthday Birthday
        {
            get { return birthday; }
        }

        /// <summary>
        /// The person's health information.
        /// </summary>
        public virtual HealthInformation HealthInformation
        {
            get { return healthInformation; }
        }

        /// <summary>
        /// The person's contact information.
        /// </summary>
        public virtual ContactInformation ContactInformation
        {
            get { return contactInformation; }
        }

        /// <summary>
        /// The person's social security number.
        /// </summary>
        public SocialSecurityNumber SecurityNumber
        {
            get { return socialSecurityNumber; }
        }

        /// <summary>
        /// The person's marital status.
        /// </summary>
        public MaritalStatus MaritalStatus
        {
            get { return maritalStatus; }
        }

        #endregion Public Properties

        #region Public Methods

        #endregion Protected Methods
    }
}