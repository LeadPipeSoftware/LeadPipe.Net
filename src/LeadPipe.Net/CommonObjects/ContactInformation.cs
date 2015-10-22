// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactInformation.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace LeadPipe.Net.CommonObjects
{
    /// <summary>
    /// A type representing contact information.
    /// </summary>
    public class ContactInformation
    {
        /// <summary>
        /// The contact's phone numbers.
        /// </summary>
        private Dictionary<string, PhoneNumber> phoneNumbers;

        /// <summary>
        /// The contact's addresses.
        /// </summary>
        private Dictionary<string, Address> addresses;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInformation" /> class.
        /// </summary>
        /// <param name="phoneNumbers">The phone numbers.</param>
        /// <param name="addresses">The addresses.</param>
        public ContactInformation(Dictionary<string, PhoneNumber> phoneNumbers, Dictionary<string, Address> addresses)
        {
            this.phoneNumbers = phoneNumbers;
            this.addresses = addresses;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInformation"/> class.
        /// </summary>
        public ContactInformation()
        {
        }

        /// <summary>
        /// The contact's phone numbers.
        /// </summary>
        public virtual Dictionary<string, PhoneNumber> PhoneNumbers
        {
            get { return phoneNumbers; }
        }

        /// <summary>
        /// The contact's addresses.
        /// </summary>
        public virtual Dictionary<string, Address> Addresses
        {
            get { return addresses; }
        }

        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="address">The address.</param>
        public virtual void AddAddress(string key, Address address)
        {
            this.addresses.Add(key, address);
        }

        /// <summary>
        /// Adds a phone number.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="phoneNumber">The phone number.</param>
        public virtual void AddPhoneNumber(string key, PhoneNumber phoneNumber)
        {
            this.phoneNumbers.Add(key, phoneNumber);
        }
    }
}