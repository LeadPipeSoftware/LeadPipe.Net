// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LeadPipe.Net.Domain;
using LeadPipe.Net.Specifications;

namespace LeadPipe.Net.Data
{
	/// <summary>
	/// The base repository.
	/// </summary>
	/// <typeparam name="T">The repository type.</typeparam>
	public class Repository<T> : IRepository<T>, IEnumerable where T : class
	{
		#region Constants and Fields

        /// <summary>
        /// The data command provider.
        /// </summary>
	    private readonly IDataCommandProvider dataCommandProvider;

	    /// <summary>
        /// The query runner.
        /// </summary>
	    private readonly IQueryRunner<T> queryRunner;

	    #endregion

		#region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository&lt;T&gt;" /> class.
        /// </summary>
        /// <param name="dataCommandProvider">The data command provider.</param>
        /// <param name="queryRunner">The query runner.</param>
		public Repository(IDataCommandProvider dataCommandProvider, IQueryRunner<T> queryRunner)
		{
            this.dataCommandProvider = dataCommandProvider;
            this.queryRunner = queryRunner;
		}

	    #endregion

		#region Public Properties

        /// <summary>
        /// Gets all objects.
        /// </summary>
        public virtual IQueryable<T> All
        {
            get
            {
                return this.dataCommandProvider.Query<T>();
            }
        }

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        public virtual IQueryable<T> DataSource { get; set; }

        /// <summary>
        /// Returns the repository (syntax sugar).
        /// </summary>
        public IRepository<T> Find
        {
            get
            {
                return this;
            }
        }

		/// <summary>
		/// Gets the type of object the repository manages.
		/// </summary>
		/// <value>
		/// The object type of the repository.
		/// </value>
		public Type RepositoryType
		{
			get
			{
				return typeof(T);
			}
		}

        #endregion

        #region Public Methods

        /// <summary>
		/// Represents an <see cref="IQueryable"/> list of objects that match a LINQ expression.
		/// </summary>
		/// <param name="expression">
		/// The LINQ expression.
		/// </param>
		/// <returns>
		/// The <see cref="IQueryable"/> list of matching objects.
		/// </returns>
		public virtual IQueryable<T> AllMatchingExpression(Expression<Func<T, bool>> expression)
		{
			return this.All.Where(expression).AsQueryable();
		}

		/// <summary>
		/// Returns an <see cref="IEnumerable{T}"/> list of objects that match the supplied specification.
		/// </summary>
		/// <param name="specification">
		/// The specification.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable{T}"/> list of matching objects.
		/// </returns>
		public virtual IEnumerable<T> AllMatchingSpecification(ISpecification<T> specification)
		{
			return this.All.Where(specification.SatisfiedBy()).AsEnumerable();
		}

	    /// <summary>
	    /// Returns all objects that match the supplied query.
	    /// </summary>
	    /// <param name="query">The query.</param>
	    /// <returns>All objects matching the supplied query.</returns>
	    public virtual IEnumerable<T> AllMatchingQuery(IQuery<IEnumerable<T>> query)
	    {
	        return this.queryRunner.GetQueryResult(query);
	    }

        /// <summary>
        /// Gets the expression tree that is associated with the instance of <see cref="T:System.Linq.IQueryable" />.
        /// </summary>
        /// <returns>The <see cref="T:System.Linq.Expressions.Expression" /> that is associated with this instance of <see cref="T:System.Linq.IQueryable" />.</returns>
        public Expression Expression
        {
            get
            {
                return this.dataCommandProvider.Query<T>().Expression;
            }
        }

        /// <summary>
        /// Gets the type of the element(s) that are returned when the expression tree associated with this instance of <see cref="T:System.Linq.IQueryable" /> is executed.
        /// </summary>
        /// <returns>A <see cref="T:System.Type" /> that represents the type of the element(s) that are returned when the expression tree associated with this object is executed.</returns>
        public Type ElementType
        {
            get
            {
                return this.dataCommandProvider.Query<T>().ElementType;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.dataCommandProvider.Query<T>().GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.dataCommandProvider.Query<T>().GetEnumerator();
        }

		/// <summary>
		/// Returns a single result that matches the supplied expression.
		/// </summary>
		/// <param name="expression">
		/// The expression.
		/// </param>
		/// <returns>
		/// The matching object or default value if no match was found.
		/// </returns>
		public virtual T One(Expression<Func<T, bool>> expression)
		{
			return this.All.SingleOrDefault(expression);
		}

		/// <summary>
		/// Returns a single result that matches the supplied specification.
		/// </summary>
		/// <param name="specification">
		/// The specification.
		/// </param>
		/// <returns>
		/// The matching object or default value if no match was found.
		/// </returns>
		public virtual T One(ISpecification<T> specification)
		{
			return this.All.Where(specification.SatisfiedBy()).SingleOrDefault();
		}

        /// <summary>
        /// Returns a single result that matches the supplied query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The matching object or default value if no match was found.</returns>
        public virtual T One(IQuery<T> query)
        {
            return this.queryRunner.GetQueryResult(query);
        }

		/// <summary>
		/// Returns a single result with the supplied key.
		/// </summary>
		/// <param name="key">
		/// The key.
		/// </param>
		/// <returns>
		/// The matching object or default value if no match was found.
		/// </returns>
		[Obsolete("This method is deprecated. Please use the Repository.Load or Repository.Get methods instead.")]
		public T One(string key)
		{
			/*
			 * This is really a bad idea as it bypasses all of the good stuff that NHibernate gives us when
			 * it comes to caching. Doing it this way means that we HAVE to hit the database which bypasses
			 * the first level identiy map and the second level cache. Ayende Rahien gives us the deets:
			 * 
			 * http://ayende.com/blog/3988/nhibernate-the-difference-between-get-load-and-querying-by-id
			 * 
			 * It should also be noted that RavenDB doesn't support Cast as of 4/27/2013 so, well, there you
			 * have it. Don't use this method, kids.
			 */

			return (T)this.All.Cast<IKeyed>().SingleOrDefault(x => x.Key == key);
		}        

		/// <summary>
		/// Gets the query provider that is associated with this data source.
		/// </summary>
		/// <returns>The <see cref="T:System.Linq.IQueryProvider" /> that is associated with this data source.</returns>
		public IQueryProvider Provider
		{
			get
			{
				return this.dataCommandProvider.Query<T>().Provider;
			}
        }

        #endregion
    }
}