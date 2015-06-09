// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAggregateRoot.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
	/// <summary>
	/// A marker interface that indicates an Entity is an Aggregate Root. Usage is completely optional.
	/// </summary>
	/// <remarks>Page 125 - Evans, Eric. Domain Driven Design. 2004. Addison-Wesley. March 2009</remarks>
	public interface IAggregateRoot : IEntity
	{
	}
}