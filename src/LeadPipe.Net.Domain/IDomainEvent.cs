// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
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