// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FiniteStateMachine.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.FiniteStateMachine
{
	/// <summary>
	/// The finite state machine.
	/// </summary>
	/// <typeparam name="THistoryEntry">The type of the history entry.</typeparam>
	public abstract class FiniteStateMachine<THistoryEntry> : IFiniteStateMachine<THistoryEntry>
		where THistoryEntry : IFiniteStateMachineHistoryEntry, new()
	{
		/// <summary>
		/// The registered states.
		/// </summary>
		private readonly IList<IFiniteState> registeredStates = new List<IFiniteState>();

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateMachine{THistoryEntry}" /> class.
		/// Initializes a new instance of the <see cref="FiniteStateMachine&lt;THistoryEntry&gt;" /> class.
		/// </summary>
		/// <param name="startingState">State of the starting.</param>
		protected FiniteStateMachine(IFiniteState startingState)
		{
			this.History = new FiniteStateMachineHistory<THistoryEntry>();

			this.StartingState = startingState;

			// Create our start transition...
			this.StartingTransition = new FiniteStateTransition(0, "New", new FiniteStateMachineTransitionReason("New", "New"), this.StartingState);

			this.Initialize();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateMachine{THistoryEntry}" /> class.
		/// Initializes a new instance of the <see cref="FiniteStateMachine&lt;THistoryEntry&gt;" /> class.
		/// </summary>
		/// <param name="startingTransition">The starting transition.</param>
		protected FiniteStateMachine(IFiniteStateTransition startingTransition)
		{
			this.History = new FiniteStateMachineHistory<THistoryEntry>();

			this.StartingTransition = startingTransition;

			this.StartingState = this.StartingTransition.EndState;

			this.Initialize();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateMachine{THistoryEntry}" /> class.
		/// Initializes a new instance of the <see cref="FiniteStateMachine&lt;THistoryEntry&gt;" /> class.
		/// </summary>
		protected FiniteStateMachine()
		{
		}

		/// <summary>
		/// The state changed event handler.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The instance containing the event data.</param>
		public delegate void StateChangedEventHandler(object sender, StateChangedEventArgs e);

		/// <summary>
		/// Occurs when [state changed].
		/// </summary>
		public virtual event StateChangedEventHandler StateChanged;

		/// <summary>
		/// Gets all transitions.
		/// </summary>
		/// <value>All transitions.</value>
		public virtual IEnumerable<IFiniteStateTransition> AllTransitions
		{
			get
			{
				return this.States.SelectMany(state => state.Transitions).ToList();
			}
		}

		/// <summary>
		/// Gets the executable transitions.
		/// </summary>
		/// <value>The available transitions.</value>
		public virtual IEnumerable<IFiniteStateTransition> AvailableTransitions
		{
			get
			{
				var availableTransitions = new List<IFiniteStateTransition>();

				foreach (var transition in this.CurrentTransitions)
				{
					// If the transition requires data then call our virtual members (the implementer MUST override), otherwise just do business as usual...
					if (TransitionRequiresTransitionData(transition))
					{
						if (this.CanTransition(transition))
						{
							availableTransitions.Add(transition);
						}
					}
					else
					{
						if (transition.CanTransition())
						{
							availableTransitions.Add(transition);
						}
					}
				}

				return availableTransitions;
			}
		}

		/// <summary>
		/// Gets the current state.
		/// </summary>
		/// <value>The state of the current.</value>
		public virtual IFiniteState CurrentState
		{
			get
			{
				var stateCode = this.History.MostRecentEntry.StateCode;
				var currentState = this.States.SingleOrDefault(x => x.Code == stateCode);

				if (currentState == null)
				{
					throw new CurrentStateNotRegisteredException(stateCode);
				}

				return currentState;
			}
		}

		/// <summary>
		/// Gets the current transition reason.
		/// </summary>
		/// <value>The current transition reason.</value>
		public virtual IFiniteStateMachineTransitionReason CurrentTransitionReason
		{
			get
			{
				var reasonCode = this.History.MostRecentEntry.ReasonCode;

				IFiniteStateMachineTransitionReason reason = null;

				foreach (var transition in from state in this.States from transition in state.Transitions where transition.Reason.Code == reasonCode select transition)
				{
					reason = transition.Reason;
				}

				if (reason == null)
				{
					throw new CurrentReasonNotRegisteredException(reasonCode);
				}

				return reason;
			}
		}

		/// <summary>
		/// Gets the transitions for the current state.
		/// </summary>
		/// <value>The current transitions.</value>
		public virtual IEnumerable<IFiniteStateTransition> CurrentTransitions
		{
			get
			{
				return this.CurrentState.Transitions.AsEnumerable();
			}
		}

		/// <summary>
		/// Gets or sets the history.
		/// </summary>
		/// <value>The history.</value>
		public virtual IFiniteStateMachineHistory<THistoryEntry> History { get; protected set; }

		/// <summary>
		/// Gets or sets the surrogate id.
		/// </summary>
		/// <value>The sid.</value>
		/// <remarks>This field is usually for persistence-related concerns.</remarks>
		public virtual Guid Sid { get; set; }

		/// <summary>
		/// Gets or sets the state of the starting.
		/// </summary>
		/// <value>The state of the starting.</value>
		public virtual IFiniteState StartingState { get; set; }

		/// <summary>
		/// Gets or sets the starting transition.
		/// </summary>
		/// <value>The starting transition.</value>
		public virtual IFiniteStateTransition StartingTransition { get; set; }

		/// <summary>
		/// Gets the states.
		/// </summary>
		/// <value>The states.</value>
		public virtual IEnumerable<IFiniteState> States
		{
			get
			{
				return this.registeredStates.AsEnumerable();
			}
		}

		/// <summary>
		/// Gets or sets the persistence version.
		/// </summary>
		/// <value>The ver.</value>
		public virtual int Ver { get; set; }

		/// <summary>
		/// Gets the last transition.
		/// </summary>
		/// <returns>A IFiniteStateTransition.</returns>
		public virtual IFiniteStateTransition GetLastTransition()
		{
			var previousHistoryEntry = this.History.Entries.LastOrDefault();
			if (previousHistoryEntry != null)
			{
				return this.AllTransitions.FirstOrDefault(x => x.Reason.Code == previousHistoryEntry.ReasonCode);
			}

			return null;
		}

		/// <summary>
		/// Performs the transition.
		/// </summary>
		/// <param name="transitionCode">The transition code.</param>
		public virtual void PerformTransition(int transitionCode)
		{
			// Look up the transition...
			var transition = this.CurrentState.Transitions.SingleOrDefault(x => x.Code == transitionCode);

			// If we don't have a matching transition then throw...
			if (transition.IsNull())
			{
				throw new TransitionNotAvailableException(string.Format(CultureInfo.CurrentCulture, "The transition with a Code value of {0} is not available in the {1} state.", transitionCode, this.CurrentState.Name));
			}

			this.PerformTransition(transition);
		}

		/// <summary>
		/// Performs the transition.
		/// </summary>
		/// <param name="transition">The transition.</param>
		/// <param name="comment">The comment.</param>
		public virtual void PerformTransition(IFiniteStateTransition transition, string comment = null)
		{
			Guard.Will.ProtectAgainstNullArgument(() => transition);

			// If the requested transition is not available then...
			var hasTransition = this.CurrentState.Transitions.FirstOrDefault(x => x.Code == transition.Code) != null;
			if (!hasTransition)
			{
				throw new TransitionNotAvailableException(transition, this.CurrentState);
			}

			Guard.Will.ThrowException("The transition does not have an end state.").When(transition.EndState.IsNull());

			IFiniteState transitionResult;

			// If the transition requires data then call our virtual members (the implementer MUST override), otherwise just do business as usual...
			if (TransitionRequiresTransitionData(transition))
			{
				if (!this.CanTransition(transition))
				{
					throw new ApplicationException("The transition cannot be executed.");
				}

				transitionResult = this.Transition(transition);
			}
			else
			{
				if (!transition.CanTransition())
				{
					throw new ApplicationException("The transition cannot be executed.");
				}

				transitionResult = transition.Transition();
			}

			// If the transition failed then pop...
			if (!transition.TransitionSucceeded)
			{
				if (string.IsNullOrEmpty(transition.FailureMessage))
				{
					throw new ApplicationException("The transition failed. No failure message was provided by the transition.");
				}

				throw new ApplicationException(transition.FailureMessage.FormattedWith("The transition failed. {0}"));
			}

			// If the transition returned a state that isn't in our list of states then...
			if (!this.States.Contains(transitionResult))
			{
				throw new StateNotRegisteredException(transition, transitionResult);
			}

			// Write the transition to the history...
			var historyEntry = this.BuildHistoryEntry(transition, transitionResult, comment);
			this.History.AddEntry(historyEntry);

			// Raise the state changed event...
			this.OnStateChanged(new StateChangedEventArgs(transition, transitionResult, comment));
		}

		/// <summary>
		/// Registers a state.
		/// </summary>
		/// <param name="state">The state to register.</param>
		public virtual void RegisterState(IFiniteState state)
		{
			// If that state has already been registered then throw...
			if (this.registeredStates.Contains(state))
			{
				throw new StateAlreadyRegisteredException(state);
			}

			// If it's not the same state, but the Code value is already in use then throw...
			if (this.registeredStates.Any(x => x.Code == state.Code))
			{
				throw new DuplicateStateCodeException(state);
			}

			this.registeredStates.Add(state);
		}

		/// <summary>
		/// Removes a state.
		/// </summary>
		/// <param name="state">The state to remove.</param>
		public virtual void RemoveState(IFiniteState state)
		{
			if (!this.registeredStates.Contains(state))
			{
				return;
			}

			if (this.CurrentState == state)
			{
				throw new StateInUseException(state);
			}

			this.registeredStates.Remove(state);
		}

		/// <summary>
		/// Tries the state of the get transition in any.
		/// </summary>
		/// <typeparam name="T">The type of transition to find</typeparam>
		/// <param name="transition">The transition.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
		public virtual bool TryGetTransitionInAnyState<T>(out IFiniteStateTransition transition) where T : IFiniteStateTransition
		{
			foreach (var finiteState in this.States)
			{
				if (this.TryGetTransitionInState<T>(finiteState, out transition))
				{
					return true;
				}
			}

			transition = null;
			return false;
		}

		/// <summary>
		/// Tries the name of the get transition in any state by.
		/// </summary>
		/// <param name="transitionName">Name of the transition.</param>
		/// <param name="transition">The transition.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
		public virtual bool TryGetTransitionInAnyStateByName(string transitionName, out IFiniteStateTransition transition)
		{
			foreach (var finiteState in this.States)
			{
				transition = finiteState.GetTransitionByName(transitionName);
				if (transition != null)
				{
					return true;
				}
			}

			transition = null;
			return false;
		}

		/// <summary>
		/// Tries to get the IFiniteStateTransition by type in the current state.
		/// </summary>
		/// <typeparam name="T">The type of transition</typeparam>
		/// <param name="transition">The transition.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
		public virtual bool TryGetTransitionInCurrentState<T>(out IFiniteStateTransition transition) where T : IFiniteStateTransition
		{
			return this.TryGetTransitionInState<T>(this.CurrentState, out transition);
		}

		/// <summary>
		/// Tries the name of the get transition in current state by.
		/// </summary>
		/// <param name="transitionName">Name of the transition.</param>
		/// <param name="transition">The transition.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
		public virtual bool TryGetTransitionInCurrentStateByName(string transitionName, out IFiniteStateTransition transition)
		{
			transition = this.CurrentState.GetTransitionByName(transitionName);
			return transition != null;
		}

		/// <summary>
		/// Called after the finite state machine is initialized.
		/// </summary>
		protected virtual void AfterInitialize()
		{
		}

		/// <summary>
		/// Called before the finite state machine is initialized.
		/// </summary>
		protected virtual void BeforeInitialize()
		{
		}

		/// <summary>
		/// Adds the history entry.
		/// </summary>
		/// <param name="transition">The transition.</param>
		/// <param name="transitionResult">The transition result.</param>
		/// <param name="comments">The comments.</param>
		/// <returns>A built-up history entry.</returns>
		protected abstract THistoryEntry BuildHistoryEntry(IFiniteStateTransition transition, IFiniteState transitionResult, string comments);

		/// <summary>
		/// Determines whether this instance can transition.
		/// </summary>
		/// <param name="transition">The transition.</param>
		/// <returns><c>true</c> if this instance can transition; otherwise, <c>false</c>.</returns>
		protected virtual bool CanTransition(IFiniteStateTransition transition)
		{
			throw new ApplicationException("This finite state machine has one or more transitions that require transition data. You must override CanTransition() in your implementation.");
		}

		/// <summary>
		/// Initializes finite state machine.
		/// </summary>
		protected virtual void Initialize()
		{
			this.BeforeInitialize();

			this.InitializeHistory();

			this.AfterInitialize();
		}

		/// <summary>
		/// Initializes the history.
		/// </summary>
		protected abstract void InitializeHistory();

		/// <summary>
		/// Raises the <see cref="E:StateChanged" /> event.
		/// </summary>
		/// <param name="e">The instance containing the event data.</param>
		protected virtual void OnStateChanged(StateChangedEventArgs e)
		{
			if (this.StateChanged != null)
			{
				this.StateChanged(this, e);
			}
		}

		/// <summary>
		/// Transitions to a new state.
		/// </summary>
		/// <param name="transition">The transition.</param>
		/// <returns>The resulting state.</returns>
		protected virtual IFiniteState Transition(IFiniteStateTransition transition)
		{
			throw new ApplicationException("This finite state machine has one or more transitions that require transition data. You must override Transition() in your implementation.");
		}

		/// <summary>
		/// Tries the state of the get transition in.
		/// </summary>
		/// <typeparam name="T">The type of transition to find</typeparam>
		/// <param name="state">The state.</param>
		/// <param name="transition">The transition.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
		protected virtual bool TryGetTransitionInState<T>(IFiniteState state, out IFiniteStateTransition transition) where T : IFiniteStateTransition
		{
			transition = state.Transitions.OfType<T>().FirstOrDefault();
			return transition != null;
		}

		/// <summary>
		/// Determines if a transition requires transition data.
		/// </summary>
		/// <param name="transition">The transition.</param>
		/// <returns>True if the transition requires transition data. False otherwise.</returns>
		private static bool TransitionRequiresTransitionData(IFiniteStateTransition transition)
		{
			var requiresTransitionData = transition.GetType().GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IFiniteStateTransition<>));

			return requiresTransitionData;
		}
	}

	/// <summary>
	/// The finite state machine.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "GBM: Suppression is OK here.")]
	public class FiniteStateMachine : FiniteStateMachine<FiniteStateMachineHistoryEntry>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateMachine" /> class.
		/// </summary>
		/// <param name="startingState">State of the starting.</param>
		public FiniteStateMachine(IFiniteState startingState)
			: base(startingState)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateMachine" /> class.
		/// </summary>
		/// <param name="startingTransition">The starting transition.</param>
		public FiniteStateMachine(IFiniteStateTransition startingTransition)
			: base(startingTransition)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateMachine" /> class.
		/// </summary>
		protected FiniteStateMachine()
		{
		}

		/// <summary>
		/// Builds the history entry.
		/// </summary>
		/// <param name="transition">The transition.</param>
		/// <param name="transitionResult">The transition result.</param>
		/// <param name="comments">The comments.</param>
		/// <returns>A built-up history entry.</returns>
		protected override FiniteStateMachineHistoryEntry BuildHistoryEntry(IFiniteStateTransition transition, IFiniteState transitionResult, string comments)
		{
			return new FiniteStateMachineHistoryEntry { Comments = comments, ReasonCode = transition.Reason.Code, ReasonDescription = transition.Reason.Description, StateCode = transitionResult.Code, StateName = transitionResult.Name };
		}

		/// <summary>
		/// Initializes the history.
		/// </summary>
		protected override void InitializeHistory()
		{
			if (this.History == null)
			{
				throw new ApplicationException("The finite state machine history is null. Check to make sure that the history was initialized.");
			}

			// Don't bother writing the initial record if there are already entries...
			if (this.History.Entries.Any())
			{
				return;
			}

			// Write our initial record...
			var initialHistoryEntry = new FiniteStateMachineHistoryEntry { StateCode = this.StartingTransition.EndState.Code, ReasonCode = this.StartingTransition.Reason.Code };

			this.History.AddEntry(initialHistoryEntry);
		}
	}
}