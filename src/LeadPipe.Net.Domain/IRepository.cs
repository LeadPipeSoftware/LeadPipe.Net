// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;
using LeadPipe.Net.Specifications;

namespace LeadPipe.Net.Domain
{
	using System.Collections.Generic;

	/// <summary>
	/// Defines a strongly-typed repository.
	/// </summary>
	/// <typeparam name="T">
	/// The type that the repository serves.
	/// </typeparam>
	public interface IRepository<T>
        where T : class
	{
		/*
		 * Anyone paying attention would likely notice that I've been careful to use the term 'object' rather than
		 * 'entity' throughout this type. Why? Because while entities are access via repositories in DDD, that doesn't
		 * mean that the repository pattern doesn't have value outside of DDD as well. For that matter, we should take
		 * care to remember that persistence does not necessarily mean "save it to disk" and that the pattern is useful
		 * beyond CRUD.
		 */

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        IQueryable<T> DataSource { get; set; }

        /// <summary>
        /// Gets all objects.
        /// </summary>
        IQueryable<T> All { get; }

	    /// <summary>
	    /// Returns the repository (syntax sugar).
	    /// </summary>
	    IRepository<T> Find { get; }

        /// <summary>
        /// Returns an <see cref="IQueryable"/> list of objects that match a LINQ expression.
        /// </summary>
        /// <param name="expression">
        /// The LINQ expression.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/> list of matching objects.
        /// </returns>
        IQueryable<T> AllMatchingExpression(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> list of objects that match the supplied specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/> list of matching objects.
        /// </returns>
        IEnumerable<T> AllMatchingSpecification(ISpecification<T> specification);

	    /// <summary>
	    /// Returns all objects that match the supplied query.
	    /// </summary>
	    /// <param name="query">The query.</param>
	    /// <returns>All objects matching the supplied query.</returns>
	    IEnumerable<T> AllMatchingQuery(IQuery<IEnumerable<T>> query);

        /// <summary>
        /// Returns a single result that matches the supplied specification.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The matching entity or default value if no match was found.
        /// </returns>
        T One(string key);

        /// <summary>
        /// Returns a single result that matches the supplied specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The matching entity or default value if no match was found.</returns>
        T One(ISpecification<T> specification);

        /// <summary>
        /// Returns a single result that matches the LINQ expression.
        /// </summary>
        /// <param name="expression">The LINQ expression.</param>
        /// <returns>The matching entity or default value if no match was found.</returns>
        T One(Expression<Func<T, bool>> expression);

	    /// <summary>
	    /// Returns a single result that matches the supplied query.
	    /// </summary>
	    /// <param name="query">The query.</param>
	    /// <returns>The matching object or default value if no match was found.</returns>
	    T One(IQuery<T> query);
	}
}