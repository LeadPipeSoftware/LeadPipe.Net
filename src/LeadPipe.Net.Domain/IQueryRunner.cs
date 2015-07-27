// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQueryRunner.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
    /// <summary>
    /// Runs queries.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IQueryRunner<TResult>
    {
        /// <summary>
        /// Gets the query result.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        TResult GetQueryResult(IQuery<TResult> query);
    }
}