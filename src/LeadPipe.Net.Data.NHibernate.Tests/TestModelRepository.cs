// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
    /// <summary>
    /// The test model repository.
    /// </summary>
    public class TestModelRepository : Repository<TestModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestModelRepository"/> class.
        /// </summary>
        /// <param name="dataCommandProvider">The data session.</param>
        /// <param name="objectFinder">The object finder.</param>
        public TestModelRepository(IDataCommandProvider dataCommandProvider, IObjectFinder<TestModel> objectFinder)
            : base(dataCommandProvider, objectFinder, RepositoryStrictness.Open)
        {
        }
    }
}