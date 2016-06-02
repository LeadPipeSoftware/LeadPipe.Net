// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using System.Collections.Generic;

namespace LeadPipe.Net.Data
{
    /// <summary>
    /// A query object.
    /// </summary>
    /// <typeparam name="TResultType">The type of the result.</typeparam>
    public abstract class Query<TResultType> : IQuery<IEnumerable<TResultType>>
    {
        protected readonly IDataCommandProvider DataCommandProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="Query{TResult}"/> class.
        /// </summary>
        /// <param name="dataCommandProvider">The data command provider.</param>
        protected Query(IDataCommandProvider dataCommandProvider)
        {
            DataCommandProvider = dataCommandProvider;
        }

        /// <summary>
        /// Gets the result of the query.
        /// </summary>
        /// <returns>
        /// The result of the query.
        /// </returns>
        public abstract IEnumerable<TResultType> GetResult();
    }
}