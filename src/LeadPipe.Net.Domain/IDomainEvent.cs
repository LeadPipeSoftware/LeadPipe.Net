// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDomainEvent.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Domain
{
	/// <summary>
	/// Defines a domain event.
	/// </summary>
	public interface IDomainEvent
	{
	}

	public interface IDomainEventWithId : IDomainEvent
	{
		Guid DomainEventId { get; }
	}
}