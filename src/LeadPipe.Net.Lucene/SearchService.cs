// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchService.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using Lucene.Net.Index;
using Lucene.Net.Store;

namespace LeadPipe.Net.Lucene
{
	using Directory = System.IO.Directory;
	using Version = global::Lucene.Net.Util.Version;

	/// <summary>
	/// The search service.
	/// </summary>
	public class SearchService<TEntity, TSearchData> : ISearchService<TEntity, TSearchData> where TSearchData : new()
	{
		private readonly string indexFolder;

		private readonly Version luceneVersion;

		private readonly global::Lucene.Net.Index.IndexWriter.MaxFieldLength maxFieldLength;

		private readonly ISearchIndexClearer searchIndexClearer;

		private readonly ISearchIndexOptimizer searchIndexOptimizer;

		private readonly ISearchIndexUpdater<TEntity, TSearchData> searchIndexUpdater;

		private readonly ISearchScoreExplainer searchScoreExplainer;

		private readonly ISearcher<TSearchData> searcher;

		private readonly string writeLockSemaphoreFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchService{TEntity, TSearchData}"/> class.
        /// </summary>
        /// <param name="searchIndexClearer">The search index clearer.</param>
        /// <param name="searchIndexOptimizer">The search index optimizer.</param>
        /// <param name="searcher">The searcher.</param>
        /// <param name="searchIndexUpdater">The search index updater.</param>
        /// <param name="searchScoreExplainer">The search score explainer.</param>
		public SearchService(
			ISearchIndexClearer searchIndexClearer, 
			ISearchIndexOptimizer searchIndexOptimizer, 
			ISearcher<TSearchData> searcher, 
			ISearchIndexUpdater<TEntity, TSearchData> searchIndexUpdater, 
			ISearchScoreExplainer searchScoreExplainer)
		{
			this.searchIndexClearer = searchIndexClearer;
			this.searchIndexOptimizer = searchIndexOptimizer;
			this.searcher = searcher;
			this.searchIndexUpdater = searchIndexUpdater;
			this.searchScoreExplainer = searchScoreExplainer;

			this.luceneVersion = Version.LUCENE_30;
			this.maxFieldLength = global::Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED;

			this.indexFolder = @"C:\SearchIndex\";

			this.FsDirectory = this.GetDirectory();

			this.writeLockSemaphoreFile = Path.Combine(this.IndexFolder, "write.lock");

			this.HitLimit = 1000;
		}

        /// <summary>
        /// Gets or sets the fs directory.
        /// </summary>
        /// <value>
        /// The fs directory.
        /// </value>
		public virtual FSDirectory FsDirectory { get; protected set; }

        /// <summary>
        /// Gets or sets the hit limit.
        /// </summary>
        /// <value>
        /// The hit limit.
        /// </value>
		public virtual int HitLimit { get; set; }

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
				return this.indexFolder;
			}
		}

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
				return this.luceneVersion;
			}
		}

        /// <summary>
        /// Gets the maximum length of the field.
        /// </summary>
        /// <value>
        /// The maximum length of the field.
        /// </value>
		public virtual global::Lucene.Net.Index.IndexWriter.MaxFieldLength MaxFieldLength
		{
			get
			{
				return this.maxFieldLength;
			}
		}

        /// <summary>
        /// Clears the index.
        /// </summary>
		public virtual void ClearIndex()
		{
			this.searchIndexClearer.ClearIndex(this.LuceneVersion, this.FsDirectory, this.MaxFieldLength);
		}

		////public void ClearIndex(string id)
		////{
		////    this.searchIndexClearer.ClearIndex(id, this.LuceneVersion, this.FsDirectory, this.MaxFieldLength);
		////}

        /// <summary>
        /// Explains the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="resultId">The result identifier.</param>
        /// <returns></returns>
		public virtual string Explain(string input, int resultId)
		{
			return this.searchScoreExplainer.Explain(this.LuceneVersion, this.FsDirectory, input, resultId);
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
			return this.searcher.Search(this.LuceneVersion, this.FsDirectory, this.HitLimit, input);
		}

        /// <summary>
        /// Sets the default search fields.
        /// </summary>
        /// <param name="defaultSearchFields">The default search fields.</param>
	    public void SetDefaultSearchFields(IEnumerable<string> defaultSearchFields)
	    {
	        this.searcher.SetDefaultSearchFields(defaultSearchFields);
	    }

        /// <summary>
        /// Sets the search fields.
        /// </summary>
        /// <param name="searchFields">The search fields.</param>
	    public void SetSearchFields(IEnumerable<string> searchFields)
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
			return this.searcher.SimpleSearch(this.LuceneVersion, this.FsDirectory, this.HitLimit, input);
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

        /// <summary>
        /// Gets the directory.
        /// </summary>
        /// <returns></returns>
		private FSDirectory GetDirectory()
		{
			if (!Directory.Exists(this.IndexFolder))
			{
				Directory.CreateDirectory(this.IndexFolder);
			}

			if (this.FsDirectory == null)
			{
				this.FsDirectory = FSDirectory.Open(new DirectoryInfo(this.IndexFolder));
			}

			if (IndexWriter.IsLocked(this.FsDirectory))
			{
				IndexWriter.Unlock(this.FsDirectory);
			}

			if (File.Exists(this.writeLockSemaphoreFile))
			{
				File.Delete(this.writeLockSemaphoreFile);
			}

			return this.FsDirectory;
		}
	}
}