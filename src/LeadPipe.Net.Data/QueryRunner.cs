// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryRunner.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using LeadPipe.Net.Domain;

namespace LeadPipe.Net.Data
{
	/// <summary>
	/// Generic query runner implementation.
	/// </summary>
	/// <typeparam name="T">
	/// The type of the object.
	/// </typeparam>
	public class QueryRunner<T> : IQueryRunner<T>
	{
		#region Constants and Fields

		/// <summary>
		/// The data command provider.
		/// </summary>
		private readonly IDataCommandProvider dataCommandProvider;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="QueryRunner&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="dataCommandProvider">The data command provider.</param>
		public QueryRunner(IDataCommandProvider dataCommandProvider)
		{
			Guard.Will.ProtectAgainstNullArgument(() => dataCommandProvider);

			this.dataCommandProvider = dataCommandProvider;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the data source.
		/// </summary>
		public virtual IQueryable<T> DataSource { get; set; }

		#endregion

		#region Public Methods and Operators

        /// <summary>
        /// Gets the query result.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The result of the query.</returns>
        public T GetQueryResult(IQuery<T> query)
        {
            var result = query.GetResult();

            return result;
        }

        /// <summary>
        /// Gets the query result.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The result of the query.</returns>
	    public IEnumerable<T> GetQueryResult(IQuery<IEnumerable<T>> query)
	    {
	        var results = query.GetResult();

	        return results;
	    }

	    #endregion
	}
}