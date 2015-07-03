# LeadPipe.Net.Data.NHibernate

LeadPipe.Net.Data.NHibernate is a comprehensive pre-built data implementation package that uses NHibernate and provides implementations of a Repository, the Query Object pattern, and Unit of Work pattern. This library is built in such a way that if you don't want to abstract NHibernate's ISession object with a Unit of Work or use the Repository pattern, you can still take advantage of other offerings such as the Query Object pattern and Object Finder.

## Active Data Session Manager

The Active Data Session Manager has one job; return the active NHibernate ISession which it has safely tucked away for us.

## Data Command Provider

The Data Command Provider takes on the job of providing the essential Create, Read, Update, and Delete (CRUD) aspects. Interesting to note that if you don't have a desire to use the Repository pattern, you can still use the Data Command Provider to do whatever you need.

## Data Session Provider

The Data Session Provider's job is to create ISessions for us.

## Session Factory Builder Interface

The Session Factory Builder interface is what you'll implement in your code to deliver a configured NHibernate SessionFactory.

## Unit of Work

The Unit of Work is ultimately the object you'll spend almost all of your time with. It pulls everything together in a classic, easily recognized pattern:

```csharp
using(unitOfWork.Start())
{
	// Do stuff...
	//
	unitOfWork.Commit();
}
```

Note that the LeadPipe.Net.Data.NHibernate implementation of Unit of Work is not merely a wrapper of ISession as found with other implementations.

## Unit of Work Factory

The Unit of Work Factory's job? You guessed it! It creates new units of work for us and can be used as such:

```csharp
var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

using(unitOfWork.Start())
{
	// Do stuff...
	//
	unitOfWork.Commit();
}
```

## A Note on Wrapping Your O/RM

Not that long ago it was a very popular practice to abstract the O/RM and LeadPipe.Net.Data.NHibernate is, in many ways, a example of that way of thinking. Take some time to do your own research, experiment, and form your own opinions about what works the best for you. Bear in mind, however, that you can get a lot of value from the LeadPipe.Net.Data libraries without necessarily abstracting tools like NHibernate away completely.
