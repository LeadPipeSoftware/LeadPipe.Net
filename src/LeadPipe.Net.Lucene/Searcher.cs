// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using System.Collections.Generic;
using System.Linq;

namespace LeadPipe.Net.Lucene
{
    /// <summary>
    /// Performs searches.
    /// </summary>
    public class Searcher<TSearchData> : ISearcher<TSearchData> where TSearchData : IKeyed, new()
    {
        private readonly IDocumentToSearchDataTypeConverter<TSearchData> documentToSearchDataTypeConverter;

        private readonly ISearchQueryParser searchQueryParser;

        private List<string> allSearchFields = new List<string>();

        private List<string> defaultSearchFields = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Searcher{TSearchData}"/> class.
        /// </summary>
        /// <param name="searchQueryParser">The search query parser.</param>
        /// <param name="documentToSearchDataTypeConverter">The document to search data type converter.</param>
        public Searcher(ISearchQueryParser searchQueryParser, IDocumentToSearchDataTypeConverter<TSearchData> documentToSearchDataTypeConverter)
        {
            this.searchQueryParser = searchQueryParser;
            this.documentToSearchDataTypeConverter = documentToSearchDataTypeConverter;
        }

        /// <summary>
        /// Searches Lucene.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="hitLimit">The hit limit.</param>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public virtual SearchResult<TSearchData> Search(Version luceneVersion, FSDirectory fsDirectory, int hitLimit, string input)
        {
            return string.IsNullOrEmpty(input) ? new SearchResult<TSearchData>() : this.PerformSearch(luceneVersion, fsDirectory, hitLimit, input);
        }

        /// <summary>
        /// Sets the default search fields.
        /// </summary>
        /// <param name="searchFields">The default search fields.</param>
        public virtual void SetDefaultSearchFields(IEnumerable<string> searchFields)
        {
            this.defaultSearchFields.Clear();

            this.defaultSearchFields = searchFields as List<string>;
        }

        /// <summary>
        /// Sets the search fields.
        /// </summary>
        /// <param name="searchFields">The search fields.</param>
        public virtual void SetSearchFields(IEnumerable<string> searchFields)
        {
            this.allSearchFields.Clear();

            this.allSearchFields = searchFields as List<string>;
        }

        /// <summary>
        /// Performs a simple search.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="hitLimit">The hit limit.</param>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public virtual SearchResult<TSearchData> SimpleSearch(Version luceneVersion, FSDirectory fsDirectory, int hitLimit, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new SearchResult<TSearchData>();
            }

            var terms = input.Trim().Replace("-", " ").Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim() + "*");

            input = string.Join(" ", terms);

            return this.PerformSearch(luceneVersion, fsDirectory, hitLimit, input);
        }

        /// <summary>
        /// Maps the documents to search data.
        /// </summary>
        /// <param name="scoreDocuments">The score documents.</param>
        /// <param name="indexSearcher">The index searcher.</param>
        /// <returns></returns>
        private IEnumerable<TSearchData> MapDocumentsToSearchData(IEnumerable<ScoreDoc> scoreDocuments, IndexSearcher indexSearcher)
        {
            if (scoreDocuments == null) return new List<TSearchData>();

            var scoreDocs = scoreDocuments as IList<ScoreDoc> ?? scoreDocuments.ToList();

            if (!scoreDocs.Any()) return new List<TSearchData>();

            var topScore = scoreDocs.First().Score;

            return scoreDocs.Select(scoreDocument => this.documentToSearchDataTypeConverter.Convert(scoreDocument.Doc, indexSearcher.Doc(scoreDocument.Doc), scoreDocument.Score, topScore)).ToList();
        }

        /// <summary>
        /// Performs the search.
        /// </summary>
        /// <param name="luceneVersion">The lucene version.</param>
        /// <param name="fsDirectory">The fs directory.</param>
        /// <param name="hitLimit">The hit limit.</param>
        /// <param name="searchQuery">The search query.</param>
        /// <returns></returns>
        private SearchResult<TSearchData> PerformSearch(Version luceneVersion, FSDirectory fsDirectory, int hitLimit, string searchQuery)
        {
            var result = new SearchResult<TSearchData>();

            string[] fields = null;

            if (string.IsNullOrEmpty(searchQuery.Replace("*", string.Empty).Replace("?", string.Empty)))
            {
                return result;
            }

            fields = searchQuery.Contains(':') ? this.allSearchFields.ToArray() : this.defaultSearchFields.ToArray();

            using (var indexSearcher = new IndexSearcher(fsDirectory, false))
            {
                var analyzer = new StandardAnalyzer(luceneVersion);

                var queryParser = new MultiFieldQueryParser(luceneVersion, fields, analyzer) { DefaultOperator = QueryParser.Operator.AND };

                var query = this.searchQueryParser.ParseQuery(searchQuery, queryParser);

                var topFieldCollector = TopFieldCollector.Create(new Sort(), hitLimit, false, true, true, true);

                indexSearcher.Search(query, topFieldCollector);

                var topDocs = topFieldCollector.TopDocs();

                result.TotalHitCount = topDocs.TotalHits;

                var hits = topDocs.ScoreDocs;

                result.Results = this.MapDocumentsToSearchData(hits, indexSearcher);

                analyzer.Close();

                return result;
            }
        }
    }
}