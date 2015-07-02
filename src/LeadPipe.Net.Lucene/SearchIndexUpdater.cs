// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchIndexUpdater.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;

namespace LeadPipe.Net.Lucene
{
    using Version = global::Lucene.Net.Util.Version;

    /// <summary>
    /// Updates the search index.
    /// </summary>
    public class SearchIndexUpdater<TEntity, TSearchData> : ISearchIndexUpdater<TEntity, TSearchData> where TSearchData : IKeyed, new()
    {
        private readonly ISearchDataToDocumentTypeConverter<TSearchData> searchDataToDocumentTypeConverter;

        private readonly IEntityToSearchDataTypeConverter<TEntity, TSearchData> entityToSearchDataTypeConverter;

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
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
        public virtual void UpdateIndex(Version luceneVersion, FSDirectory fsDirectory, IndexWriter.MaxFieldLength maxFieldLength)
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
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
        /// <param name="searchData"></param>
        public virtual void UpdateIndex(Version luceneVersion, FSDirectory fsDirectory, IndexWriter.MaxFieldLength maxFieldLength, IEnumerable<TSearchData> searchData)
        {
            var analyzer = new StandardAnalyzer(luceneVersion);

            using (var indexWriter = new IndexWriter(fsDirectory, analyzer, maxFieldLength))
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
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
        /// <param name="entities"></param>
        public virtual void UpdateIndex(Version luceneVersion, FSDirectory fsDirectory, IndexWriter.MaxFieldLength maxFieldLength,
            IEnumerable<TEntity> entities)
        {
            var searchDatas = entities.Select(entity => this.entityToSearchDataTypeConverter.Convert(entity)).ToList();

            this.UpdateIndex(luceneVersion, fsDirectory, maxFieldLength, searchDatas);
        }

        /// <summary>
        /// Adds an entity to the index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="searchData">The search data.</param>
        /// <param name="indexWriter">The index writer.</param>
        private void AddEntityToIndex(TSearchData searchData, IndexWriter indexWriter)
        {
            DeleteEntityFromIndex(searchData, indexWriter);

            var document = this.searchDataToDocumentTypeConverter.Convert(searchData);

            indexWriter.AddDocument(document);
        }

        /// <summary>
        /// Deletes a single entity from the index.
        /// </summary>
        /// <param name="searchData">The search data.</param>
        /// <param name="indexWriter">The index writer.</param>
        private static void DeleteEntityFromIndex(TSearchData searchData, IndexWriter indexWriter)
        {
            var searchQuery = new TermQuery(new Term("Key", searchData.Key));

            indexWriter.DeleteDocuments(searchQuery);
        }
    }
}