// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuery.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
    /// <summary>
    /// A query that can be run with IQueryRunner.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IQuery<TResult>
    {
        /// <summary>
        /// Gets the result of the query.
        /// </summary>
        /// <returns>
        /// The result of the query.
        /// </returns>
        TResult GetResult();
    }
}