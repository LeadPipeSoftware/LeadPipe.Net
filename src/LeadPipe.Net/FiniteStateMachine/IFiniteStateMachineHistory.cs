// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace LeadPipe.Net.FiniteStateMachine
{
    /// <summary>
    /// The finite state machine history.
    /// </summary>
    /// <typeparam name="THistoryEntry">The type of the history entry.</typeparam>
    public interface IFiniteStateMachineHistory<THistoryEntry> where THistoryEntry : IFiniteStateMachineHistoryEntry
    {
        /// <summary>
        /// Gets or sets the entries sorted by entry number.
        /// </summary>
        IEnumerable<THistoryEntry> Entries { get; set; }

        /// <summary>
        /// Gets the most recent entry.
        /// </summary>
        THistoryEntry MostRecentEntry { get; }

        /// <summary>
        /// Gets or sets the surrogate id.
        /// </summary>
        /// <remarks>
        /// This field is usually for persistence-related concerns.
        /// </remarks>
        Guid Sid { get; set; }

        /// <summary>
        /// Adds an entry to the history.
        /// </summary>
        /// <param name="historyEntry">The history entry to add.</param>
        void AddEntry(THistoryEntry historyEntry);
    }
}