// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISearchScoreExplainer.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
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
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="input">The input.</param>
        /// <param name="resultId">The result identifier.</param>
        /// <returns></returns>
		string Explain(Version luceneVersion, FSDirectory fsDirectory, string input, int resultId);
	}
}