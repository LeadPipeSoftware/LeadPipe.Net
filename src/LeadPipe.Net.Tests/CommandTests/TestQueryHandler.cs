// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Commands;

namespace LeadPipe.Net.Tests.CommandTests
{
    /// <summary>
    /// Handles test queries.
    /// </summary>
    public class TestQueryHandler : IQueryHandler<TestQuery, string>
    {
        /// <summary>
        /// Handles the specified query request.
        /// </summary>
        /// <param name="request">The query request.</param>
        /// <returns>The response.</returns>
        public string Handle(TestQuery request)
        {
            return request.Execute();
        }
    }
}