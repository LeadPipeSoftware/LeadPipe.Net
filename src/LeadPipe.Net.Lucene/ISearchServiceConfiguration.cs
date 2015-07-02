// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISearchServiceConfiguration.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace LeadPipe.Net.Lucene
{
    /// <summary>
    /// The search service configuration.
    /// </summary>
    public interface ISearchServiceConfiguration
    {
        /// <summary>
        /// Gets the lucene version.
        /// </summary>
        /// <value>
        /// The lucene version.
        /// </value>
        Version LuceneVersion { get; }

        /// <summary>
        /// Gets the maximum length of the field.
        /// </summary>
        /// <value>
        /// The maximum length of the field.
        /// </value>
        IndexWriter.MaxFieldLength MaxFieldLength { get; }

        /// <summary>
        /// Gets the index folder.
        /// </summary>
        /// <value>
        /// The index folder.
        /// </value>
        string IndexFolder { get; }

        /// <summary>
        /// Gets the fs directory.
        /// </summary>
        /// <value>
        /// The fs directory.
        /// </value>
        FSDirectory FsDirectory { get; }

        /// <summary>
        /// Gets the write lock semaphore file name.
        /// </summary>
        /// <value>
        /// The write lock semaphore file name.
        /// </value>
        string WriteLockSemaphoreFileName { get; }

        /// <summary>
        /// Gets the hit limit.
        /// </summary>
        /// <value>
        /// The hit limit.
        /// </value>
        int HitLimit { get; set; }
    }
}