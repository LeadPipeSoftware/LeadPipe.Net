// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.FiniteStateMachine
{
    /// <summary>
    /// The finite state machine history entry.
    /// </summary>
    public interface IFiniteStateMachineHistoryEntry
    {
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        string Comments { get; set; }

        /// <summary>
        /// Gets or sets the entry date.
        /// </summary>
        DateTime EntryDate { get; set; }

        /// <summary>
        /// Gets or sets the entry number.
        /// </summary>
        int EntryNumber { get; set; }

        /// <summary>
        /// Gets or sets the executed by name.
        /// </summary>
        string ExecutedBy { get; set; }

        /// <summary>
        /// Gets or sets the reason code.
        /// </summary>
        string ReasonCode { get; set; }

        /// <summary>
        /// Gets or sets the surrogate id.
        /// </summary>
        /// <remarks>
        /// This field is usually for persistence-related concerns.
        /// </remarks>
        Guid Sid { get; set; }

        /// <summary>
        /// Gets or sets the state code.
        /// </summary>
        int StateCode { get; set; }
    }
}