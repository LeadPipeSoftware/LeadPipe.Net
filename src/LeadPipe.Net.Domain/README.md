# LeadPipe.Net.Domain

LeadPipe.Net.Domain provides implementations of core Domain Driven Design types including Entity, Repository, Value Object, domain events, Aggregate Roots, and more. These carefully crafted implementations are well documented and try to hold true to the spirit of Eric Evan's outstanding work.

There's not much to this library because there doesn't *need* to be. After all, Domain Driven Design isn't about a technical implementation, it's about concepts such as ubiquitous language and developing a useful model that's been distilled to the purest form possible. With that in mind, most of what you'll find in this library are merely marker and defining interfaces and an eventing mechanism that could easily fit in elsewhere.

If you came looking for a solid Repository implementation or Entity base type, you won't find it here. However, you can find implementations of those in other LeadPipe.Net libraries. In particular, if you're looking for a base type for your Entity classes, try inheriting from LeadPipe.Net's PersistableObject type and including the IEntity interface. That will fix you right up with a solid, well-tested implementation that's been used in production environments for years.

## Aggregate Root

A marker interface is provided for you to clearly indicate an Entity is an Aggregate Root. Usage is completely optional, but encouraged.

Reference page 125 - Evans, Eric. Domain Driven Design. 2004. Addison-Wesley. March 2009

## Domain Events

The LeadPipe.Net.Domain eventing approach is an adaptation of Udi Dahan's published technique. Our adaptation takes advantage of Local.Data to avoid ThreadStatic in a web context ([see here](http://www.hanselman.com/blog/ATaleOfTwoTechniquesTheThreadStaticAttributeAndSystemWebHttpContextCurrentItems.aspx). You can [read more about Udi's approach on his blog](http://www.udidahan.com/2009/06/14/domain-events-salvation/.
http://www.udidahan.com/2009/06/14/domain-events-salvation/).

## Domain Service

A marker interface is provided for you to clearly indicaate that an object is a domain service. Usage is completely optional.

Page 107 - Evans, Eric. Domain Driven Design. 2004. Addison-Wesley. March 2009

## Entity

An interface is provided that implements IKeyed.

## Repository

A strongly-typed repository implementation. Note that it does not require that your objects be marked as an Entity.

## Value Object

It is very difficult (impossible?) to implement value object overrides of Equals and GetHashCode that will work 100% reliably in a base class. There are dozens of approaches, but they all have pitfalls and you end up getting burned in one way or another. The Pluralsight guys have reached the same basic conclusion and, coincidentally, have implemented [a similar solution](http://blog.pluralsight.com/2012/01/21/domain-driven-design-in-c-equals-and-gethashcode-part-1/).

If you despise tracking down value versus reference equality bugs, use the ValueObject base type to force yourself to provide a property set of overrides. If, however, you like to live with "expert mode" turned on all the time, feel free to shrug your shoulders and move along. Don't say that you weren't warned, though!
