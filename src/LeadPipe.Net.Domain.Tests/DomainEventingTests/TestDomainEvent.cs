// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain.Tests.DomainEventingTests
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