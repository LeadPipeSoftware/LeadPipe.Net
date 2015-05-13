// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleFiniteStateMachine.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace LeadPipe.Net.FiniteStateMachine
{
	/// <summary>
	/// A simplified finite state machine.
	/// </summary>
	/// <typeparam name="TStateName">The type of the state name (usually an enum).</typeparam>
	/// <typeparam name="TState">The type of the state.</typeparam>
	public abstract class SimpleFiniteStateMachine<TStateName, TState> where TState : SimpleFiniteState<TStateName>
	{
		protected Dictionary<TStateName, TState> states = new Dictionary<TStateName, TState>();

		public TStateName Status { get; protected set; }

		protected abstract void InitializeStates();

		public virtual bool CanTransitionTo(TStateName stateName)
		{
			return IsValidTransition(Status, stateName);
		}

		public virtual bool IsValidTransition(TStateName current, TStateName next)
		{
			var currentState = states[current];
			var nextState = states[next];

			return currentState.CanTransition(nextState) || currentState.CanReverseTransition(nextState);
		}

		public virtual bool PerformTransition(TStateName stateName)
		{
			if (!IsValidTransition(Status, stateName))
			{
				return false;
			}

			Status = stateName;

			return true;
		}
	}
}