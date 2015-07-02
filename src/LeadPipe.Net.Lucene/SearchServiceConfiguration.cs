// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchServiceConfiguration.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using LeadPipe.Net.Extensions;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Directory = System.IO.Directory;

namespace LeadPipe.Net.Lucene
{
	/// <summary>
	/// The search service configuration.
	/// </summary>
	public class SearchServiceConfiguration : ISearchServiceConfiguration
	{
	    private Version luceneVersion;
	    private IndexWriter.MaxFieldLength maxFieldLength;
	    private string indexFolder;
	    private FSDirectory fsDirectory;
	    private string writeLockSemaphoreFileName;
	    private int hitLimit;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchServiceConfiguration" /> class.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="maxFieldLength">Maximum length of the field.</param>
        /// <param name="indexFolder">The index folder.</param>
        /// <param name="writeLockSemaphoreFileName">Name of the write lock semaphore file.</param>
        /// <param name="hitLimit">The hit limit.</param>
	    public SearchServiceConfiguration(
            Version luceneVersion,
            IndexWriter.MaxFieldLength maxFieldLength,
            string indexFolder,
            string writeLockSemaphoreFileName,
            int hitLimit)
	    {
            this.luceneVersion = luceneVersion.IsNull() ? Version.LUCENE_30 : luceneVersion;

            this.maxFieldLength = maxFieldLength.IsNull() ? IndexWriter.MaxFieldLength.UNLIMITED : maxFieldLength;

            this.indexFolder = indexFolder.IsNullOrEmpty() ? @"C:\SearchIndex\" : indexFolder;

            this.writeLockSemaphoreFileName = writeLockSemaphoreFileName.IsNullOrEmpty() ? Path.Combine(this.indexFolder, "write.lock") : writeLockSemaphoreFileName;

            this.hitLimit = hitLimit.Equals(EqualityComparer<int>.Default.Equals(hitLimit, default(int))) ? 1000 : hitLimit;

            this.fsDirectory = this.GetDirectory();
	    }

	    /// <summary>
	    /// Gets the Lucene version.
	    /// </summary>
	    /// <value>
	    /// The lucene version.
	    /// </value>
	    public virtual Version LuceneVersion
	    {
	        get { return luceneVersion; }
	        protected set { luceneVersion = value; }
	    }

	    /// <summary>
	    /// Gets the maximum length of the field.
	    /// </summary>
	    /// <value>
	    /// The maximum length of the field.
	    /// </value>
	    public virtual IndexWriter.MaxFieldLength MaxFieldLength
	    {
	        get { return maxFieldLength; }
	        protected set { maxFieldLength = value; }
	    }

	    /// <summary>
	    /// Gets the index folder.
	    /// </summary>
	    /// <value>
	    /// The index folder.
	    /// </value>
	    public virtual string IndexFolder
	    {
	        get { return indexFolder; }
	        protected set { indexFolder = value; }
	    }

	    /// <summary>
	    /// Gets the fs directory.
	    /// </summary>
	    /// <value>
	    /// The fs directory.
	    /// </value>
	    public virtual FSDirectory FsDirectory
	    {
	        get { return fsDirectory; }
	        protected set { fsDirectory = value; }
	    }

	    /// <summary>
	    /// Gets the write lock semaphore file name.
	    /// </summary>
	    /// <value>
	    /// The write lock semaphore file name.
	    /// </value>
	    public virtual string WriteLockSemaphoreFileName
	    {
	        get { return writeLockSemaphoreFileName; }
	        protected set { writeLockSemaphoreFileName = value; }
	    }

	    /// <summary>
	    /// Gets the hit limit.
	    /// </summary>
	    /// <value>
	    /// The hit limit.
	    /// </value>
	    public virtual int HitLimit
	    {
	        get { return hitLimit; }
	        set { hitLimit = value; }
	    }

	    /// <summary>
	    /// Gets the directory.
	    /// </summary>
	    /// <returns></returns>
	    protected virtual FSDirectory GetDirectory()
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

            if (File.Exists(this.WriteLockSemaphoreFileName))
            {
                File.Delete(this.WriteLockSemaphoreFileName);
            }

            return this.FsDirectory;
        }
	}
}