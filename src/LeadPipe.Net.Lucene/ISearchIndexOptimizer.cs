// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISearchIndexOptimizer.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace LeadPipe.Net.Lucene
{
	/// <summary>
	/// Optimizes the search index.
	/// </summary>
	public interface ISearchIndexOptimizer
	{
        /// <summary>
        /// Optimizes the Lucene index.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
		void Optimize(Version luceneVersion, FSDirectory fsDirectory, IndexWriter.MaxFieldLength maxFieldLength);
	}
}