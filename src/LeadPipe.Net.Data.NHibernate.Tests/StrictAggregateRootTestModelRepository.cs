// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
    public class StrictAggregateRootTestModelRepository : Repository<AggregateRootTestModel>
    {
        public StrictAggregateRootTestModelRepository(IDataCommandProvider dataCommandProvider, IObjectFinder<AggregateRootTestModel> objectFinder)
            : base(dataCommandProvider, objectFinder, RepositoryStrictness.Strict)
        {
        }
    }
}