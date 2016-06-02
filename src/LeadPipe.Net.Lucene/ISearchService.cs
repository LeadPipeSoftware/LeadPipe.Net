// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace LeadPipe.Net.Lucene
{
    /// <summary>
    /// Provides searching services.
    /// </summary>
    public interface ISearchService<TEntity, TSearchData> where TSearchData : IKeyed, new()
    {
        /// <summary>
        /// Gets or sets the hit limit.
        /// </summary>
        /// <value>
        /// The hit limit.
        /// </value>
        int HitLimit { get; set; }

        /// <summary>
        /// Clears the index.
        /// </summary>
        void ClearIndex();

        /// <summary>
        /// Clears the index.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void ClearIndex(string id);

        /// <summary>
        /// Explains the score for a result.
        /// </summary>
        /// <param name="resultId">The result identifier.</param>
        /// <returns></returns>
        string Explain(int resultId);

        /// <summary>
        /// Optimizes this instance.
        /// </summary>
        void Optimize();

        /// <summary>
        /// Searches the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        SearchResult<TSearchData> Search(string input);

        /// <summary>
        /// Sets the default search fields.
        /// </summary>
        /// <param name="defaultSearchFields">The default search fields.</param>
        void SetDefaultSearchFields(IEnumerable<string> defaultSearchFields);

        /// <summary>
        /// Sets the search fields.
        /// </summary>
        /// <param name="searchFields">The search fields.</param>
        void SetSearchFields(IEnumerable<string> searchFields);

        /// <summary>
        /// Simples the search.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        SearchResult<TSearchData> SimpleSearch(string input);

        /// <summary>
        /// Updates the index.
        /// </summary>
        void UpdateIndex();

        /// <summary>
        /// Updates the index.
        /// </summary>
        /// <param name="searchData">The search data.</param>
        void UpdateIndex(IEnumerable<TSearchData> searchData);

        /// <summary>
        /// Updates the index.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void UpdateIndex(IEnumerable<TEntity> entities);
    }
}