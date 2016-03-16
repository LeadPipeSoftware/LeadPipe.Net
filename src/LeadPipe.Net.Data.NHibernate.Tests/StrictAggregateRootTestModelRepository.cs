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