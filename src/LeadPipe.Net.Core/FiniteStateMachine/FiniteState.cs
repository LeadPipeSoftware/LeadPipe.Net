// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FiniteState.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.FiniteStateMachine
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using LeadPipe.Net.Core.Extensions;

	/// <summary>
	/// The finite state.
	/// </summary>
	public class FiniteState : IFiniteState, IEquatable<FiniteState>
	{
		#region Constants and Fields

		/// <summary>
		/// The state transitions.
		/// </summary>
		private readonly IList<IFiniteStateTransition> registeredTransitions = new List<IFiniteStateTransition>();

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteState" /> class.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="name">The name.</param>
		public FiniteState(int code, string name)
		{
			this.Code = code;
			this.Name = name;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteState" /> class.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="name">The name.</param>
		/// <param name="registeredTransitions">The transitions.</param>
		public FiniteState(int code, string name, IList<IFiniteStateTransition> registeredTransitions)
			: this(code, name)
		{
			this.registeredTransitions = registeredTransitions;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteState" /> class.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="name">The name.</param>
		/// <param name="description">The description.</param>
		public FiniteState(int code, string name, string description)
			: this(code, name)
		{
			this.Description = description;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteState" /> class.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="name">The name.</param>
		/// <param name="description">The description.</param>
		/// <param name="registeredTransitions">The transitions.</param>
		public FiniteState(int code, string name, string description, IList<IFiniteStateTransition> registeredTransitions)
			: this(code, name, description)
		{
			this.registeredTransitions = registeredTransitions;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteState" /> class.
		/// </summary>
		protected FiniteState()
		{
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the code.
		/// </summary>
		/// <value>The code.</value>
		public virtual int Code { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public virtual string Description { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public virtual string Name { get; set; }

		/// <summary>
		/// Gets or sets the surrogate id.
		/// </summary>
		/// <value>The sid.</value>
		/// <remarks>This field is usually for persistence-related concerns.</remarks>
		public virtual Guid Sid { get; set; }

		/// <summary>
		/// Gets the state transitions.
		/// </summary>
		/// <value>The transitions.</value>
		public virtual IEnumerable<IFiniteStateTransition> Transitions
		{
			get
			{
				return this.registeredTransitions.ToList().AsReadOnly();
			}
		}

		/// <summary>
		/// Gets or sets the persistence version.
		/// </summary>
		/// <value>The ver.</value>
		public virtual int Ver { get; set; }

		#endregion

		#region Operators

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="state1">The first domain object.</param>
		/// <param name="state2">The second domain object.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(FiniteState state1, FiniteState state2)
		{
			object obj1 = state1;
			object obj2 = state2;

			if (obj1.IsNull() && obj2.IsNull())
			{
				return true;
			}

			if (obj1.IsNull() || obj2.IsNull())
			{
				return false;
			}

			if (state1.GetType() != state2.GetType())
			{
				return false;
			}

			return state1.Code.CompareTo(state2.Code) == 0;
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="state1">The first domain object.</param>
		/// <param name="state2">The second domain object.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(FiniteState state1, FiniteState state2)
		{
			return !(state1 == state2);
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Gets the name of the transition by.
		/// </summary>
		/// <param name="transitionName">Name of the transition.</param>
		/// <returns>A IFiniteStateTransition.</returns>
		public virtual IFiniteStateTransition GetTransitionByName(string transitionName)
		{
			return this.Transitions.FirstOrDefault(x => x.Name == transitionName);
		}

		/// <summary>
		/// Registers a transition.
		/// </summary>
		/// <param name="transition">The transition.</param>
		public virtual void RegisterTransition(IFiniteStateTransition transition)
		{
			if (this.registeredTransitions.Contains(transition))
			{
				throw new TransitionAlreadyRegisteredException(this, transition);
			}

			// If it's not the same transition, but the Code value is already in use then throw...
			if (this.registeredTransitions.Any(x => x.Code == transition.Code))
			{
				throw new DuplicateTransitionCodeException(transition);
			}

			this.registeredTransitions.Add(transition);
		}

		/// <summary>
		/// Removes the transition.
		/// </summary>
		/// <param name="transition">The transition.</param>
		public virtual void RemoveTransition(IFiniteStateTransition transition)
		{
			if (this.registeredTransitions.Contains(transition))
			{
				this.registeredTransitions.Remove(transition);
			}
		}

		#endregion

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="obj" />. Zero This instance is equal to <paramref name="obj" />. Greater than zero This instance is greater than <paramref name="obj" />.</returns>
		public int CompareTo(object obj)
		{
			var state = obj as IFiniteState;

			if (state != null)
			{
				return this.CompareTo(state);
			}

			return -1;
		}

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="state">A state to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="state" />. Zero This instance is equal to <paramref name="state" />. Greater than zero This instance is greater than <paramref name="state" />.</returns>
		public int CompareTo(IFiniteState state)
		{
			return this.Code.CompareTo(state.Code);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
		public bool Equals(FiniteState other)
		{
			return this.Code.Equals(other.Code);
		}
	}
}