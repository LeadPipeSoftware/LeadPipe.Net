using LeadPipe.Net.Domain;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
    public class StrictTestModelRepository : Repository<TestModel>
    {
        public StrictTestModelRepository(IDataCommandProvider dataCommandProvider, IObjectFinder<TestModel> objectFinder) 
            : base(dataCommandProvider, objectFinder, RepositoryStrictness.Strict)
        {
        }
    }
}