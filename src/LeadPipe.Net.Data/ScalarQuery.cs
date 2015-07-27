// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScalarQuery.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;

namespace LeadPipe.Net.Data
{
    /// <summary>
    /// A scalar query object.
    /// </summary>
    /// <typeparam name="TResultType">The type of the result.</typeparam>
    public abstract class ScalarQuery<TResultType> : IQuery<TResultType>
    {
        protected readonly IDataCommandProvider dataCommandProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScalarQuery{TResult}"/> class.
        /// </summary>
        /// <param name="dataCommandProvider">The data command provider.</param>
        protected ScalarQuery(IDataCommandProvider dataCommandProvider)
        {
            this.dataCommandProvider = dataCommandProvider;
        }

        /// <summary>
        /// Gets the result of the query.
        /// </summary>
        /// <returns>
        /// The result of the query.
        /// </returns>
        public abstract TResultType GetResult();
    }
}