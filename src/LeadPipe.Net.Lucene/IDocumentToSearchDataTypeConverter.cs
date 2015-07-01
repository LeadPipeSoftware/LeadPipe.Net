// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentToSearchDataTypeConverter.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Documents;

namespace LeadPipe.Net.Lucene
{
	/// <summary>
	/// Converts Lucene Document types to SearchData types.
	/// </summary>
	public interface IDocumentToSearchDataTypeConverter<TSearchData> where TSearchData : new()
	{
        /// <summary>
        /// Converts the specified document to search data.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="document">The document.</param>
        /// <param name="score">The score.</param>
        /// <param name="topScore">The top score.</param>
        /// <returns></returns>
		TSearchData Convert(int documentId, Document document, float score, float topScore);
	}
}