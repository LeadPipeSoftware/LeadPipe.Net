// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using NHibernate;
using System.Collections.Generic;

namespace LeadPipe.Net.Data.NHibernate
{
    /// <summary>
    /// A query object.
    /// </summary>
    /// <typeparam name="TResultType">The type of the result.</typeparam>
    public abstract class Query<TResultType> : IQuery<IEnumerable<TResultType>>
    {
        /// <summary>
        /// The data command provider.
        /// </summary>
        protected readonly DataCommandProvider dataCommandProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="Query{TResult}"/> class.
        /// </summary>
        /// <param name="dataCommandProvider">The data command provider.</param>
        protected Query(IDataCommandProvider dataCommandProvider)
        {
            this.dataCommandProvider = (DataCommandProvider)dataCommandProvider;
        }

        /// <summary>
        /// Gets the NHibernate session object.
        /// </summary>
        /// <value>
        /// The NHibernate session object.
        /// </value>
        protected ISession Session
        {
            get { return dataCommandProvider.Session; }
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