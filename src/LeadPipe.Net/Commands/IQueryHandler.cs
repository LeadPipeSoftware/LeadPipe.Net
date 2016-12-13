// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Commands
{
    /// <summary>
    /// Handles queries.
    /// </summary>
    /// <typeparam name="TRequest">The type of the query request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface IQueryHandler<in TRequest, out TResponse>
        where TRequest : IQuery<TResponse>
    {
        /// <summary>
        /// Handles the specified query request.
        /// </summary>
        /// <param name="request">The query request.</param>
        /// <returns>The response.</returns>
        TResponse Handle(TRequest request);
    }
}