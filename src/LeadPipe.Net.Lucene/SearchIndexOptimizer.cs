// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace LeadPipe.Net.Lucene
{
    /// <summary>
    /// Optimizes the search index.
    /// </summary>
    public class SearchIndexOptimizer : ISearchIndexOptimizer
    {
        /// <summary>
        /// Optimizes the Lucene index.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="directory">The lucene directory.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
        public virtual void Optimize(Version luceneVersion, Directory directory, IndexWriter.MaxFieldLength maxFieldLength)
        {
            var analyzer = new StandardAnalyzer(luceneVersion);

            using (var indexWriter = new IndexWriter(directory, analyzer, maxFieldLength))
            {
                analyzer.Close();

                indexWriter.Optimize();
            }
        }
    }
}