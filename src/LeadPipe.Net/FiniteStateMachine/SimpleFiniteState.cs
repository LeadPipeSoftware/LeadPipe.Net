// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleFiniteState.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace LeadPipe.Net.FiniteStateMachine
{
	/// <summary>
	/// A simplified finite state.
	/// </summary>
	/// <typeparam name="TStateName">The type of the state name (usually an enum).</typeparam>
	public class SimpleFiniteState<TStateName>
	{
		/// <summary>
		/// Gets or sets the code.
		/// </summary>
		/// <value>The code.</value>
		public virtual int Code { get; set; }

		/// <summary>
		/// Gets or sets the name of the state.
		/// </summary>
		/// <value>
		/// The state name.
		/// </value>
		public TStateName Name { get; set; }

		/// <summary>
		/// Gets or sets the forward transitions.
		/// </summary>
		/// <value>
		/// The forward transitions.
		/// </value>
		public virtual HashSet<SimpleFiniteState<TStateName>> ForwardTransitions { get; protected set; }

		/// <summary>
		/// Gets or sets the reverse transitions.
		/// </summary>
		/// <value>
		/// The reverse transitions.
		/// </value>
		public virtual HashSet<SimpleFiniteState<TStateName>> ReverseTransitions { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SimpleFiniteState{TStatus}"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="forwardTransitions">The forward transitions.</param>
		/// <param name="reverseTransitions">The reverse transitions.</param>
		public SimpleFiniteState(TStateName status, HashSet<SimpleFiniteState<TStateName>> forwardTransitions, HashSet<SimpleFiniteState<TStateName>> reverseTransitions = null)
		{
			Name = status;
			ForwardTransitions = forwardTransitions;
			ReverseTransitions = reverseTransitions ?? new HashSet<SimpleFiniteState<TStateName>>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SimpleFiniteState{TStatus}"/> class.
		/// </summary>
		/// <param name="status">The status.</param>
		public SimpleFiniteState(TStateName status)
		{
			Name = status;
			ForwardTransitions = new HashSet<SimpleFiniteState<TStateName>>();
			ReverseTransitions = new HashSet<SimpleFiniteState<TStateName>>();
		}

		/// <summary>
		/// Adds the transition.
		/// </summary>
		/// <param name="state">The state.</param>
		public void AddTransition(SimpleFiniteState<TStateName> state)
		{
			ForwardTransitions.Add(state);
		}

		/// <summary>
		/// Adds the reverse transition.
		/// </summary>
		/// <param name="state">The state.</param>
		public void AddReverseTransition(SimpleFiniteState<TStateName> state)
		{
			ReverseTransitions.Add(state);
		}

		/// <summary>
		/// Determines whether this instance can transition the specified state.
		/// </summary>
		/// <param name="state">The state.</param>
		/// <returns>True if the transition can occur.</returns>
		public virtual bool CanTransition(SimpleFiniteState<TStateName> state)
		{
			return ForwardTransitions.Contains(state);
		}

		/// <summary>
		/// Determines whether this instance can reverse transition to the specified state.
		/// </summary>
		/// <param name="state">The state.</param>
		/// <returns>True if the transition can occur.</returns>
		public virtual bool CanReverseTransition(SimpleFiniteState<TStateName> state)
		{
			return ReverseTransitions.Contains(state);
		}
	}
}