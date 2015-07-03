# LeadPipe.Net.Authorization

The LeadPipe.Net Authorization library provides a flexible, easy-to-use authorization mechanism for your applications. With it, your authorization looks like this:

```csharp
var isAuthorized = authorizer
	.Will.Assert
	.User(user)
	.Can.ExecuteAnyOfTheseActivities(new[] { activity })
	.In(application);
```

If you prefer exceptions:

```csharp
authorizer
	.Will.ThrowAccessDeniedException()
	.When.User(user)
	.Can.Not.ExecuteAnyOfTheseActivities(new[] { activity })
	.In(application);
```

## Components

The components involved are straight-forward. They are:

### Activity

A single, finite unit of work. Often, these are outward facing capabilities of your application. For example, "ApprovePurchaseOrder" might be a great Activity. On the other hand, "DoAccounting" probably isn't. Of course, that's up to you.

### Activity Group

Activity Groups are macro collections of related Activities. They are not intended to act as Roles (see below), however. Think of Activity Groups as what you would use if you had two or more Activities necessary to complete a business saga. For example, "ManagePurchaseOrders" might be a great Activity Group whereas "AccountingStuff" might not. Again, it's entirely up to you and Activity Groups are optional.

### Application

Applications are top-level containers for Activities. With the LeadPipe.Net Authorization library, you have the flexibility to define multiple applications. This can be handy if you want to decentralize your authorization services.

### ApplicationUser

Application Users are associations of Users and Applications. You can define as many Users and Applications as you wish, but you must create an ApplicationUser in order to grant permissions. Generally speaking, however, you don't have to worry about it. A simple call to Application.AddUser() will take care of everything.

### Authorizer

The Authorizer is what you'll use to perform authorizations (see above).

### Role

Roles allow you to define aggregations of Activities and (optionally) Activity Groups in a way that can mirror your business organization. Once again, the use of Roles is entirely optional.

### User

Users are, of course, the folks you're trying to authorize.

### User Grant

User Grants are how you give Users permission to perform one or more Activities.

## Other Features

There are some other great features, including:

### Grant Auditing

Each time a User is granted permission to perform an Activity, you'll have an optional log entry that shows who granted the permission and when.

### Authorization Auditing

Each time an authorization check is performed, you'll have an optional log entry that shows all you'd want to know about the check including when it happened, who the user was, what Activity they were attempting to perform, and the check result (approved or denied).
