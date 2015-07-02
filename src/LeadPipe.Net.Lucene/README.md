# LeadPipe.Net.Lucene

LeadPipe.Net.Lucene provides a set of base types that make implementing the powerful, open source Lucene search engine straight-foward. The goal is to make using Lucene as simple as this:

```c-sharp
	var results = searchService.Search("123");
```

## Getting Started

LeadPipe.Net.Lucene is based on the notion that you have entities (POCO's) that you will project into search data. Next, you need to convert that search data into a Lucene document and vice versa. Let's have a look at how this works.

### EntityToSearchDataTypeConverter

First, we'll create an EntityToSearchDataTypeConverter. Here we're taking whatever object we want to put in Lucene's search index and converting it into search data. This search data type is what we'll convert into a Lucene document and also what we'll get back from a Lucene search.

```c-sharp
public class FooToFooSearchDataTypeConverter : IEntityToSearchDataTypeConverter<Foo, FooSearchData>
{
	public FooSearchData Convert(Foo foo)
	{
		var fooSearchData = new FooSearchData
		{
			Key = foo.Key,
			Parrot = foo.Parrot,
			Bar = foo.Bar,
		};

		return fooSearchData;
	}
}
```

Think of search data types as search and result optimized data transfer objects. These types should be flattened and normalized.

### SearchDataToDocumentTypeConverter

Next, we need to convert our search data into a Lucene document. This is our opportunity to tell Lucene exactly how to handle our data.

```c-sharp
public Document Convert(FooSearchData searchData)
{
	var document = new Document();

	document.Add(new Field(FooSearchFields.Key, searchData.Key, Field.Store.YES, Field.Index.ANALYZED));
	document.Add(new Field(FooSearchFields.Parrot, searchData.Parrot, Field.Store.YES, Field.Index.ANALYZED));
	document.Add(new Field(FooSearchFields.Bar, searchData.Bar, Field.Store.YES, Field.Index.NO));

	return document;
}
```

### DocumentToSearchDataTypeConverter

When we perform a search, we want to get our search data back. To do that, we need to convert a Lucene document into search data.

```c-sharp
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
```

### Configuration

Finally, we just need to configure our search service. This will depend on your environment, but the simplest way is like this:

```c-sharp
var config = new SearchServiceConfiguration(Version.LUCENE_30, IndexWriter.MaxFieldLength.UNLIMITED, @"C:\SearchIndex\", "write.lock", 1000);
            
            var parser = new SearchQueryParser();
            
            var searchService = new SearchService<Foo, FooSearchData>(
                config,
                new SearchIndexClearer(),
                new SearchIndexOptimizer(),
                new Searcher<FooSearchData>(parser, new DocumentToFooSearchDataTypeConverter()),
                new SearchIndexUpdater<Foo, FooSearchData>(new FooSearchDataToDocumentTypeConverter(), new FooToFooSearchDataTypeConverter()), new SearchScoreExplainer(parser));
```

Of course, a good dependency injection framework can make all that go away. For example, with StructureMap we might do this:

```c-sharp
Container = new Container(c =>
{
    c.For<ISearchServiceConfiguration>().Use(() => new SearchServiceConfiguration(
        Version.LUCENE_30,
        IndexWriter.MaxFieldLength.UNLIMITED,
        @"C:\SearchIndex\",
        "write.lock",
        1000)).Named("Configuration");

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
```

Of course, each framework is different. Do what make the most sense for you.

### SearchFields (optional)

One thing that is optional, but recommended is to create a simple class that keeps magic strings out of your code. Everywhere you see a usage of FooSearchFields in the example above comes from this class:

```c-sharp
public class FooSearchFields
{
	public static readonly string Key;

	public static readonly string Parrot;

	public static readonly string Bar;

	static FooSearchFields()
	{
		Key = "Key".ToLowerInvariant();
		Parrot = "Parrot".ToLowerInvariant();
		Bar = "Bar".ToLowerInvariant();
	}
}
```

## Summary

That should be enough to get you started. Nearly every aspect of LeadPipe.Net.Lucene is customizable. All you have to do is inherit from the base class, override what you need to override, and you're off and running!