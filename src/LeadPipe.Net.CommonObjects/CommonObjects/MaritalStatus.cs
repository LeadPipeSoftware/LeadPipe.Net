// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaritalStatus.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;

namespace LeadPipe.Net.CommonObjects.CommonObjects
{
    /// <summary>
    /// An enumeration of marital statuses.
    /// </summary>
    public enum MaritalStatus
    {
        [Description("Unspecified")]
        Unspecified = 0,

        [Abbreviation("Married")]
        Married = 1,

        [Description("Never Married")]
        NeverMarried = 2,

        [Description("Separated")]
        Separated = 3,

        [Description("Divorced")]
        Divorced = 4,

        [Description("Widowed")]
        Widowed = 5,

        [Description("Widower")]
        Widower = 6
    }
}