// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FetchingProvider.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Linq;

namespace LeadPipe.Net.Data.NHibernate
{
	/// <summary>
	/// An NHibernate fetching provider.
	/// </summary>
	public class FetchingProvider : IFetchingProvider
	{
		#region Public Methods and Operators

		/// <summary>
		/// Fetches the specified query.
		/// </summary>
		/// <typeparam name="TOriginating">The type of the originating.</typeparam>
		/// <typeparam name="TRelated">The type of the related.</typeparam>
		/// <param name="query">The query.</param>
		/// <param name="relatedObjectSelector">The related object selector.</param>
		/// <returns>The fetch request.</returns>
		public IFetchRequest<TOriginating, TRelated> Fetch<TOriginating, TRelated>(IQueryable<TOriginating> query, Expression<Func<TOriginating, TRelated>> relatedObjectSelector)
		{
			var fetch = EagerFetchingExtensionMethods.Fetch(query, relatedObjectSelector);
			return new FetchRequest<TOriginating, TRelated>(fetch);
		}

		/// <summary>
		/// Fetches the many.
		/// </summary>
		/// <typeparam name="TOriginating">The type of the originating.</typeparam>
		/// <typeparam name="TRelated">The type of the related.</typeparam>
		/// <param name="query">The query.</param>
		/// <param name="relatedObjectSelector">The related object selector.</param>
		/// <returns>The fetch request.</returns>
		public IFetchRequest<TOriginating, TRelated> FetchMany<TOriginating, TRelated>(IQueryable<TOriginating> query, Expression<Func<TOriginating, IEnumerable<TRelated>>> relatedObjectSelector)
		{
			var fetch = EagerFetchingExtensionMethods.FetchMany(query, relatedObjectSelector);
			return new FetchRequest<TOriginating, TRelated>(fetch);
		}

		/// <summary>
		/// Thens the fetch.
		/// </summary>
		/// <typeparam name="TQueried">The type of the queried.</typeparam>
		/// <typeparam name="TFetch">The type of the fetch.</typeparam>
		/// <typeparam name="TRelated">The type of the related.</typeparam>
		/// <param name="query">The query.</param>
		/// <param name="relatedObjectSelector">The related object selector.</param>
		/// <returns>The fetch request.</returns>
		public IFetchRequest<TQueried, TRelated> ThenFetch<TQueried, TFetch, TRelated>(IFetchRequest<TQueried, TFetch> query, Expression<Func<TFetch, TRelated>> relatedObjectSelector)
		{
			var impl = query as FetchRequest<TQueried, TFetch>;
			var fetch = impl.NhFetchRequest.ThenFetch(relatedObjectSelector);
			return new FetchRequest<TQueried, TRelated>(fetch);
		}

		/// <summary>
		/// Thens the fetch many.
		/// </summary>
		/// <typeparam name="TQueried">The type of the queried.</typeparam>
		/// <typeparam name="TFetch">The type of the fetch.</typeparam>
		/// <typeparam name="TRelated">The type of the related.</typeparam>
		/// <param name="query">The query.</param>
		/// <param name="relatedObjectSelector">The related object selector.</param>
		/// <returns>The fetch request.</returns>
		public IFetchRequest<TQueried, TRelated> ThenFetchMany<TQueried, TFetch, TRelated>(IFetchRequest<TQueried, TFetch> query, Expression<Func<TFetch, IEnumerable<TRelated>>> relatedObjectSelector)
		{
			var impl = query as FetchRequest<TQueried, TFetch>;
			var fetch = impl.NhFetchRequest.ThenFetchMany(relatedObjectSelector);
			return new FetchRequest<TQueried, TRelated>(fetch);
		}

		#endregion
	}
}