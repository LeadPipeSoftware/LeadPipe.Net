using LeadPipe.Net.Domain;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
    public class AggregateRootTestModel : TestModel, IAggregateRoot
    {

        public AggregateRootTestModel(string testProperty) : base(testProperty)
        {
        }

        public AggregateRootTestModel()
        {
        }
    }
}