// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FetchReqeust.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Linq;

namespace LeadPipe.Net.Data.NHibernate
{
	/// <summary>
	/// An NHibernate fetch request.
	/// </summary>
	/// <typeparam name="TQueried">The type of the queried.</typeparam>
	/// <typeparam name="TFetch">The type of the fetch.</typeparam>
	public class FetchRequest<TQueried, TFetch> : IFetchRequest<TQueried, TFetch>
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="FetchRequest{TQueried, TFetch}" /> class.
		/// </summary>
		/// <param name="nhFetchRequest">The NHibernate fetch request.</param>
		public FetchRequest(INhFetchRequest<TQueried, TFetch> nhFetchRequest)
		{
			this.NhFetchRequest = nhFetchRequest;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the type of the element(s) that are returned when the expression tree associated with this instance of <see cref="T:System.Linq.IQueryable" /> is executed.
		/// </summary>
		/// <returns>A <see cref="T:System.Type" /> that represents the type of the element(s) that are returned when the expression tree associated with this object is executed.</returns>
		public Type ElementType
		{
			get
			{
				return this.NhFetchRequest.ElementType;
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
				return this.NhFetchRequest.Expression;
			}
		}

		/// <summary>
		/// Gets the NHibernate fetch request.
		/// </summary>
		/// <value>
		/// The NHibernate fetch request.
		/// </value>
		public INhFetchRequest<TQueried, TFetch> NhFetchRequest { get; private set; }

		/// <summary>
		/// Gets the query provider that is associated with this data source.
		/// </summary>
		/// <returns>The <see cref="T:System.Linq.IQueryProvider" /> that is associated with this data source.</returns>
		public IQueryProvider Provider
		{
			get
			{
				return this.NhFetchRequest.Provider;
			}
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<TQueried> GetEnumerator()
		{
			return this.NhFetchRequest.GetEnumerator();
		}

		#endregion

		#region Explicit Interface Methods

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.NhFetchRequest.GetEnumerator();
		}

		#endregion
	}
}