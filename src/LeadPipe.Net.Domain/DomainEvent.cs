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
    public abstract class DomainEvent : IDomainEventWithId
    {
        /// <summary>
        /// Initializes a new instance of DomainEvent.
        /// </summary>
        public DomainEvent()
        {
            DomainEventId = Guid.NewGuid();
        }

        /// <summary>
        /// The domain event id.
        /// </summary>
        public Guid DomainEventId { get; protected set; }
    }
}