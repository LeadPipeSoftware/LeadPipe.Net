// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net
{
    /// <summary>
    /// Represents system time.
    /// </summary>
    public class Clock : IClock
    {
        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <returns>
        /// The current time.
        /// </returns>
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Gets the current UTC time.
        /// </summary>
        /// <returns>
        /// The current UTC time.
        /// </returns>
        public DateTime GetCurrentUtcTime()
        {
            return DateTime.UtcNow;
        }
    }
}