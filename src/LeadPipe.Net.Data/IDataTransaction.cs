// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Data
{
    /// <summary>
    /// Defines a generic data transaction.
    /// </summary>
    public interface IDataTransaction : IDisposable
    {
        /// <summary>
        /// Commits the transaction.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rolls the transaction back.
        /// </summary>
        void Rollback();
    }
}