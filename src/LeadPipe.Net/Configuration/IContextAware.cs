// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Configuration
{
    /// <summary>
    /// Defines an object that is context aware.
    /// </summary>
    public interface IContextAware
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        string Context { get; }
    }
}