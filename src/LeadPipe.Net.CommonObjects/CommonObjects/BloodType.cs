// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.CommonObjects.CommonObjects
{
    /// <summary>
    /// An enumeration of blood types.
    /// </summary>
    public enum BloodType
    {
        [Abbreviation("O+")]
        OPositive = 0,

        [Abbreviation("O-")]
        ONegative = 1,

        [Abbreviation("A+")]
        APositive = 2,

        [Abbreviation("A-")]
        ANegative = 3,

        [Abbreviation("B+")]
        BPositive = 4,

        [Abbreviation("B-")]
        BNegative = 5,

        [Abbreviation("AB+")]
        AbPositive = 6,

        [Abbreviation("AB-")]
        AbNegative = 7
    }
}