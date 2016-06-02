// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
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