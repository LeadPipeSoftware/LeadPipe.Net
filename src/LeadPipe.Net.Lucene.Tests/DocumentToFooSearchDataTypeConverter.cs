// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Documents;

namespace LeadPipe.Net.Lucene.Tests
{
    /// <summary>
    /// Converts Lucene Document types to FooSearchData types.
    /// </summary>
    public class DocumentToFooSearchDataTypeConverter : DocumentToSearchDataTypeConverter<FooSearchData>
    {
        /// <summary>
        /// Converts the specified document to search data.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="document">The document.</param>
        /// <param name="score">The score.</param>
        /// <param name="topScore">The top score.</param>
        /// <returns>The converted data.</returns>
        public override FooSearchData Convert(int documentId, Document document, float score, float topScore)
        {
            var normalizedScore = NormalizeScore(score, topScore);

            var scoreStarCount = CountScoreStars(normalizedScore);

            var scoreStars = new string(System.Convert.ToChar("*"), scoreStarCount);

            var parrot = GetDocumentFieldValue(document, FooSearchFields.Parrot);
            var bar = GetDocumentFieldValue(document, FooSearchFields.Bar);

            var fooSearchData = new FooSearchData
            {
                Parrot = parrot,
                Bar = bar,
                Score = scoreStars
            };

            return fooSearchData;
        }
    }
}