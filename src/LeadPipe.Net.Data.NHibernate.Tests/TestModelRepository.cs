// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestModelRepository.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
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
            : base(dataCommandProvider, objectFinder)
        {
        }
    }
}