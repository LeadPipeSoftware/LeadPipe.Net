// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISearchQueryParser.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.QueryParsers;
using Lucene.Net.Search;

namespace LeadPipe.Net.Lucene
{
	/// <summary>
	/// Parses search queries.
	/// </summary>
	public interface ISearchQueryParser
	{
        /// <summary>
        /// Parses the query.
        /// </summary>
        /// <param name="searchQuery">The search query.</param>
        /// <param name="parser">The parser.</param>
        /// <returns></returns>
		Query ParseQuery(string searchQuery, QueryParser parser);
	}
}