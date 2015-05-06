// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFiniteState.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.FiniteStateMachine
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// The finite state interface.
	/// </summary>
	public interface IFiniteState : IComparable
	{
		/// <summary>
		/// Gets or sets the code.
		/// </summary>
		/// <value>The code.</value>
		int Code { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		string Description { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		string Name { get; set; }

		/// <summary>
		/// Gets or sets the surrogate id.
		/// </summary>
		/// <value>The sid.</value>
		/// <remarks>This field is usually for persistence-related concerns.</remarks>
		Guid Sid { get; set; }

		/// <summary>
		/// Gets the state transitions.
		/// </summary>
		/// <value>The transitions.</value>
		IEnumerable<IFiniteStateTransition> Transitions { get; }

		/// <summary>
		/// Gets or sets the persistence version.
		/// </summary>
		/// <value>The ver.</value>
		int Ver { get; set; }

		/// <summary>
		/// Gets the name of the transition by.
		/// </summary>
		/// <param name="transitionName">Name of the transition.</param>
		/// <returns>A IFiniteStateTransition.</returns>
		IFiniteStateTransition GetTransitionByName(string transitionName);

		/// <summary>
		/// Registers a transition.
		/// </summary>
		/// <param name="transition">The transition.</param>
		void RegisterTransition(IFiniteStateTransition transition);

		/// <summary>
		/// Removes the transition.
		/// </summary>
		/// <param name="transition">The transition.</param>
		void RemoveTransition(IFiniteStateTransition transition);
	}
}