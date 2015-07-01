// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchResult.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace LeadPipe.Net.Lucene
{
	/// <summary>
	/// The search result.
	/// </summary>
	public class SearchResult<TSearchData>
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchResult{TSearchData}"/> class.
        /// </summary>
		public SearchResult()
		{
			this.Results = new List<TSearchData>();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchResult{TSearchData}"/> class.
        /// </summary>
        /// <param name="results">The results.</param>
        /// <param name="totalHitCount">The total hit count.</param>
		public SearchResult(IEnumerable<TSearchData> results, int totalHitCount)
		{
			this.Results = results;
			this.TotalHitCount = totalHitCount;
		}

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
		public IEnumerable<TSearchData> Results { get; set; }

        /// <summary>
        /// Gets or sets the total hit count.
        /// </summary>
        /// <value>
        /// The total hit count.
        /// </value>
		public int TotalHitCount { get; set; }
	}
}