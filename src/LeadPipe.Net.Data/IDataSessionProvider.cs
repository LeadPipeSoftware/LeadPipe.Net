// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Data
{
    /// <summary>
    /// The data session provider.
    /// </summary>
    /// <remarks>
    /// The DataSessionProvider's job is to create DataSession objects.
    /// </remarks>
    /// <typeparam name="T">The session type.</typeparam>
    public interface IDataSessionProvider<T>
    {
        /// <summary>
        /// Creates a data session instance.
        /// </summary>
        /// <returns>
        /// A new data session.
        /// </returns>
        T Create();
    }
}