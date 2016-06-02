// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace LeadPipe.Net.FiniteStateMachine
{
    /// <summary>
    /// A simplified finite state machine.
    /// </summary>
    /// <typeparam name="TStateName">The type of the state name (usually an enum).</typeparam>
    /// <typeparam name="TState">The type of the state.</typeparam>
    public abstract class SimpleFiniteStateMachine<TStateName, TState> where TState : SimpleFiniteState<TStateName>
    {
        protected TStateName initialStateName;
        protected Dictionary<TStateName, TState> states = new Dictionary<TStateName, TState>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleFiniteStateMachine{TStateName, TState}"/> class.
        /// </summary>
        public SimpleFiniteStateMachine(TStateName initialStateName)
        {
            History = new FiniteStateMachineHistory<SimpleFiniteStateMachineHistoryEntry<TStateName>>();

            InitializeStates();

            this.initialStateName = initialStateName;

            PerformTransition(initialStateName);
        }

        /// <summary>
        /// Gets or sets the history.
        /// </summary>
        /// <value>The history.</value>
        public virtual IFiniteStateMachineHistory<SimpleFiniteStateMachineHistoryEntry<TStateName>> History { get; protected set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public TStateName Status { get; protected set; }

        /// <summary>
        /// Determines whether this instance [can transition to] the specified state name.
        /// </summary>
        /// <param name="stateName">Name of the state.</param>
        /// <returns></returns>
        public virtual bool CanTransitionTo(TStateName stateName)
        {
            return IsValidTransition(Status, stateName);
        }

        /// <summary>
        /// Determines whether [is valid transition] [the specified current].
        /// </summary>
        /// <param name="current">The current.</param>
        /// <param name="next">The next.</param>
        /// <returns></returns>
        public virtual bool IsValidTransition(TStateName current, TStateName next)
        {
            var currentState = states[current];
            var nextState = states[next];

            return currentState.CanTransition(nextState) || currentState.CanReverseTransition(nextState);
        }

        /// <summary>
        /// Performs the transition.
        /// </summary>
        /// <param name="stateName">Name of the state.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        public virtual bool PerformTransition(TStateName stateName, string reason = null, string comment = null)
        {
            // If there are NOT history entries and we're dealing with the initial state then proceed...
            if (!History.Entries.Any() && stateName.Equals(initialStateName))
            {
                Status = stateName;

                var historyEntry = BuildHistoryEntry(Status, reason, comment);

                History.AddEntry(historyEntry);
            }
            else // Otherwise (we do have entries or we're NOT dealing with the initial state then...
            {
                if (!IsValidTransition(Status, stateName))
                {
                    return false;
                }

                Status = stateName;

                var historyEntry = BuildHistoryEntry(Status, reason, comment);

                History.AddEntry(historyEntry);
            }

            return true;
        }

        /// <summary>
        /// Adds the history entry.
        /// </summary>
        /// <param name="newStateName">New name of the state.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="comments">The comments.</param>
        /// <returns>
        /// A built-up history entry.
        /// </returns>
        protected abstract SimpleFiniteStateMachineHistoryEntry<TStateName> BuildHistoryEntry(TStateName newStateName, string reason, string comments);

        /// <summary>
        /// Initializes the states.
        /// </summary>
        protected abstract void InitializeStates();
    }
}