// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Data
{
    /// <summary>
    /// Defines a unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /*
         * Martin Fowler defines the Unit of Work as follows:
         *
         * "Maintains a list of objects affected by a business transaction and coordinates the writing out of changes
         * and the resolution of concurrency problems."
         *
         * Simply put, a unit of work's concern is to manage the changes you're making. The most important thing to
         * note is the word "business" in Martin's definition. A database transaction may be a component of a unit of
         * work, but a unit of work isn't just a database transaction.
         */

        /// <summary>
        /// Defines an action that occurs after the Unit of Work is committed.
        /// </summary>
        Action InvokeAfterCommit { get; set; }

        /// <summary>
        /// Defines an action that occurs before the Unit of Work is committed.
        /// </summary>
        Action InvokeBeforeCommit { get; set; }

        /// <summary>
        /// Defines an action that occurs if an exception occurs during commit.
        /// </summary>
        Action InvokeOnCommitException { get; set; }

        /// <summary>
        /// Defines an action that occurs immediately prior to the transaction being rolled back.
        /// </summary>
        Action InvokeOnRollback { get; set; }

        /// <summary>
        /// Gets a value indicating whether the unit of work is started.
        /// </summary>
        /// <value><c>true</c> if this instance is started; otherwise, <c>false</c>.</value>
        bool IsStarted { get; }

        /// <summary>
        /// Gets the nest level.
        /// </summary>
        /// <value>The nest level.</value>
        int NestLevel { get; }

        /// <summary>
        /// Gets the Unit of Work batch mode.
        /// </summary>
        /// <value>The Unit of Work batch mode.</value>
        UnitOfWorkBatchMode UnitOfWorkBatchMode { get; }

        /// <summary>
        /// Commits the changes made in the unit of work.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rolls back the unit of work changes.
        /// </summary>
        void Rollback();

        /// <summary>
        /// Starts the unit of work.
        /// </summary>
        /// <returns>A started unit of work.</returns>
        IUnitOfWork Start();
    }
}