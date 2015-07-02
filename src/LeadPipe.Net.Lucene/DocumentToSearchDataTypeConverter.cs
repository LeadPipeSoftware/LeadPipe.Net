// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentToSearchDataTypeConverter.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Lucene.Net.Documents;

namespace LeadPipe.Net.Lucene
{
	/// <summary>
	/// Converts Lucene Document types to SearchData types.
	/// </summary>
	public abstract class DocumentToSearchDataTypeConverter<TSearchData> : IDocumentToSearchDataTypeConverter<TSearchData> where TSearchData : IKeyed, new()
	{
        /// <summary>
        /// Converts the specified document to search data.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="document">The document.</param>
        /// <param name="score">The score.</param>
        /// <param name="topScore">The top score.</param>
        /// <returns></returns>
	    public abstract TSearchData Convert(int documentId, Document document, float score, float topScore);

        /// <summary>
        /// Counts the score stars.
        /// </summary>
        /// <param name="normalizedScore">The normalized score.</param>
        /// <returns></returns>
		protected static int CountScoreStars(float normalizedScore)
		{
			/*
			 * Here we want to put 1 through 5 stars on our matches. To do that we simply divide the normalized score
			 * by 0.20. Clearly our top match will result in 5. Our next match (0.909) will result in 4.54 which we
			 * then truncate to 4 and cast as an integer.
			 */
			var scoreStarCount = (int)Math.Truncate(normalizedScore / 0.20);

			return scoreStarCount;
		}

        /// <summary>
        /// Gets the document field value.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
		protected static string GetDocumentFieldValue(Document document, string fieldName)
		{
			var result = document.Get(fieldName.ToUpperInvariant());

			return result ?? string.Empty;
		}

        /// <summary>
        /// Normalizes the score.
        /// </summary>
        /// <param name="score">The score.</param>
        /// <param name="topScore">The top score.</param>
        /// <returns></returns>
		protected static float NormalizeScore(float score, float topScore)
		{
			/*
			 * Here we're normalizing the score. Let's say that the highest score in the set is 1.375. This algorithm
			 * will divide that by itself and the result will be 1.000. Great, that's the top. Now let's say the next
			 * score is 1.250. We divide that by our top score and we get 0.909. Awesome.
			 */
			var normalizedScore = score / topScore;

			return normalizedScore;
		}
	}
}