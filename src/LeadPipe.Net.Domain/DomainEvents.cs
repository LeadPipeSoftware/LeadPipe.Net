// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The domain eventing mechanism.
    /// </summary>
    /// <remarks>
    /// This approach is an adaptation of Udi Dahan's approach. This adaptation takes advantage of Local.Data to avoid
    /// ThreadStatic in a web context (see http://goo.gl/84E95). You can read more about Udi's approach on his blog at
    /// http://www.udidahan.com/2009/06/14/domain-events-salvation/.
    /// </remarks>
    public static class DomainEvents
    {
        /// <summary>
        /// The local data key for domain event actions.
        /// </summary>
        public const string DomainEventActionsKey = "LeadPipeDomainEventActions";

        /// <summary>
        /// Clears all callback actions.
        /// </summary>
        public static void Clear()
        {
            Local.Data[DomainEventActionsKey] = null;
        }

        /// <summary>
        /// Raises the specified domain event.
        /// </summary>
        /// <typeparam name="T">The domain event type.</typeparam>
        /// <param name="args">The domain event arguments.</param>
        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (Local.Data[DomainEventActionsKey] == null)
            {
                return;
            }

            // Pull the actions out as a list of delegates...
            var actions = Local.Data[DomainEventActionsKey] as List<Delegate>;

            // Do nothing if there are no delegates...
            if (actions == null)
            {
                return;
            }

            // Call each callback action registered to the event type...
            foreach (var action in actions.OfType<Action<T>>())
            {
                action(args);
            }
        }

        /// <summary>
        /// Registers the specified callback action for a given domain event.
        /// </summary>
        /// <typeparam name="T">The domain event.</typeparam>
        /// <param name="callbackAction">The callback action.</param>
        public static void Register<T>(Action<T> callbackAction) where T : IDomainEvent
        {
            // If we don't already have actions in local data then create a new list...
            if (Local.Data[DomainEventActionsKey] == null)
            {
                Local.Data[DomainEventActionsKey] = new List<Delegate>();
            }

            // Pull the actions out as a list of delegates...
            var actions = Local.Data[DomainEventActionsKey] as List<Delegate>;

            // If the cast was successful then add the new callback action...
            if (actions != null)
            {
                actions.Add(callbackAction);
            }

            // Stuff the list back into local data...
            Local.Data[DomainEventActionsKey] = actions;
        }

        /// <summary>
        /// Unregisters the specified callback action for a given domain event.
        /// </summary>
        /// <typeparam name="T">The domain event.</typeparam>
        /// <param name="callbackAction">The callback action.</param>
        public static void Unregister<T>(Action<T> callbackAction) where T : IDomainEvent
        {
            // If we don't already have actions in local data then create a new list...
            if (Local.Data[DomainEventActionsKey] == null)
            {
                Local.Data[DomainEventActionsKey] = new List<Delegate>();
            }

            // Pull the actions out as a list of delegates...
            var actions = Local.Data[DomainEventActionsKey] as List<Delegate>;

            // If the cast was successful then add the new callback action...
            if (actions != null)
            {
                actions.Remove(callbackAction);
            }

            // Stuff the list back into local data...
            Local.Data[DomainEventActionsKey] = actions;
        }
    }
}