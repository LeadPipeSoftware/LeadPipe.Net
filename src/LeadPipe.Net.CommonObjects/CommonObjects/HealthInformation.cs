// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
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
        public virtual BloodType BloodType { get; set; }
    }
}