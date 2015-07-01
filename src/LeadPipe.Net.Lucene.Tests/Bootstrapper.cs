// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using StructureMap;

namespace LeadPipe.Net.Lucene.Tests
{
    /// <summary>
    /// Bootstraps the project.
    /// </summary>
	public class Bootstrapper
	{
        /// <summary>
        /// Prevents a default instance of the <see cref="Bootstrapper"/> class from being created.
        /// </summary>
		private Bootstrapper()
		{
		}

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
		public static Container Container { get; protected set; }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <returns></returns>
		public static Bootstrapper Start()
		{
			var bootstrapper = new Bootstrapper();

			Container = new Container(c =>
			{
				c.For<ISearchIndexClearer>().Use<SearchIndexClearer>();
				c.For<ISearchIndexOptimizer>().Use<SearchIndexOptimizer>();
				c.For<ISearchQueryParser>().Use<SearchQueryParser>();
				c.For<ISearchScoreExplainer>().Use<SearchScoreExplainer>();

				c.For<IDocumentToSearchDataTypeConverter<FooSearchData>>().Use<DocumentToFooSearchDataTypeConverter>();
				c.For<ISearchDataToDocumentTypeConverter<FooSearchData>>().Use<FooSearchDataToDocumentTypeConverter>();
				c.For<IEntityToSearchDataTypeConverter<Foo, FooSearchData>>().Use<FooToFooSearchDataTypeConverter>();

				c.For<ISearchIndexUpdater<Foo, FooSearchData>>().Use<SearchIndexUpdater<Foo, FooSearchData>>();
				c.For<ISearcher<FooSearchData>>().Use<Searcher<FooSearchData>>();
				c.For<ISearchService<Foo, FooSearchData>>().Use<SearchService<Foo, FooSearchData>>();
			});

			return bootstrapper;
		}
	}
}
