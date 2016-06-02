// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using LeadPipe.Net.Specifications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LeadPipe.Net.Data
{
    /// <summary>
    /// Generic persistable object finder implementation.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    public class ObjectFinder<T> : IObjectFinder<T>
    {
        /// <summary>
        /// The data command provider.
        /// </summary>
        private readonly IDataCommandProvider dataCommandProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectFinder&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="dataCommandProvider">The data command provider.</param>
        public ObjectFinder(IDataCommandProvider dataCommandProvider)
        {
            Guard.Will.ProtectAgainstNullArgument(() => dataCommandProvider);

            this.dataCommandProvider = dataCommandProvider;
        }

        /// <summary>
        /// Gets all entities.
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
        /// Represents an <see cref="IQueryable"/> list of entities that match a LINQ expression.
        /// </summary>
        /// <param name="expression">
        /// The LINQ expression.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/> list of matching entities.
        /// </returns>
        public virtual IQueryable<T> AllMatchingExpression(Expression<Func<T, bool>> expression)
        {
            return this.All.Where(expression).AsQueryable();
        }

        /// <summary>
        /// Returns all objects that match the supplied query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>All objects matching the supplied query.</returns>
        public virtual IEnumerable<T> AllMatchingQuery(IQuery<IEnumerable<T>> query)
        {
            return query.GetResult();
        }

        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> list of entities that match the supplied specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/> list of matching entities.
        /// </returns>
        public virtual IEnumerable<T> AllMatchingSpecification(ISpecification<T> specification)
        {
            return this.All.Where(specification.SatisfiedBy()).AsEnumerable();
        }

        /// <summary>
        /// Returns a single result that has the supplied key value.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The matching object or an exception if no match was found.
        /// </returns>
        public T ByKey(string key)
        {
            return (T)this.All.Cast<IKeyed>().SingleOrDefault(x => x.Key == key);
        }

        /// <summary>
        /// Returns a single result that matches the supplied expression.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <returns>
        /// The matching object or exception if no match was found.
        /// </returns>
        public virtual T OneMatchingExpression(Expression<Func<T, bool>> expression)
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
        /// The matching object or exception if no match was found.
        /// </returns>
        public virtual T OneMatchingSpecification(ISpecification<T> specification)
        {
            return this.All.Where(specification.SatisfiedBy()).SingleOrDefault();
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
    }
}