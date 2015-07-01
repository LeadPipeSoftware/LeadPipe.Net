// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISearchDataToDocumentTypeConverter.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Documents;

namespace LeadPipe.Net.Lucene
{
	/// <summary>
	/// Converts SearchData types to Lucene Document types.
	/// </summary>
	public interface ISearchDataToDocumentTypeConverter<TSearchData>
	{
        /// <summary>
        /// Converts the specified search data to a Lucene document.
        /// </summary>
        /// <param name="searchData">The search data.</param>
        /// <returns></returns>
		Document Convert(TSearchData searchData);
	}
}