// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FiniteStateTransition.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.FiniteStateMachine
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;

	using LeadPipe.Net.Core.Extensions;

	/// <summary>
	/// The finite state transition.
	/// </summary>
	public class FiniteStateTransition : IFiniteStateTransition, IEquatable<FiniteStateTransition>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateTransition" /> class.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="name">The name.</param>
		/// <param name="reason">The reason.</param>
		/// <param name="startState">The start state.</param>
		/// <param name="endState">The end state.</param>
		public FiniteStateTransition(int code, string name, IFiniteStateMachineTransitionReason reason, IFiniteState startState, IFiniteState endState)
		{
			this.Code = code;
			this.Name = name;
			this.Reason = reason;
			this.StartState = startState;
			this.EndState = endState;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateTransition" /> class.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="name">The name.</param>
		/// <param name="reason">The reason.</param>
		/// <param name="startState">The start state.</param>
		/// <param name="endState">The end state.</param>
		/// <param name="transition">The transition.</param>
		public FiniteStateTransition(int code, string name, IFiniteStateMachineTransitionReason reason, IFiniteState startState, IFiniteState endState, Func<IFiniteState> transition)
			: this(code, name, reason, startState, endState)
		{
			this.TransitionDelegate = transition;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateTransition" /> class.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="name">The name.</param>
		/// <param name="reason">The reason.</param>
		/// <param name="startState">The start state.</param>
		/// <param name="endState">The end state.</param>
		/// <param name="transition">The transition delegate.</param>
		/// <param name="canTransition">The can transition delegate.</param>
		public FiniteStateTransition(int code, string name, IFiniteStateMachineTransitionReason reason, IFiniteState startState, IFiniteState endState, Func<IFiniteState> transition, Func<bool> canTransition)
			: this(code, name, reason, startState, endState, transition)
		{
			this.CanTransitionDelegate = canTransition;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateTransition" /> class.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="name">The name.</param>
		/// <param name="reason">The reason.</param>
		/// <param name="endState">The end state.</param>
		/// <remarks>Use this constructor when building a transition intended for use as a starting transition.</remarks>
		public FiniteStateTransition(int code, string name, IFiniteStateMachineTransitionReason reason, IFiniteState endState)
		{
			this.Code = code;
			this.Name = name;
			this.Reason = reason;
			this.StartState = null;

			this.EndState = endState;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateTransition" /> class.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="name">The name.</param>
		/// <param name="reason">The reason.</param>
		/// <param name="endState">The end state.</param>
		/// <param name="transition">The transition.</param>
		public FiniteStateTransition(int code, string name, IFiniteStateMachineTransitionReason reason, IFiniteState endState, Func<IFiniteState> transition)
			: this(code, name, reason, endState)
		{
			this.TransitionDelegate = transition;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateTransition" /> class.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="name">The name.</param>
		/// <param name="reason">The reason.</param>
		/// <param name="endState">The end state.</param>
		/// <param name="transition">The transition.</param>
		/// <param name="canTransition">The can transition.</param>
		public FiniteStateTransition(int code, string name, IFiniteStateMachineTransitionReason reason, IFiniteState endState, Func<IFiniteState> transition, Func<bool> canTransition)
			: this(code, name, reason, endState, transition)
		{
			this.CanTransitionDelegate = canTransition;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateTransition" /> class.
		/// </summary>
		protected FiniteStateTransition()
		{
		}

		/// <summary>
		/// Occurs when [transition performed].
		/// </summary>
		public event EventHandler TransitionPerformed;

		/// <summary>
		/// Gets or sets the transition code.
		/// </summary>
		/// <value>The code.</value>
		public virtual int Code { get; set; }

		/// <summary>
		/// Gets or sets the end state.
		/// </summary>
		/// <value>The end state.</value>
		public virtual IFiniteState EndState { get; set; }

		/// <summary>
		/// Gets or sets the transition failure message.
		/// </summary>
		/// <value>The failure message.</value>
		public string FailureMessage { get; protected set; }

		/// <summary>
		/// Gets or sets the transition name.
		/// </summary>
		/// <value>The name.</value>
		public virtual string Name { get; set; }

		/// <summary>
		/// Gets or sets the transition reason.
		/// </summary>
		/// <value>The reason.</value>
		public virtual IFiniteStateMachineTransitionReason Reason { get; set; }

		/// <summary>
		/// Gets or sets the surrogate id.
		/// </summary>
		/// <value>The sid.</value>
		/// <remarks>This field is usually for persistence-related concerns.</remarks>
		public virtual Guid Sid { get; set; }

		/// <summary>
		/// Gets or sets the start state.
		/// </summary>
		/// <value>The start state.</value>
		public virtual IFiniteState StartState { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the transition succeeded.
		/// </summary>
		/// <value><c>true</c> if [transition succeeded]; otherwise, <c>false</c>.</value>
		public bool TransitionSucceeded { get; protected set; }

		/// <summary>
		/// Gets or sets the persistence version.
		/// </summary>
		/// <value>The ver.</value>
		public virtual int Ver { get; set; }

		/// <summary>
		/// Gets or sets the can transition delegate.
		/// </summary>
		/// <value>The can transition delegate.</value>
		protected virtual Func<bool> CanTransitionDelegate { get; set; }

		/// <summary>
		/// Gets or sets the transition delegate.
		/// </summary>
		/// <value>The transition delegate.</value>
		protected virtual Func<IFiniteState> TransitionDelegate { get; set; }

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="transition1">The first domain object.</param>
		/// <param name="transition2">The second domain object.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(FiniteStateTransition transition1, FiniteStateTransition transition2)
		{
			object obj1 = transition1;
			object obj2 = transition2;

			if (obj1.IsNull() && obj2.IsNull())
			{
				return true;
			}

			if (obj1.IsNull() || obj2.IsNull())
			{
				return false;
			}

			if (transition1.GetType() != transition2.GetType())
			{
				return false;
			}

			return transition1.Code.CompareTo(transition2.Code) == 0;
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="transition1">The first domain object.</param>
		/// <param name="transition2">The second domain object.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(FiniteStateTransition transition1, FiniteStateTransition transition2)
		{
			return !(transition1 == transition2);
		}

		/// <summary>
		/// Gets a value indicating whether this instance can transition.
		/// </summary>
		/// <returns>True if the transition can take place. False otherwise.</returns>
		public virtual bool CanTransition()
		{
			return this.CanTransitionDelegate.IsNull() || this.CanTransitionDelegate.Invoke();
		}

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="obj" />. Zero This instance is equal to <paramref name="obj" />. Greater than zero This instance is greater than <paramref name="obj" />.</returns>
		public int CompareTo(object obj)
		{
			var transition = obj as IFiniteStateTransition;

			if (transition != null)
			{
				return this.CompareTo(transition);
			}

			return -1;
		}

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="transition">A transition to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="transition" />. Zero This instance is equal to <paramref name="transition" />. Greater than zero This instance is greater than <paramref name="transition" />.</returns>
		public int CompareTo(IFiniteStateTransition transition)
		{
			return this.Code.CompareTo(transition.Code);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
		public bool Equals(FiniteStateTransition other)
		{
			return this.Code.Equals(other.Code);
		}

		/// <summary>
		/// Transitions this instance.
		/// </summary>
		/// <returns>The transition result.</returns>
		public virtual IFiniteState Transition()
		{
			this.TransitionSucceeded = true;

			this.OnTransitionPerformed(new EventArgs());

			// If we've been delegated, we'll let them do all the work otherwise we'll just return our end state...
			return this.TransitionDelegate.IsNotNull() ? this.TransitionDelegate.Invoke() : this.EndState;
		}

		/// <summary>
		/// Raises the <see cref="E:TransitionPerformed" /> event.
		/// </summary>
		/// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnTransitionPerformed(EventArgs e)
		{
			if (this.TransitionPerformed != null)
			{
				this.TransitionPerformed(this, e);
			}
		}
	}

	/// <summary>
	/// The finite state transition.
	/// </summary>
	/// <typeparam name="TTransitionData">The type of the transition data.</typeparam>
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "GBM: Suppression is OK here.")]
	public abstract class FiniteStateTransition<TTransitionData> : FiniteStateTransition, IFiniteStateTransition<TTransitionData>
	{
		/// <summary>
		/// Gets the allowed transition reason codes.
		/// </summary>
		/// <value>The allowed transition reason codes.</value>
		public abstract IEnumerable<string> AllowedTransitionFromReasonCodes { get; }

		/// <summary>
		/// Gets a value indicating whether this instance can transition.
		/// </summary>
		/// <param name="transitionData">The transition data.</param>
		/// <returns>True if the transition can take place. False otherwise.</returns>
		public abstract bool CanTransition(TTransitionData transitionData);

		/// <summary>
		/// Transitions this instance.
		/// </summary>
		/// <param name="transitionData">The transition data.</param>
		/// <returns>The transition result.</returns>
		public abstract IFiniteState Transition(TTransitionData transitionData);
	}
}