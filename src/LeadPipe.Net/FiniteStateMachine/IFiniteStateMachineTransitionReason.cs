// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.FiniteStateMachine
{
    /// <summary>
    /// The finite state machine transition reason.
    /// </summary>
    public interface IFiniteStateMachineTransitionReason : IComparable
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }
    }
}