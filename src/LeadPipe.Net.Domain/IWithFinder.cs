// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
    /// <summary>
    /// The interface for objects that employ a finder.
    /// </summary>
    /// <typeparam name="TFinder">
    /// The type of the finder.
    /// </typeparam>
    public interface IWithFinder<TFinder>
    {
        /// <summary>
        /// Gets the entity finder interface.
        /// </summary>
        TFinder Find { get; }
    }
}