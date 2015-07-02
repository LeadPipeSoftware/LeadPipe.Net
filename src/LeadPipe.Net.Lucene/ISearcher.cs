// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISearcher.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Lucene.Net.Store;
using Lucene.Net.Util;

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