// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchIndexUpdater.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;

namespace LeadPipe.Net.Lucene
{
    using Version = global::Lucene.Net.Util.Version;

    /// <summary>
    /// Updates the search index.
    /// </summary>
    public class SearchIndexUpdater<TEntity, TSearchData> : ISearchIndexUpdater<TEntity, TSearchData> where TSearchData : new()
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
            var searchData = new List<TSearchData>();

            /*
                 * Here is where you would fetch your entities and project them into SearchData. Maybe
                 * a SQL query off a view. Whatever works for you. The following line is commented out
                 * so that the solution will compile.
                 */

            ////this.UpdateIndex(luceneVersion, fsDirectory, maxFieldLength, searchData);
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
            var searchDatas = new List<TSearchData>();

            foreach (var entity in entities)
            {
                var searchData = this.entityToSearchDataTypeConverter.Convert(entity);

                searchDatas.Add(searchData);
            }

            this.UpdateIndex(luceneVersion, fsDirectory, maxFieldLength, searchDatas);
        }

        /// <summary>
        /// Adds the index of the entity to.
        /// </summary>
        /// <param name="searchData">The search data.</param>
        /// <param name="indexWriter">The index writer.</param>
        private void AddEntityToIndex(TSearchData searchData, IndexWriter indexWriter)
        {
            //this.DeleteEntityFromIndex(searchData, indexWriter);

            var document = this.searchDataToDocumentTypeConverter.Convert(searchData);

            indexWriter.AddDocument(document);
        }

        //private void DeleteEntityFromIndex(TSearchData searchData, IndexWriter indexWriter)
        //{
        //    var searchQuery = new TermQuery(new Term(SearchFields.Id, searchData.Id));

        //    indexWriter.DeleteDocuments(searchQuery);
        //}
    }
}