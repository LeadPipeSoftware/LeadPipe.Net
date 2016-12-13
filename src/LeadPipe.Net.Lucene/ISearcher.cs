// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Store;
using Lucene.Net.Util;
using System.Collections.Generic;

namespace LeadPipe.Net.Lucene
{
    /// <summary>
    /// Searches the index.
    /// </summary>
    public interface ISearcher<TSearchData> where TSearchData : IKeyed, new()
    {
        /// <summary>
        /// Searches Lucene.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="hitLimit">The hit limit.</param>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        SearchResult<TSearchData> Search(Version luceneVersion, FSDirectory fsDirectory, int hitLimit, string input);

        /// <summary>
        /// Sets the default search fields.
        /// </summary>
        /// <param name="searchFields">The default search fields.</param>
        void SetDefaultSearchFields(IEnumerable<string> searchFields);

        /// <summary>
        /// Sets the search fields.
        /// </summary>
        /// <param name="searchFields">The search fields.</param>
        void SetSearchFields(IEnumerable<string> searchFields);

        /// <summary>
        /// Performs a simple search.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="hitLimit">The hit limit.</param>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        SearchResult<TSearchData> SimpleSearch(Version luceneVersion, FSDirectory fsDirectory, int hitLimit, string input);
    }
}