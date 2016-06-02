// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
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