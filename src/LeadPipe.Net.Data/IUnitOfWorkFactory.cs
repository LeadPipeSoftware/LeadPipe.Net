// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Data
{
    /// <summary>
    /// Defines a unit of work factory.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Gets or sets the Unit of Work batch mode.
        /// </summary>
        /// <value>
        /// The Unit of Work batch mode.
        /// </value>
        UnitOfWorkBatchMode UnitOfWorkBatchMode { get; set; }

        /// <summary>
        /// Creates a new Unit of Work.
        /// </summary>
        /// <returns>
        /// A Unit of Work.
        /// </returns>
        IUnitOfWork CreateUnitOfWork();
    }
}