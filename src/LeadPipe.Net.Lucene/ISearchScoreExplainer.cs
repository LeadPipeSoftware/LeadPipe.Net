// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Store;
using Lucene.Net.Util;

namespace LeadPipe.Net.Lucene
{
    /// <summary>
    /// Explains search scores.
    /// </summary>
    public interface ISearchScoreExplainer
    {
        /// <summary>
        /// Explains the search score.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="directory">The lucene directory.</param>
        /// <param name="input">The input.</param>
        /// <param name="resultId">The result identifier.</param>
        /// <returns></returns>
        string Explain(Version luceneVersion, Directory directory, string input, int resultId);
    }
}