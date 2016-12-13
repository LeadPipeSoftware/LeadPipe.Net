// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net
{
    /// <summary>
    /// Defines a local data object.
    /// </summary>
    public interface ILocalData
    {
        /// <summary>
        /// Gets a count of the local data objects.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets or sets local data.
        /// </summary>
        /// <param name="key">The object data key.</param>
        /// <returns>The local data object.</returns>
        object this[object key] { get; set; }

        /// <summary>
        /// Clears all local data objects.
        /// </summary>
        void Clear();
    }
}