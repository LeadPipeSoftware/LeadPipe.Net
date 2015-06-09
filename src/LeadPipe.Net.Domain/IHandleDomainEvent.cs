// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHandleDomainEvent.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
	/// <summary>
	/// The interface for objects that handle domain events.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IHandleDomainEvent<T> where T : IDomainEvent
	{
		/// <summary>
		/// Handles the domain event.
		/// </summary>
		/// <param name="args">The event arguments.</param>
		void Handle(T args);
	}
}