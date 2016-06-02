// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Index;
using Lucene.Net.Store;
using System.Collections.Generic;

namespace LeadPipe.Net.Lucene
{
    using Version = global::Lucene.Net.Util.Version;

    /// <summary>
    /// The search service.
    /// </summary>
    public class SearchService<TEntity, TSearchData> : ISearchService<TEntity, TSearchData> where TSearchData : IKeyed, new()
    {
        private readonly ISearchServiceConfiguration configuration;

        private readonly ISearcher<TSearchData> searcher;
        private readonly ISearchIndexClearer searchIndexClearer;

        private readonly ISearchIndexOptimizer searchIndexOptimizer;

        private readonly ISearchIndexUpdater<TEntity, TSearchData> searchIndexUpdater;

        private readonly ISearchScoreExplainer searchScoreExplainer;
        private readonly string writeLockSemaphoreFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchService{TEntity, TSearchData}" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="searchIndexClearer">The search index clearer.</param>
        /// <param name="searchIndexOptimizer">The search index optimizer.</param>
        /// <param name="searcher">The searcher.</param>
        /// <param name="searchIndexUpdater">The search index updater.</param>
        /// <param name="searchScoreExplainer">The search score explainer.</param>
        public SearchService(
            ISearchServiceConfiguration configuration,
            ISearchIndexClearer searchIndexClearer,
            ISearchIndexOptimizer searchIndexOptimizer,
            ISearcher<TSearchData> searcher,
            ISearchIndexUpdater<TEntity, TSearchData> searchIndexUpdater,
            ISearchScoreExplainer searchScoreExplainer)
        {
            this.configuration = configuration;
            this.searchIndexClearer = searchIndexClearer;
            this.searchIndexOptimizer = searchIndexOptimizer;
            this.searcher = searcher;
            this.searchIndexUpdater = searchIndexUpdater;
            this.searchScoreExplainer = searchScoreExplainer;
        }

        /// <summary>
        /// Gets or sets the Lucene file system directory.
        /// </summary>
        /// <value>
        /// The Lucene file system directory.
        /// </value>
        public virtual FSDirectory FsDirectory
        {
            get { return this.configuration.FsDirectory; }
        }

        /// <summary>
        /// Gets or sets the hit limit.
        /// </summary>
        /// <value>
        /// The hit limit.
        /// </value>
        public virtual int HitLimit
        {
            get { return this.configuration.HitLimit; }
            set { this.configuration.HitLimit = value; }
        }

        /// <summary>
        /// Gets the index folder.
        /// </summary>
        /// <value>
        /// The index folder.
        /// </value>
        public virtual string IndexFolder
        {
            get
            {
                return this.configuration.IndexFolder;
            }
        }

        /// <summary>
        /// Gets or sets the last query input.
        /// </summary>
        /// <value>
        /// The last query input.
        /// </value>
        public virtual string LastInput { get; protected set; }

        /// <summary>
        /// Gets or sets the last search result.
        /// </summary>
        /// <value>
        /// The last search result.
        /// </value>
        public virtual SearchResult<TSearchData> LastSearchResult { get; protected set; }

        /// <summary>
        /// Gets the lucene version.
        /// </summary>
        /// <value>
        /// The lucene version.
        /// </value>
        public Version LuceneVersion
        {
            get
            {
                return this.configuration.LuceneVersion;
            }
        }

        /// <summary>
        /// Gets the maximum length of the field.
        /// </summary>
        /// <value>
        /// The maximum length of the field.
        /// </value>
        public virtual IndexWriter.MaxFieldLength MaxFieldLength
        {
            get
            {
                return this.configuration.MaxFieldLength;
            }
        }

        /// <summary>
        /// Clears the index.
        /// </summary>
        public virtual void ClearIndex()
        {
            this.searchIndexClearer.ClearIndex(this.LuceneVersion, this.FsDirectory, this.MaxFieldLength);
        }

        /// <summary>
        /// Clears the index.
        /// </summary>
        /// <param name="key">The key.</param>
        public virtual void ClearIndex(string key)
        {
            this.searchIndexClearer.ClearIndex(key, this.LuceneVersion, this.FsDirectory, this.MaxFieldLength);
        }

        /// <summary>
        /// Explains the specified input.
        /// </summary>
        /// <param name="resultId">The result identifier.</param>
        /// <returns></returns>
        public virtual string Explain(int resultId)
        {
            return this.searchScoreExplainer.Explain(this.LuceneVersion, this.FsDirectory, this.LastInput, resultId);
        }

        /// <summary>
        /// Optimizes this instance.
        /// </summary>
        public virtual void Optimize()
        {
            this.searchIndexOptimizer.Optimize(this.LuceneVersion, this.FsDirectory, this.MaxFieldLength);
        }

        /// <summary>
        /// Searches the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public virtual SearchResult<TSearchData> Search(string input)
        {
            this.LastInput = input;

            this.LastSearchResult = this.searcher.Search(this.LuceneVersion, this.FsDirectory, this.HitLimit, input);

            return this.LastSearchResult;
        }

        /// <summary>
        /// Sets the default search fields.
        /// </summary>
        /// <param name="defaultSearchFields">The default search fields.</param>
        public virtual void SetDefaultSearchFields(IEnumerable<string> defaultSearchFields)
        {
            this.searcher.SetDefaultSearchFields(defaultSearchFields);
        }

        /// <summary>
        /// Sets the search fields.
        /// </summary>
        /// <param name="searchFields">The search fields.</param>
        public virtual void SetSearchFields(IEnumerable<string> searchFields)
        {
            this.searcher.SetSearchFields(searchFields);
        }

        /// <summary>
        /// Simples the search.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public virtual SearchResult<TSearchData> SimpleSearch(string input)
        {
            this.LastInput = input;

            this.LastSearchResult = this.searcher.SimpleSearch(this.LuceneVersion, this.FsDirectory, this.HitLimit, input);

            return this.LastSearchResult;
        }

        /// <summary>
        /// Updates the index.
        /// </summary>
        public virtual void UpdateIndex()
        {
            this.searchIndexUpdater.UpdateIndex(this.LuceneVersion, this.FsDirectory, this.MaxFieldLength);
        }

        /// <summary>
        /// Updates the index.
        /// </summary>
        /// <param name="searchData"></param>
        public virtual void UpdateIndex(IEnumerable<TSearchData> searchData)
        {
            this.searchIndexUpdater.UpdateIndex(this.LuceneVersion, this.FsDirectory, this.MaxFieldLength, searchData);
        }

        /// <summary>
        /// Updates the index.
        /// </summary>
        /// <param name="entities"></param>
        public virtual void UpdateIndex(IEnumerable<TEntity> entities)
        {
            this.searchIndexUpdater.UpdateIndex(this.LuceneVersion, this.FsDirectory, this.MaxFieldLength, entities);
        }
    }
}