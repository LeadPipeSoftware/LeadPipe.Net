// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Data
{
    /// <summary>
    /// The interface for objects that use schema.
    /// </summary>
    public interface IUseSchema
    {
        /// <summary>
        /// Gets the name of the schema.
        /// </summary>
        string SchemaName { get; }
    }
}