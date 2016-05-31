// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainEvent.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Domain
{
	/// <summary>
	/// Defines a domain event.
	/// </summary>
	public abstract class DomainEvent : IDomainEventWithId
	{
		public DomainEvent()
		{
			DomainEventId = Guid.NewGuid();
		}

		public Guid DomainEventId { get; protected set; }
	}
}