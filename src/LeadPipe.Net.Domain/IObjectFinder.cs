// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
    using Specifications;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// The persistable object finder interface.
    /// </summary>
    /// <typeparam name="T">The type of the persistable object.</typeparam>
    public interface IObjectFinder<T> : IQueryable<T>
    {
        /// <summary>
        /// Gets all objects.
        /// </summary>
        IQueryable<T> All { get; }

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        IQueryable<T> DataSource { get; set; }

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
        /// Returns all objects that match the supplied query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>All objects matching the supplied query.</returns>
        IEnumerable<T> AllMatchingQuery(IQuery<IEnumerable<T>> query);

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
        /// Returns a single result that matches the supplied specification.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The matching entity or exception if no match was found.
        /// </returns>
        T ByKey(string key);

        /// <summary>
        /// Returns a single result that matches the LINQ expression.
        /// </summary>
        /// <param name="expression">The LINQ expression.</param>
        /// <returns>The matching entity or exception if no match was found.</returns>
        T OneMatchingExpression(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Returns a single result that matches the supplied specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The matching entity or exception if no match was found.</returns>
        T OneMatchingSpecification(ISpecification<T> specification);
    }
}