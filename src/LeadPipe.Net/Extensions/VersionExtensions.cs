// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Extensions
{
    /// <summary>
    /// Extension methods for the Version type.
    /// </summary>
    public static class VersionExtensions
    {
        /// <summary>
        /// Determines whether a Version is newer than another Version.
        /// </summary>
        /// <param name="firstVersion">The first version.</param>
        /// <param name="secondVersion">The second version.</param>
        /// <returns>
        ///   <c>true</c> if [is newer than] [the specified version]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNewerThan(this Version firstVersion, Version secondVersion)
        {
            return firstVersion.CompareTo(secondVersion) > 0;
        }

        /// <summary>
        /// Determines whether a Version is newer than or equal to another Version.
        /// </summary>
        /// <param name="firstVersion">The first version.</param>
        /// <param name="secondVersion">The second version.</param>
        /// <returns>
        ///   <c>true</c> if [is newer than] [the specified version]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNewerThanOrEqualTo(this Version firstVersion, Version secondVersion)
        {
            return firstVersion.CompareTo(secondVersion) >= 0;
        }

        /// <summary>
        /// Determines whether a Version is older than another Version.
        /// </summary>
        /// <param name="firstVersion">The first version.</param>
        /// <param name="secondVersion">The second version.</param>
        /// <returns>
        ///   <c>true</c> if [is newer than] [the specified version]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOlderThan(this Version firstVersion, Version secondVersion)
        {
            return firstVersion.CompareTo(secondVersion) < 0;
        }

        /// <summary>
        /// Determines whether a Version is older than or equal to another Version.
        /// </summary>
        /// <param name="firstVersion">The first version.</param>
        /// <param name="secondVersion">The second version.</param>
        /// <returns>
        ///   <c>true</c> if [is newer than] [the specified version]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOlderThanOrEqualTo(this Version firstVersion, Version secondVersion)
        {
            return firstVersion.CompareTo(secondVersion) <= 0;
        }
    }
}