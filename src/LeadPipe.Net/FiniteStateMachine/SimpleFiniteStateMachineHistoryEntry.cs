// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.FiniteStateMachine
{
    /// <summary>
    /// The simple finite state machine history entry.
    /// </summary>
    public class SimpleFiniteStateMachineHistoryEntry<TStateName> : IFiniteStateMachineHistoryEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FiniteStateMachineHistoryEntry" /> class.
        /// </summary>
        /// <param name="entryNumber">The entry number.</param>
        /// <param name="stateName">Name of the state.</param>
        /// <param name="reasonCode">The reason code.</param>
        public SimpleFiniteStateMachineHistoryEntry(int entryNumber, TStateName stateName, string reasonCode)
        {
            this.EntryNumber = entryNumber;
            this.StateName = stateName;
            this.ReasonCode = reasonCode;

            this.EntryDate = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FiniteStateMachineHistoryEntry"/> class.
        /// </summary>
        /// <param name="entryNumber">The entry number.</param>
        /// <param name="stateCode">The state code.</param>
        /// <param name="reasonCode">The reason code.</param>
        /// <param name="comments">The comments.</param>
        public SimpleFiniteStateMachineHistoryEntry(
            int entryNumber,
            TStateName stateName,
            string reasonCode,
            string comments)
            : this(entryNumber, stateName, reasonCode)
        {
            this.Comments = comments;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FiniteStateMachineHistoryEntry"/> class.
        /// </summary>
        public SimpleFiniteStateMachineHistoryEntry()
        {
        }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public virtual string Comments { get; set; }

        /// <summary>
        /// Gets or sets the entry date.
        /// </summary>
        public virtual DateTime EntryDate { get; set; }

        /// <summary>
        /// Gets or sets the entry number.
        /// </summary>
        public virtual int EntryNumber { get; set; }

        /// <summary>
        /// Gets or sets the executed by name.
        /// </summary>
        public virtual string ExecutedBy { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public virtual string Owner { get; set; }

        /// <summary>
        /// Gets or sets the reason code.
        /// </summary>
        public virtual string ReasonCode { get; set; }

        /// <summary>
        /// Gets or sets the reason description.
        /// </summary>
        /// <value>
        /// The reason description.
        /// </value>
        public virtual string ReasonDescription { get; set; }

        /// <summary>
        /// Gets or sets the surrogate id.
        /// </summary>
        /// <remarks>
        /// This field is usually for persistence-related concerns.
        /// </remarks>
        public virtual Guid Sid { get; set; }

        /// <summary>
        /// Gets or sets the state code.
        /// </summary>
        public int StateCode { get; set; }

        /// <summary>
        /// Gets or sets the state name.
        /// </summary>
        public virtual TStateName StateName { get; set; }
    }
}