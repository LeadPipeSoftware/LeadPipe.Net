////// --------------------------------------------------------------------------------------------------------------------
////// <copyright file="IFetchingProvider.cs" company="Lead Pipe Software">
//////   Copyright (c) Lead Pipe Software All rights reserved.
////// </copyright>
////// --------------------------------------------------------------------------------------------------------------------

////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Linq.Expressions;

////namespace LeadPipe.Net.Data
////{
////    /// <summary>
////    /// A fetching provider.
////    /// </summary>
////    public interface IFetchingProvider
////    {
////        /// <summary>
////        /// Fetches the specified query.
////        /// </summary>
////        /// <typeparam name="TOriginating">The type of the originating.</typeparam>
////        /// <typeparam name="TRelated">The type of the related.</typeparam>
////        /// <param name="query">The query.</param>
////        /// <param name="relatedObjectSelector">The related object selector.</param>
////        /// <returns>The fetch request.</returns>
////        IFetchRequest<TOriginating, TRelated> Fetch<TOriginating, TRelated>(IQueryable<TOriginating> query, Expression<Func<TOriginating, TRelated>> relatedObjectSelector);

////        /// <summary>
////        /// Fetches the many.
////        /// </summary>
////        /// <typeparam name="TOriginating">The type of the originating.</typeparam>
////        /// <typeparam name="TRelated">The type of the related.</typeparam>
////        /// <param name="query">The query.</param>
////        /// <param name="relatedObjectSelector">The related object selector.</param>
////        /// <returns>The fetch request.</returns>
////        IFetchRequest<TOriginating, TRelated> FetchMany<TOriginating, TRelated>(IQueryable<TOriginating> query, Expression<Func<TOriginating, IEnumerable<TRelated>>> relatedObjectSelector);

////        /// <summary>
////        /// Thens the fetch.
////        /// </summary>
////        /// <typeparam name="TQueried">The type of the queried.</typeparam>
////        /// <typeparam name="TFetch">The type of the fetch.</typeparam>
////        /// <typeparam name="TRelated">The type of the related.</typeparam>
////        /// <param name="query">The query.</param>
////        /// <param name="relatedObjectSelector">The related object selector.</param>
////        /// <returns>The fetch request.</returns>
////        IFetchRequest<TQueried, TRelated> ThenFetch<TQueried, TFetch, TRelated>(IFetchRequest<TQueried, TFetch> query, Expression<Func<TFetch, TRelated>> relatedObjectSelector);

////        /// <summary>
////        /// Thens the fetch many.
////        /// </summary>
////        /// <typeparam name="TQueried">The type of the queried.</typeparam>
////        /// <typeparam name="TFetch">The type of the fetch.</typeparam>
////        /// <typeparam name="TRelated">The type of the related.</typeparam>
////        /// <param name="query">The query.</param>
////        /// <param name="relatedObjectSelector">The related object selector.</param>
////        /// <returns>The fetch request.</returns>
////        IFetchRequest<TQueried, TRelated> ThenFetchMany<TQueried, TFetch, TRelated>(IFetchRequest<TQueried, TFetch> query, Expression<Func<TFetch, IEnumerable<TRelated>>> relatedObjectSelector);
////    }
////}
