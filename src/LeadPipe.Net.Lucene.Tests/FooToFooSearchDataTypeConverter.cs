// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FooToFooSearchDataTypeConverter.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Lucene.Tests
{
	/// <summary>
	/// Converts Foo types to FooSearchData types.
	/// </summary>
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
}