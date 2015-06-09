// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EagerFetch.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LeadPipe.Net.Data.NHibernate
{
	/// <summary>
	/// An NHibernate eager fetch request.
	/// </summary>
	public static class EagerFetch
	{
		#region Static Fields

		/// <summary>
		/// The fetching provider.
		/// </summary>
		public static Func<IFetchingProvider> FetchingProvider = () => new FetchingProvider();

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Fetches the specified query.
		/// </summary>
		/// <typeparam name="TOriginating">The type of the originating.</typeparam>
		/// <typeparam name="TRelated">The type of the related.</typeparam>
		/// <param name="query">The query.</param>
		/// <param name="relatedObjectSelector">The related object selector.</param>
		/// <returns>The fetch request.</returns>
		public static IFetchRequest<TOriginating, TRelated> Fetch<TOriginating, TRelated>(this IQueryable<TOriginating> query, Expression<Func<TOriginating, TRelated>> relatedObjectSelector)
		{
			return FetchingProvider()
				.Fetch(query, relatedObjectSelector);
		}

		/// <summary>
		/// Fetches the many.
		/// </summary>
		/// <typeparam name="TOriginating">The type of the originating.</typeparam>
		/// <typeparam name="TRelated">The type of the related.</typeparam>
		/// <param name="query">The query.</param>
		/// <param name="relatedObjectSelector">The related object selector.</param>
		/// <returns>The fetch request.</returns>
		public static IFetchRequest<TOriginating, TRelated> FetchMany<TOriginating, TRelated>(this IQueryable<TOriginating> query, Expression<Func<TOriginating, IEnumerable<TRelated>>> relatedObjectSelector)
		{
			return FetchingProvider()
				.FetchMany(query, relatedObjectSelector);
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
		public static IFetchRequest<TQueried, TRelated> ThenFetch<TQueried, TFetch, TRelated>(this IFetchRequest<TQueried, TFetch> query, Expression<Func<TFetch, TRelated>> relatedObjectSelector)
		{
			return FetchingProvider()
				.ThenFetch(query, relatedObjectSelector);
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
		public static IFetchRequest<TQueried, TRelated> ThenFetchMany<TQueried, TFetch, TRelated>(this IFetchRequest<TQueried, TFetch> query, Expression<Func<TFetch, IEnumerable<TRelated>>> relatedObjectSelector)
		{
			return FetchingProvider()
				.ThenFetchMany(query, relatedObjectSelector);
		}

		#endregion
	}
}