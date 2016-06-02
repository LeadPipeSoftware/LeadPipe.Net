// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NHibernate;

namespace LeadPipe.Net.Data.NHibernate
{
    /// <summary>
    /// An NHibernate implementation of IDataTransaction.
    /// </summary>
    public sealed class DataTransaction : IDataTransaction
    {
        /// <summary>
        /// The NHibernate transaction.
        /// </summary>
        private readonly ITransaction transaction;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTransaction"/> class.
        /// </summary>
        /// <param name="transaction">
        /// The transaction.
        /// </param>
        public DataTransaction(ITransaction transaction)
        {
            this.transaction = transaction;
        }

        /// <summary>
        /// Flushes the session and commits the transaction.
        /// </summary>
        public void Commit()
        {
            this.transaction.Commit();
        }

        /// <summary>
        /// Disposes the transaction.
        /// </summary>
        public void Dispose()
        {
            this.transaction.Dispose();
        }

        /// <summary>
        /// Forces the transaction to roll back.
        /// </summary>
        public void Rollback()
        {
            this.transaction.Rollback();
        }
    }
}