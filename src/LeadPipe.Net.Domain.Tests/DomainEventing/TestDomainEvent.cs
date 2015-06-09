// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestDomainEvent.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain.Tests.DomainEventing
{
	/// <summary>
	/// A test domain event class.
	/// </summary>
	public class TestDomainEvent : IDomainEvent
	{
		/// <summary>
		/// Gets or sets the new name.
		/// </summary>
		/// <value>The new name.</value>
		public string NewName { get; set; }
	}
}