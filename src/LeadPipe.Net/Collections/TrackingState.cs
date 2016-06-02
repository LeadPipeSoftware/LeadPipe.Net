// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Collections
{
    /// <summary>
    /// The tracking state.
    /// </summary>
    public enum TrackingState
    {
        /// <summary>
        /// Indicates that the tracking state is unknown (which should really never happen).
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates that an item is not changed, deleted or added.
        /// </summary>
        Unchanged,

        /// <summary>
        /// Indicates an item was changed.
        /// </summary>
        Changed,

        /// <summary>
        /// Indicates an item was removed.
        /// </summary>
        Removed,

        /// <summary>
        /// Indicates an item was added.
        /// </summary>
        Added
    }
}