// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFiniteStateMachine.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace LeadPipe.Net.FiniteStateMachine
{
	/// <summary>
	/// The finite state machine interface.
	/// </summary>
	/// <typeparam name="THistoryEntry">The type of the history entry.</typeparam>
	public interface IFiniteStateMachine<THistoryEntry>
		where THistoryEntry : IFiniteStateMachineHistoryEntry
	{
		#region Public Properties

		/// <summary>
		/// Gets all of the registered transitions.
		/// </summary>
		IEnumerable<IFiniteStateTransition> AllTransitions { get; }

		/// <summary>
		/// Gets the executable transitions.
		/// </summary>
		IEnumerable<IFiniteStateTransition> AvailableTransitions { get; }

		/// <summary>
		/// Gets the current state.
		/// </summary>
		IFiniteState CurrentState { get; }

		/// <summary>
		/// Gets the current transition reason.
		/// </summary>
		IFiniteStateMachineTransitionReason CurrentTransitionReason { get; }

		/// <summary>
		/// Gets the available transitions.
		/// </summary>
		IEnumerable<IFiniteStateTransition> CurrentTransitions { get; }

		/// <summary>
		/// Gets the finite state machine history.
		/// </summary>
		IFiniteStateMachineHistory<THistoryEntry> History { get; }

		/// <summary>
		/// Gets or sets the surrogate id.
		/// </summary>
		/// <remarks>
		/// This field is usually for persistence-related concerns.
		/// </remarks>
		Guid Sid { get; set; }

		/// <summary>
		/// Gets or sets the state of the starting.
		/// </summary>
		IFiniteState StartingState { get; set; }

		/// <summary>
		/// Gets or sets the starting transition.
		/// </summary>
		IFiniteStateTransition StartingTransition { get; set; }

		/// <summary>
		/// Gets the registered states.
		/// </summary>
		IEnumerable<IFiniteState> States { get; }

		/// <summary>
		/// Gets or sets the persistence version.
		/// </summary>
		int Ver { get; set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Performs the transition.
		/// </summary>
		/// <param name="transitionCode">
		/// The transition code.
		/// </param>
		void PerformTransition(int transitionCode);

		/// <summary>
		/// Performs the transition.
		/// </summary>
		/// <param name="transition">
		/// The transition.
		/// </param>
		/// <param name="comment">
		/// The comment.
		/// </param>
		void PerformTransition(IFiniteStateTransition transition, string comment = null);

		/// <summary>
		/// Registers a state.
		/// </summary>
		/// <param name="state">
		/// The state to register.
		/// </param>
		void RegisterState(IFiniteState state);

		/// <summary>
		/// Removes a state.
		/// </summary>
		/// <param name="state">
		/// The state to remove.
		/// </param>
		void RemoveState(IFiniteState state);

		#endregion
	}
}