# LeadPipe.Net.Data.NHibernate

LeadPipe.Net.Data.NHibernate is a comprehensive pre-built data implementation package that uses NHibernate and provides implementations of a Repository, the Query Object pattern, and Unit of Work pattern. This library is built in such a way that if you don't want to abstract NHibernate's ISession object with a Unit of Work or use the Repository pattern, you can still take advantage of other offerings such as the Query Object pattern and Object Finder.

## Getting Started

Getting started is easy. Assuming you're using an IoC container such as Unity or StructureMap, the simplest way to go about it is to reference the NuGet package that corresponds to your preferred container. All you need to dois use the LeadPipeNHibernateDataConfiguration type to get the ball rolling.

```csharp
var container = new Container();

LeadPipeNHibernateDataConfiguration.Initialize(container, typeof(UnitTestSessionFactoryBuilder));

/*
 * It's only necessary to register repositories if you have custom implementations that
 * extend the base Repository class. If you do nothing, you'll simply get the generic
 * repository implementation.
 */

LeadPipeNHibernateDataConfiguration.RegisterRepository<TestModel>(container, typeof(TestModelRepository));
```

### Session Factory Builder Interface

The Session Factory Builder interface is what you'll implement in your code to deliver a configured NHibernate SessionFactory. Here's an example that uses NHibernate's loquacious syntax and a SQLite in-memory database:

```csharp
public class SessionFactoryBuilder : ISessionFactoryBuilder
{
	private const string MapDocumentName = "NHibernateMap";

	private ISessionFactory sessionFactory;

	public global::NHibernate.Cfg.Configuration Configuration { get; protected set; }

	public ISessionFactory Build()
	{
		if (this.sessionFactory != null)
		{
			return this.sessionFactory;
		}

		this.Configuration = this.Configure();
		var mapping = this.Map();
		this.Configuration.AddDeserializedMapping(mapping, MapDocumentName);
			
		this.sessionFactory = this.Configuration.BuildSessionFactory();

		new SchemaExport(this.Configuration).Create(false, true);

		return this.sessionFactory;
	}

	private global::NHibernate.Cfg.Configuration Configure()
	{
		var configuration = new global::NHibernate.Cfg.Configuration();

		configuration.DataBaseIntegration(
			db =>
				{
					db.Driver<SQLite20Driver>();
					db.ConnectionString = "Data Source=:memory:;Version=3;New=True;Pooling=True;Max Pool Size=1";
					db.Dialect<SQLiteDialect>();
					db.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
				});

		return configuration;
	}

	private HbmMapping Map()
	{
		var mapper = new ModelMapper();

		mapper.AddMapping<FooMap>();
		mapper.AddMapping<BarMap>();

		var mapping = mapper.CompileMappingFor(new[] { typeof(Foo), typeof(Bar) });

		return mapping;
	}
}
```

Here's an example using Fluent NHibernate:

```csharp
public class SessionFactoryBuilder : ISessionFactoryBuilder
{
    public NHibernate.Cfg.Configuration Configuration { get; private set; }

    public ISessionFactory Build()
    {
        ISessionFactory sessionFactory = null;

        try
        {
            sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString("Server=YOURSERVER;Database=YOURDATABASE;Trusted_Connection=True;"))
                .Mappings(m => { m.FluentMappings.AddFromAssemblyOf<Blog>(); })
                .ExposeConfiguration(config =>
                {
                    Configuration = config;
                    new SchemaExport(config).Execute(true, true, false);
                })
                .Diagnostics(d => d.Enable()).BuildSessionFactory();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while configuring the database connection.", ex);
        }

        NHibernateProfiler.Initialize();

        return sessionFactory;
    }
}
```

### Unit of Work

The Unit of Work is ultimately the object you'll spend a lot of your time with. It pulls everything together in a classic, easily recognized pattern:

```csharp
using(unitOfWork.Start())
{
	// Do stuff...
	//
	unitOfWork.Commit();
}
```

Note that the LeadPipe.Net.Data.NHibernate implementation of Unit of Work is not merely a wrapper of ISession as found with other implementations.

### Unit of Work Factory

To obtain a Unit of Work, we'll use the UnitOfWorkFactory's CreateUnitOfWork method as such:

```csharp
var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

using(unitOfWork.Start())
{
	// Do stuff...
	//
	unitOfWork.Commit();
}
```

### Repository

Do do anything useful, you'll probably want to use a Repository. Here's an example:

```csharp
var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

using(unitOfWork.Start())
{
    var foo = new Foo("Bar");

	repository.Create(foo);

	unitOfWork.Commit();
}
```

If you don't want to use a Repository, you can access the NHibernate ISession directly through the DataCommandProvider which coincidentally provides essential CRUD operations.

#### Repository.Create

The Create method will add a new object to the repository and will persist that object when the Unit of Work is committed.

#### Repository.Delete

The Delete method will remove an object from the repository and will remove that object permanently when the Unit of Work is committed.

#### Repository.Load

The Load method will load an existing object based on its mapped id. If no match is found, an exception is thrown.

#### Repository.Get

The Get method will attempt to load an existing object based on its mapped id. If no match is found, it returns null.

#### Repository.Save

The Save method behaves the same as the Create method.

#### Repository.Update

The Update method will update an existing object in the repository and will persist those changes when the Unit of Work is committed.

#### Repository.Find.All

The Find.All method will return all objects of that type. Be careful! You probably want to put a limit on the number of objects returned.

#### Repository.Find.All with expressions

The Find.All method is an IQueryable which means that you can add LINQ expressions to query for what you want. For example:

```csharp
var results = repository.Find.All.Where(x => x.SomeProperty.Equals("123"));
```

#### Repository.Find.AllMatchingExpression

The Find.AllMatchingExpression method returns all objects that match an expression that you supply.

```csharp
var results = repository.Find.AllMatchingExpression(x => x.MyProperty > 10);
```

#### Repository.Find.AllMatchingSpecification

The Find.AllMatchingSpecification method returns all objects that match a specification that you supply.

```csharp
var results = repository.Find.AllMatchingSpecification(MySpecifications.PropertyStartsWithABC());
```

#### Repository.Find.AllMatchingQuery

```csharp
var results = repository.Find.AllMatchingQuery(new FoosWithSomePropertyThatStartWithABC(dataCommandProvider));
```

### Advanced

These are generally things you won't have to worry about, but explanations are provided just in case you want to extend or replace components in your project.

#### Active Data Session Manager

The Active Data Session Manager has one job; return the active NHibernate ISession which it has safely tucked away for us.

#### Data Command Provider

The Data Command Provider takes on the job of providing the essential Create, Read, Update, and Delete (CRUD) aspects. Interesting to note that if you don't have a desire to use the Repository pattern, you can still use the Data Command Provider to do whatever you need.

#### Data Session Provider

The Data Session Provider's job is to create ISessions for us.

## A Note on Wrapping Your O/RM

Not that long ago it was a very popular practice to abstract the O/RM and LeadPipe.Net.Data.NHibernate is, in many ways, a example of that way of thinking. Take some time to do your own research, experiment, and form your own opinions about what works the best for you. Bear in mind, however, that you can get a lot of value from the LeadPipe.Net.Data libraries without necessarily abstracting tools like NHibernate away completely.
