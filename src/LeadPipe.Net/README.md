# LeadPipe.Net

LeadPipe.Net is the core library that provides quite a few useful cross-cutting goodies that are handy for almost any project. Even if you don't want or need any other LeadPipe.Net libraries, there's almost certainly something in this library you'll find useful.

## Collections

### Tracking Observable Collection

The tracking observable collection is a collection that maintains a record of events. For example, if an item is added to the collection, it is recorded. This makes it easy to determine what changes have occurred and react accordingly.

```csharp
var originalList = new List<NotifyingStringClass> { new NotifyingStringClass() };

var trackingObservableCollection = new TrackingObservableCollection<NotifyingStringClass>(originalList);

var newItem = new NotifyingStringClass();

this.trackingObservableCollection.Add(newItem);

this.trackingObservableCollection.HasAddedItems; // returns true!

var addedItems = this.trackingObservableCollection.AddedItems; // all the added items!
```

### Stacked List

The stacked list is an observable collection that acts like a stack. You can peek, pop, push and so forth. Here's an example of pushing items then popping:

```csharp
var stackedList = new StackedList<int>();

stackedList.Push(0);
stackedList.Push(1);
stackedList.Push(2);
stackedList.Push(3);

var poppedItem = stackedList.Pop();

poppedItem.Equals(3)); // returns true!
```

## Command Mediator

Here you'll find a straight-forward implementation of the command mediator pattern. For more information on this very useful pattern [click here](https://sourcemaking.com/design_patterns/mediator).

## Extensions

There are tons of useful extension methods here. You'll find handy extension for these types and more:

- Bool
- DateTime
- Decimal
- Dictionary
- Enumerable
- Enum
- Exception
- Int
- Linq
- List
- Object
- Stream
- String
- Type
- Version

## Finite State Machine

A Finite State Machine (FSM) is the mechanism by which we can model an abstract machine by defining a finite number of States as well as the Transitions between those States. For example, a door may be considered an FSM in that it has States (open and closed) as well as Transitions (open and close) that are triggered by Events (opened and closed) that are invoked by object methods (door.Open and door.Close).

There are two implementations; a simple FSM and an expanded FSM. Use the one that suits your needs. For more information on Finite State Machines [click here](https://en.wikipedia.org/wiki/Finite-state_machine).
 
## Clock

DateTime.Now is certainly an easy and generally reliable way of determining when it is. However, it presents a significant problem when it comes to unit tests; it's not mockable without some pretty ugly acrobatics. The solution is very simple - use your own clock abstraction! LeadPipe.Net provides a simple Clock with GetCurrentTime() and GetCurrentUtcTime() implementations that are dead simple to mock.

## Enumeration

A straight-up copy of [Jimmy Bogard's excellent Enumeration supertype](https://lostechies.com/jimmybogard/2008/08/12/enumeration-classes/). You don't know what you're missing if you haven't taken this incredible time saver for a spin around the block. Jimmy even shows us how to [persist it with NHibernate](https://lostechies.com/jimmybogard/2012/05/01/persisting-enumeration-classes-with-nhibernate/).

## Guard

Nothing is more obnoxious than wading through dozens of lines of guarding code to get to the meat of the method. The Guard class can help you clean things up and make your code easier to read and more intention revealing. For example, you can replace this:

```csharp
public void SomeMethod(string someArg)
{
	if (someArg == null) throw new ArgumentNullException("Argument someArg cannot be null!");
	
	if (someArg == string.EmptyOrNull) throw new ArgumentNullException("Argument someArg must have a value!");
	
	if (someArg.Equals("SomethingWeHate")
	{
		throw new InvalidOperationException("We hate that!");
	}
	
	var something = new Something("Whatever");
	
	// ...
}

```

With this:

```csharp
public void SomeMethod(string someArg)
{
	Guard.Will.ProtectAgainstNullArgument(() => nullArgument);
	Guard.Will.ThrowExceptionOfType<InvalidOperationException>().When(someArg.Equals("SomethingWeHate");
	Guard.Will.ProtectAgainstNullOrEmptyStringArgument(() => argument);
	
	var something = new Something("Whatever");
	
// ...
}
```

Granted, this is a contrived example, but even here it's clear by simply using the Guard type we can easily identify the defensive programming code from the business logic.

## Poller

A poller that will retry an operation until criteria is met. Here's a really stupid example of the happy path:

```csharp
var poller = new Poller();

// Ask the poller to start and immediately return true...
poller.Start(() => true);

poller.State == Poller.PollerState.Finished; // returns true!
```

Here's an example of when something goes wrong:

```csharp
var poller = new Poller();

// Ask the poller to start and immediately return false (force a timeout)...
poller.Start(() => false);

poller.State == Poller.PollerState.TimedOut; // returns true!
```

```csharp
public class SomethingRequiringPolling()
{
	private int functionRunLimit = 5;
	private int functionRunCount;
	
	public void StartThing()
	{
		var poller = new Poller();

		poller.Start(this.PollingFunction);

		if (poller.State == Poller.PollerState.TimedOut)
		{
			throw new TimeoutException("The thing timed out!");
		}
	}
	
	// This could be anything that might require some sort of polling...
	private bool PollingFunction()
	{
		++this.functionRunCount;
	
		Debug.WriteLine(DateTime.Now.ToString().FormattedWith("Polling function called at {0}."));
	
		Debug.WriteLine((this.functionRunCount >= this.functionRunLimit).ToString().FormattedWith("Polling function returning {0}."));
	
		return this.functionRunCount >= this.functionRunLimit;
	}
}
```

## Random Value Provider

When unit testing it's great to shake things up. Throwing random (well, pseudo random) values into the mix can occasionally expose bugs that you wouldn't have otherwise caught. It's also not uncommon for programmers to accidentally write unit test code that will always pass due to the values they're using in the test itself.

The Random Value Provider is a helpful static type that can return all sorts of useful random values and is very easy to use:

```csharp
var loremIpsum = RandomValueProvider.LoremIpsum();

var randomBool = RandomValueProvider.RandomBool();
```

Other very helpful random methods include:

.RandomInteger()
.RandomUnsignedInteger()
.RandomString()
.RandomKeys()
.RandomValues()
.RandomDateTime()

## Unit Type

An implementation of [F#'s Unit Type](https://msdn.microsoft.com/en-us/library/dd483472.aspx) that represents void so that you can still return a value. This implementation lets us do things like define a type that *conceptually* has void as a generic argument.

## Salted Hash

Hash algorithms are one way functions that turn data into a fixed-length checksum that cannot be reversed. When designed and implemented properly, they are very sensitive meaning that if even a little tiny bit of the source data changes the resulting hash would be completely different. Hashes are just the ticket for storing sensitive data without *actually* storing it.

We all know better than to store passwords in plain text, but hashing is vulnerable as well. There are a lot of ways to quickly recover passwords from normal hashes. Generally, user passwords can be cracked very quickly with modern tools and techniques such as lookup tables, dictionaries, rainbows, and so forth.

The good news is that we can make cracking hashes MUCH more difficult. One of the quickest and easiest ways is to "salt the hash". Salting is nothing more than appending a string of random characters to the data before the hash is calculated. Doing so makes lookup and rainbow tables useless.

The SaltedHash type makes creating and working with salted hashes quick and easy. Don't store password hashes without it!

## Persistable Object

Alas, persistence is a leaky abstraction. It can clutter up what is otherwise a nice, clean, POCO object graph that neatly represents the business with all sorts of noise about databases, connection strings, keys, and so on. Yuck!

Many O/RM frameworks require a unique identifier for persistence purposes. Of course, you can use your object's natural identity for this purpose. However, it is often advisable to use a surrogate identity instead. This identity has no meaning to the business, however, and effectively decouples what is ultimately just a persistence concern from the business concern and, therefore, shouldn't be leaked outside of the data layer.

The Persistable Object base type provides a first-class implementation of the surrogate identity notion. It is particularly useful if you choose to steer your project down a Domain Driven Design path. Whereas all that's ultimately required of an Entity in DDD is that it have identity and the notion of a lifecycle, all too often we see Entity base classes that also try to hide the leaky peristence abstraction.

The Persistable Object can be used in conjunction with the IEntity interface in LeadPipe.Net.Domain library to achieve the goal of maintaining true-to-spirit DDD implementations while also taking care of the realities of intrusions such as persistence. You also get audit fields (CreatedBy, CreatedOn, UpdatedBy, UpdatedOn) and other goodies as well. In short, if you're gonna save it somewhere, you might consider having it derive from PersistableObject.

## Paginated List

Scott Hanselman wrote the Nerd Dinner tutorial and snuck in a little gem in [part 8](http://nerddinnerbook.s3.amazonaws.com/Part8.htm) that is a paginated list. It is exactly what it sounds like and a cheap, effective way to add paging support to the List type. LeadPipe.Net has taken a nearly verbatim copy of Scott's little class and included it for everyone to enjoy.

## NotifyPropertyChanged Base Class

Anyone that's worked with WPF knows how important the NotifyPropertyChanged event is. LeadPipe.Net provides a base class that implements the infrastructure for property change notification and automatically performs UI thread marshalling.

## Here There Be Dragons!

This attribute allows programmers to decorate dangerous parts of the code. The intent is to give programmers a way to decorate code where, for whatever reason, they decided to do something in a way that is not straight-forward. The phrase denotes dangerous or unexplored territories much like the medieval practice of putting dragons and other mythological creatures in the blank areas of maps.

```csharp
[HereThereBeDragons("Be careful not to twiddle the Foo or else the Bar will misalign!")
public void SomethingWickedThisWayComes(Foo foo)
{
	// Dangerous code here...
}
```

## Context-Aware Configuration Settings

Managing application settings can be a precarious business. One slip and suddenly you could be writing test data to the production server or worse. The context-aware configuration classes provided by LeadPipe.Net offer one solution to this problem by allowing you to create application settings that are based on the running context.

With this method, all you have to do is change one value (Context) and all of your context-aware settings will be returned when you use the ConfigurationService.GetApplicationSetting() method. For example, given this App.config file:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<connectionStrings>
		<add name="Development.DatabaseServer"
			 connectionString="Data Source=MyDatabase.db;"
		     providerName="System.Data.SQLite" />
	</connectionStrings>
	<appSettings>		
		<add key="Context"
			 value="Development" />
		<add key="Development.SomeSetting"
			 value="Gopher" />
		<add key="Test.SomeSetting"
			 value="Groundhog" />
		<add key="Production.SomeSetting"
		     value="Gazelle" />
	</appSettings>
</configuration>
```

When we use the ConfigurationService to ask for the application setting we'll get the value for the Development context:

```csharp
var setting = ConfigurationService.GetApplicationSetting("SomeSetting");

setting.Equals("Gopher"); // returns true!
```
 Of course there are probably as many ways to handle this problem as there are programmers, but LeadPipe.Net gives you a solution that you might find useful.
 