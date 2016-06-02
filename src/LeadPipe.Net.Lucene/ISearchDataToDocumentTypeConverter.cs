// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Documents;

namespace LeadPipe.Net.Lucene
{
    /// <summary>
    /// Converts SearchData types to Lucene Document types.
    /// </summary>
    public interface ISearchDataToDocumentTypeConverter<TSearchData> where TSearchData : IKeyed
    {
        /// <summary>
        /// Converts the specified search data to a Lucene document.
        /// </summary>
        /// <param name="searchData">The search data.</param>
        /// <returns></returns>
        Document Convert(TSearchData searchData);
    }
}