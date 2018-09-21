// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;
using System.Collections.Generic;

namespace LeadPipe.Net.Lucene
{
    /// <summary>
    /// Updates the search index.
    /// </summary>
    public interface ISearchIndexUpdater<TEntity, TSearchData> where TSearchData : IKeyed, new()
    {
        /// <summary>
        /// Updates the index.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="directory">The lucene directory.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
        void UpdateIndex(Version luceneVersion, Directory directory, IndexWriter.MaxFieldLength maxFieldLength);

        /// <summary>
        /// Updates the index.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="directory">The lucene directory.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
        /// <param name="searchData">The search data.</param>
        void UpdateIndex(Version luceneVersion, Directory directory, IndexWriter.MaxFieldLength maxFieldLength, IEnumerable<TSearchData> searchData);

        /// <summary>
        /// Updates the index.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="directory">The lucene directory.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
        /// <param name="entities">The entities.</param>
        void UpdateIndex(Version luceneVersion, Directory directory, IndexWriter.MaxFieldLength maxFieldLength, IEnumerable<TEntity> entities);
    }
}