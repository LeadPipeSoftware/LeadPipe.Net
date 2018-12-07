// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using Lucene.Net.Index;
using Lucene.Net.Util;
using Lucene.Net.Store;
using System.Collections.Generic;
using System.IO;

using IoDirectory = System.IO.Directory;
using LuceneDirectory = Lucene.Net.Store.Directory;


namespace LeadPipe.Net.Lucene
{
    /// <summary>
    /// The search service configuration.
    /// </summary>
    public class SearchServiceConfiguration : ISearchServiceConfiguration
    {
        private LuceneDirectory directory;
        private int hitLimit;
        private string indexFolder;
        private Version luceneVersion;
        private IndexWriter.MaxFieldLength maxFieldLength;
        private string writeLockSemaphoreFileName;

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

            this.directory = this.GetDirectory();
        }

        /// <summary>
        /// Gets the lucene directory.
        /// </summary>
        /// <value>
        /// The lucene directory.
        /// </value>
        public virtual LuceneDirectory Directory
        {
            get { return directory; }
            protected set { directory = value; }
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
        /// Gets the directory.
        /// </summary>
        /// <returns></returns>
        protected virtual LuceneDirectory GetDirectory()
        {
            if (!IoDirectory.Exists(this.IndexFolder))
            {
                IoDirectory.CreateDirectory(this.IndexFolder);
            }

            if (this.Directory == null)
            {
                this.Directory = FSDirectory.Open(new DirectoryInfo(this.IndexFolder));
            }

            if (IndexWriter.IsLocked(this.Directory))
            {
                IndexWriter.Unlock(this.Directory);
            }

            if (File.Exists(this.WriteLockSemaphoreFileName))
            {
                File.Delete(this.WriteLockSemaphoreFileName);
            }

            return this.Directory;
        }
    }
}