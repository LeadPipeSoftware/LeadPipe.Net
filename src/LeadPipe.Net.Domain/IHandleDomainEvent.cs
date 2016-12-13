// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
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