// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System.Collections.Generic;
using System.Linq;

namespace LeadPipe.Net.Lucene
{
    using Version = global::Lucene.Net.Util.Version;

    /// <summary>
    /// Updates the search index.
    /// </summary>
    public class SearchIndexUpdater<TEntity, TSearchData> : ISearchIndexUpdater<TEntity, TSearchData> where TSearchData : IKeyed, new()
    {
        private readonly IEntityToSearchDataTypeConverter<TEntity, TSearchData> entityToSearchDataTypeConverter;
        private readonly ISearchDataToDocumentTypeConverter<TSearchData> searchDataToDocumentTypeConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexUpdater{TEntity, TSearchData}"/> class.
        /// </summary>
        /// <param name="searchDataToDocumentTypeConverter">The search data to document type converter.</param>
        /// <param name="entityToSearchDataTypeConverter">The entity to search data type converter.</param>
        public SearchIndexUpdater(
            ISearchDataToDocumentTypeConverter<TSearchData> searchDataToDocumentTypeConverter,
            IEntityToSearchDataTypeConverter<TEntity, TSearchData> entityToSearchDataTypeConverter)
        {
            this.searchDataToDocumentTypeConverter = searchDataToDocumentTypeConverter;
            this.entityToSearchDataTypeConverter = entityToSearchDataTypeConverter;
        }

        /// <summary>
        /// Updates the index.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="directory">The lucene directory.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
        public virtual void UpdateIndex(Version luceneVersion, Directory directory, IndexWriter.MaxFieldLength maxFieldLength)
        {
            /*
             * You can override this method in your own updater to go fetch your search data and
             * update the index.
             */
        }

        /// <summary>
        /// Updates the index.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="directory">The lucene directory.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
        /// <param name="searchData"></param>
        public virtual void UpdateIndex(Version luceneVersion, Directory directory, IndexWriter.MaxFieldLength maxFieldLength, IEnumerable<TSearchData> searchData)
        {
            var analyzer = new StandardAnalyzer(luceneVersion);

            using (var indexWriter = new IndexWriter(directory, analyzer, maxFieldLength))
            {
                foreach (var searchDataItem in searchData)
                {
                    this.AddEntityToIndex(searchDataItem, indexWriter);
                }

                analyzer.Close();
            }
        }

        /// <summary>
        /// Updates the index.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="directory">The lucene directory.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
        /// <param name="entities"></param>
        public virtual void UpdateIndex(Version luceneVersion, Directory directory, IndexWriter.MaxFieldLength maxFieldLength,
            IEnumerable<TEntity> entities)
        {
            var searchDatas = entities.Select(entity => this.entityToSearchDataTypeConverter.Convert(entity)).ToList();

            this.UpdateIndex(luceneVersion, directory, maxFieldLength, searchDatas);
        }

        /// <summary>
        /// Deletes a single entity from the index.
        /// </summary>
        /// <param name="searchData">The search data.</param>
        /// <param name="indexWriter">The index writer.</param>
        private static void DeleteEntityFromIndex(TSearchData searchData, IndexWriter indexWriter)
        {
            var searchQuery = new TermQuery(new Term("key", searchData.Key));

            indexWriter.DeleteDocuments(searchQuery);
        }

        /// <summary>
        /// Adds an entity to the index.
        /// </summary>
        /// <param name="searchData">The search data.</param>
        /// <param name="indexWriter">The index writer.</param>
        private void AddEntityToIndex(TSearchData searchData, IndexWriter indexWriter)
        {
            DeleteEntityFromIndex(searchData, indexWriter);

            var document = this.searchDataToDocumentTypeConverter.Convert(searchData);

            indexWriter.AddDocument(document);
        }
    }
}