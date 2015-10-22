// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CardinalDirection.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.CommonObjects
{
    /// <summary>
    /// The cardinal directions.
    /// </summary>
    public enum CardinalDirection
    {
        [Abbreviation("N")]
        North = 0,

        [Abbreviation("NE")]
        Northeast = 45,

        [Abbreviation("E")]
        East = 90,

        [Abbreviation("SE")]
        Southeast = 135,

        [Abbreviation("S")]
        South = 180,

        [Abbreviation("SW")]
        Southwest = 225,

        [Abbreviation("W")]
        West = 270,

        [Abbreviation("NW")]
        Northwest = 315
    }
}