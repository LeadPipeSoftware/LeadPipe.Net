// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFiniteStateTransition.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace LeadPipe.Net.FiniteStateMachine
{
	/// <summary>
	/// The finite state transition interface.
	/// </summary>
	public interface IFiniteStateTransition : IComparable
	{
		/// <summary>
		/// Gets or sets the transition code.
		/// </summary>
		/// <value>The code.</value>
		int Code { get; set; }

		/// <summary>
		/// Gets or sets the end state.
		/// </summary>
		/// <value>The end state.</value>
		IFiniteState EndState { get; set; }

		/// <summary>
		/// Gets the transition failure message.
		/// </summary>
		/// <value>The failure message.</value>
		string FailureMessage { get; }

		/// <summary>
		/// Gets or sets the transition name.
		/// </summary>
		/// <value>The name.</value>
		string Name { get; set; }

		/// <summary>
		/// Gets or sets the transition reason.
		/// </summary>
		/// <value>The reason.</value>
		IFiniteStateMachineTransitionReason Reason { get; set; }

		/// <summary>
		/// Gets or sets the surrogate id.
		/// </summary>
		/// <value>The sid.</value>
		/// <remarks>This field is usually for persistence-related concerns.</remarks>
		Guid Sid { get; set; }

		/// <summary>
		/// Gets or sets the start state.
		/// </summary>
		/// <value>The start state.</value>
		IFiniteState StartState { get; set; }

		/// <summary>
		/// Gets a value indicating whether the transition succeeded.
		/// </summary>
		/// <value><c>true</c> if [transition succeeded]; otherwise, <c>false</c>.</value>
		bool TransitionSucceeded { get; }

		/// <summary>
		/// Gets or sets the persistence version.
		/// </summary>
		/// <value>The ver.</value>
		int Ver { get; set; }

		/// <summary>
		/// Gets a value indicating whether this instance can transition.
		/// </summary>
		/// <returns>True if the transition can take place. False otherwise.</returns>
		bool CanTransition();

		/// <summary>
		/// Transitions this instance.
		/// </summary>
		/// <returns>The transition result.</returns>
		IFiniteState Transition();
	}

	/// <summary>
	/// The finite state transition interface.
	/// </summary>
	/// <typeparam name="TTransitionData">The type of the transition data.</typeparam>
	public interface IFiniteStateTransition<TTransitionData> : IFiniteStateTransition
	{
		/// <summary>
		/// Gets the allowed transition reason codes.
		/// </summary>
		/// <value>The allowed transition reason codes.</value>
		IEnumerable<string> AllowedTransitionFromReasonCodes { get; }

		/// <summary>
		/// Gets a value indicating whether this instance can transition.
		/// </summary>
		/// <param name="transitionData">The transition data.</param>
		/// <returns>True if the transition can take place. False otherwise.</returns>
		bool CanTransition(TTransitionData transitionData);

		/// <summary>
		/// Transitions this instance.
		/// </summary>
		/// <param name="transitionData">The transition data.</param>
		/// <returns>The transition result.</returns>
		IFiniteState Transition(TTransitionData transitionData);
	}
}