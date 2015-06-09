# LeadPipe.Net

LeadPipe.Net not an architecture. It's an a'la carte collection of helpful types, attributes, extension methods, and other great stuff. For example:

## Cross-Cutting Goodies

LeadPipe.Net provides quite a few useful cross-cutting goodies that are handy for almost any project.

### Collections

#### Tracking Observable Collection

The tracking observable collection is a collection that maintains a record of events. For example, if an item is added to the collection, it is recorded. This makes it easy to determine what changes have occurred and react accordingly.

#### Stacked List

The stacked list is an observable collection that acts like a stack. You can peek, pop, push and so forth.

### Commands

Here you'll find an implementation of the command mediator pattern.

### Extensions

There are tons of useful extension methods here. You'll find handy extension for these types:

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

### Finite State Machine

A Finite State Machine (FSM) is the mechanism by which we can model an abstract machine by defining a finite number of States as well as the Transitions between those States. For example, a door may be considered an FSM in that it has States (open and closed) as well as Transitions (open and close) that are triggered by Events (opened and closed) that are invoked by object methods (door.Open and door.Close).

There are two implementations; a simple FSM and an expanded FSM. Use the one that suits your needs.
 
### Clock

Use Clock instead of DateTime.Now to make writing unit tests easier.

### Enumeration

A straight-up copy of Jimmy Bogard's excellent Enumeration supertype.

### Guard

A fluent guarding class that lets you do things like:

```
Guard.AgainstNullArgument(() => foo);
```

### Poller

A poller that will retry an operation until criteria is met.

### Random Value Provider

Provides random strings, integers, lorem ipsum, booleans, and much more. Great for unit testing.

### Unit Type

An implementation of F#'s UnitType that represents void so that you can still return a value. This implementation lets us do things like define a type that *conceptually* has void as a generic argument.

## Domain Driven Design

LeadPipe.Net.Domain provides great base implementations of common Domain Driven Design types.

(more info coming soon)

## Data NHibernate

LeadPipe.Net.Data.NHibernate provides an easily-integrated solution for using NHibernate.

(more info coming soon)
