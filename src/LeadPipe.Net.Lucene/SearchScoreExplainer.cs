// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace LeadPipe.Net.Lucene
{
    /// <summary>
    /// Explains search scores.
    /// </summary>
    public class SearchScoreExplainer : ISearchScoreExplainer
    {
        private readonly ISearchQueryParser searchQueryParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchScoreExplainer"/> class.
        /// </summary>
        /// <param name="searchQueryParser">The search query parser.</param>
        public SearchScoreExplainer(ISearchQueryParser searchQueryParser)
        {
            this.searchQueryParser = searchQueryParser;
        }

        /// <summary>
        /// Explains the search score for a result.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="input">The input.</param>
        /// <param name="resultId">The result identifier.</param>
        /// <returns></returns>
        public virtual string Explain(Version luceneVersion, FSDirectory fsDirectory, string input, int resultId)
        {
            return string.IsNullOrEmpty(input) ? string.Empty : this.PerformExplain(luceneVersion, fsDirectory, input, resultId);
        }

        /// <summary>
        /// Performs the explanation.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="searchQuery">The search query.</param>
        /// <param name="resultId">The result identifier.</param>
        /// <returns></returns>
        protected virtual string PerformExplain(Version luceneVersion, FSDirectory fsDirectory, string searchQuery, int resultId)
        {
            /*
             * The obvious problem here is that we're not using the exact same search as the real one.
             */

            var explanation = string.Empty;

            using (var indexSearcher = new IndexSearcher(fsDirectory, false))
            {
                var analyzer = new StandardAnalyzer(luceneVersion);

                var queryParser = new MultiFieldQueryParser(luceneVersion, new[] { "Id".ToLowerInvariant() }, analyzer)
                {
                    DefaultOperator = QueryParser.Operator.AND
                };

                var query = this.searchQueryParser.ParseQuery(searchQuery, queryParser);

                explanation = indexSearcher.Explain(query, resultId).ToHtml();

                analyzer.Close();
            }

            return explanation;
        }
    }
}