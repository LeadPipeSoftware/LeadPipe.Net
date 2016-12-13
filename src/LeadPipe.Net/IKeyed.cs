// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net
{
    /// <summary>
    /// Defines an instance that is keyed.
    /// </summary>
    public interface IKeyed
    {
        /// <summary>
        /// Gets the Key.
        /// </summary>
        string Key { get; }
    }
}