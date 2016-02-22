// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Query.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using LeadPipe.Net.Domain;

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