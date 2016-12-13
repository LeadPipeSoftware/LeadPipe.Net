// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
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