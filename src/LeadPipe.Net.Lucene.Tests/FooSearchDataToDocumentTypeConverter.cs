// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Documents;

namespace LeadPipe.Net.Lucene.Tests
{
    /// <summary>
    /// Converts FooSearchData types to Lucene Document types.
    /// </summary>
    public class FooSearchDataToDocumentTypeConverter : ISearchDataToDocumentTypeConverter<FooSearchData>
    {
        /// <summary>
        /// Converts the specified search data to a Lucene document.
        /// </summary>
        /// <param name="searchData">The search data.</param>
        /// <returns>The converted document.</returns>
        public Document Convert(FooSearchData searchData)
        {
            /*
             * NOTE: These are the values for indexing.
             *
             *       ANALYZED
             *       Index the tokens produced by running the field's value through an analyzer. This is useful for
             *       common text.
             *
             *       ANALYZED_NO_NORMS
             *       Expert: Index the tokens produced by running the field's value through an Analyzer, and also
             *       separately disable the storing of norms. See NOT_ANALYZED_NO_NORMS for what norms are and why you
             *       may want to disable them.
             *
             *       NO
             *       Do not index the field value. Thus the field cannot be searched, but one can still access the
             *       contents provided it is stored.
             *
             *       NOT_ANALYZED
             *       Index the field's value without using an Analyzer, so it can be searched. As no analyzer is used
             *       the value will be stored as a single term. This is useful for unique Ids like product numbers.
             *
             *       NOT_ANALYZED_NO_NORMS
             *       Expert: Index the field's value without an Analyzer, and also disable the storing of norms. Note
             *       that you can also separately enable/disable norms. No norms means that index-time field and
             *       document boosting and field length normalization are disabled. The benefit is less memory usage as
             *       norms take up one byte of RAM per indexed field for every document in the index, during searching.
             *       Note that once you index a given field with norms enabled, disabling norms will have no effect. In
             *       other words, for this to have the above described effect on a field, all instances of that field
             *       must be indexed with NOT_ANALYZED_NO_NORMS from the beginning.
             */

            var document = new Document();

            document.Add(new Field(FooSearchFields.Key, searchData.Key, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field(FooSearchFields.Parrot, searchData.Parrot, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field(FooSearchFields.Bar, searchData.Bar, Field.Store.YES, Field.Index.NO));

            return document;
        }
    }
}