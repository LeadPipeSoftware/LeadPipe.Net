// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using NUnit.Framework;

namespace LeadPipe.Net.Lucene.Tests.SearchService
{
    [TestFixture]
    public class SearchShould
    {
        [Test]
        public void ReturnOneResultWhenSearchingByIdExplicitly()
        {
            // Arrange
            Bootstrapper.Start();

            var searchService = Bootstrapper.Container.GetInstance<ISearchService<Foo, FooSearchData>>();

            searchService.ClearIndex();
            
            var entities = new List<Foo>
            {
                new Foo{Id = "123", Parrot = "SQUAWK!", Bar = "Cheers"}
            };

            searchService.UpdateIndex(entities);

            // Act
            var results = searchService.Search("id:123");

            // Assert
            Assert.That(results.TotalHitCount == 1);
        }

        [Test]
        public void ReturnOneResultWhenSearchingByIdAsDefaultField()
        {
            // Arrange
            Bootstrapper.Start();

            var searchService = Bootstrapper.Container.GetInstance<ISearchService<Foo, FooSearchData>>();

            searchService.ClearIndex();

            searchService.SetDefaultSearchFields(new List<string> { FooSearchFields.Id });

            var entities = new List<Foo>
            {
                new Foo{Id = "123", Parrot = "SQUAWK!", Bar = "Cheers"}
            };

            searchService.UpdateIndex(entities);

            // Act
            var results = searchService.Search("123");

            // Assert
            Assert.That(results.TotalHitCount == 1);
        }
    }
}
