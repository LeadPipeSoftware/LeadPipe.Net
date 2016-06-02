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
    /// Clears the search index.
    /// </summary>
    public interface ISearchIndexClearer
    {
        /// <summary>
        /// Clears the entire index.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
        void ClearIndex(Version luceneVersion, FSDirectory fsDirectory, IndexWriter.MaxFieldLength maxFieldLength);

        /// <summary>
        /// Clears an item the index.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
        void ClearIndex(string id, Version luceneVersion, FSDirectory fsDirectory, IndexWriter.MaxFieldLength maxFieldLength);
    }
}