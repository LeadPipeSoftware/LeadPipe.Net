// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWorkBatchMode.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Data
{
    /// <summary>
    /// The Unit of Work Batch Mode.
    /// </summary>
    public enum UnitOfWorkBatchMode
    {
        /// <summary>
        /// Every call to UnitOfWork.Start that is made after the initial call will result in the work being contained in a single transaction.
        /// </summary>
        Singular,
        /// <summary>
        /// Every call to UnitOfWork.Start will result in a new transaction and session commit.
        /// </summary>
        Nested
    }
}