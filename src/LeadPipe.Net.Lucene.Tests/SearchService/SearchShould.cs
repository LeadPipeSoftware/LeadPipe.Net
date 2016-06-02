// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using Lucene.Net.Index;
using Lucene.Net.Util;
using NUnit.Framework;
using System.Collections.Generic;

namespace LeadPipe.Net.Lucene.Tests.SearchService
{
    [TestFixture]
    public class SearchShould
    {
        [Test]
        public void ReturnOneResultWhenSearchingByKeyAsDefaultField()
        {
            // Arrange
            Bootstrapper.Start();

            var searchService = Bootstrapper.Container.GetInstance<ISearchService<Foo, FooSearchData>>();

            searchService.ClearIndex();

            searchService.SetDefaultSearchFields(new List<string> { FooSearchFields.Key });

            var entities = new List<Foo>
            {
                new Foo{Key = "123", Parrot = "SQUAWK!", Bar = "Cheers"}
            };

            searchService.UpdateIndex(entities);

            // Act
            var results = searchService.Search("123");

            // Assert
            Assert.That(results.TotalHitCount == 1);
        }

        [Test]
        public void ReturnOneResultWhenSearchingByKeyExplicitly()
        {
            /*
             * NOTE: This test uses a manual build-up just as an example.
             */

            // Arrange
            var config = new SearchServiceConfiguration(Version.LUCENE_30, IndexWriter.MaxFieldLength.UNLIMITED, @"C:\SearchIndex\", "write.lock", 1000);

            var parser = new SearchQueryParser();

            var searchService = new SearchService<Foo, FooSearchData>(
                config,
                new SearchIndexClearer(),
                new SearchIndexOptimizer(),
                new Searcher<FooSearchData>(parser, new DocumentToFooSearchDataTypeConverter()),
                new SearchIndexUpdater<Foo, FooSearchData>(new FooSearchDataToDocumentTypeConverter(), new FooToFooSearchDataTypeConverter()), new SearchScoreExplainer(parser));

            searchService.ClearIndex();

            var entities = new List<Foo>
            {
                new Foo{Key = "123", Parrot = "SQUAWK!", Bar = "Cheers"}
            };

            searchService.UpdateIndex(entities);

            // Act
            var results = searchService.Search("key:123");

            // Assert
            Assert.That(results.TotalHitCount == 1);
        }
    }
}