// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HealthInformation.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.CommonObjects.CommonObjects
{
    /// <summary>
    /// A class that represents health information for a person.
    /// </summary>
    public class HealthInformation
    {
        /// <summary>
        /// The blood type.
        /// </summary>
        private BloodType bloodType;

        /// <summary>
        /// The blood type.
        /// </summary>
        public virtual BloodType BloodType
        {
            get { return bloodType; }
        }
    }
}