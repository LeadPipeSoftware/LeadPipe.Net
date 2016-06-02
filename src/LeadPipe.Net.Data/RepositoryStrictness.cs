// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Data
{
    /// <summary>
    /// Determines how strict the repository is regarding DDD aggregate roots.
    /// </summary>
    public enum RepositoryStrictness
    {
        /// <summary>
        /// Exceptions are thrown if repositories are used with objects that do not inherit from IAggregateRoot.
        /// </summary>
        Strict,

        /// <summary>
        /// The repository will accept any kind of object.
        /// </summary>
        Open
    }
}