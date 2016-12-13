// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
    /// <summary>
    /// A query that can be run with IQueryRunner.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IQuery<out TResult>
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