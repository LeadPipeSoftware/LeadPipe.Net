// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FiniteStateMachineTransitionReason.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.FiniteStateMachine
{
	using System;

	using LeadPipe.Net.Core.Extensions;

	/// <summary>
	/// The finite reason machine transition reason.
	/// </summary>
	public class FiniteStateMachineTransitionReason : IFiniteStateMachineTransitionReason, IEquatable<FiniteStateMachineTransitionReason>
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateMachineTransitionReason" /> class.
		/// </summary>
		/// <param name="description">The description.</param>
		public FiniteStateMachineTransitionReason(string description)
		{
			this.Description = description;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateMachineTransitionReason" /> class.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="description">The description.</param>
		public FiniteStateMachineTransitionReason(string code, string description)
		{
			this.Code = code;
			this.Description = description;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateMachineTransitionReason" /> class.
		/// </summary>
		protected FiniteStateMachineTransitionReason()
		{
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the code.
		/// </summary>
		/// <value>The code.</value>
		public virtual string Code { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public virtual string Description { get; set; }

		#endregion

		#region Operators

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="reason1">The first domain object.</param>
		/// <param name="reason2">The second domain object.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(FiniteStateMachineTransitionReason reason1, FiniteStateMachineTransitionReason reason2)
		{
			object obj1 = reason1;
			object obj2 = reason2;

			if (obj1.IsNull() && obj2.IsNull())
			{
				return true;
			}

			if (obj1.IsNull() || obj2.IsNull())
			{
				return false;
			}

			if (reason1.GetType() != reason2.GetType())
			{
				return false;
			}

			return reason1.Code.CompareTo(reason2.Code) == 0;
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="reason1">The first domain object.</param>
		/// <param name="reason2">The second domain object.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(FiniteStateMachineTransitionReason reason1, FiniteStateMachineTransitionReason reason2)
		{
			return !(reason1 == reason2);
		}

		#endregion

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="obj" />. Zero This instance is equal to <paramref name="obj" />. Greater than zero This instance is greater than <paramref name="obj" />.</returns>
		public int CompareTo(object obj)
		{
			var reason = obj as IFiniteStateMachineTransitionReason;

			if (reason != null)
			{
				return this.CompareTo(reason);
			}

			return -1;
		}

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="reason">A reason to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="reason" />. Zero This instance is equal to <paramref name="reason" />. Greater than zero This instance is greater than <paramref name="reason" />.</returns>
		public int CompareTo(IFiniteStateMachineTransitionReason reason)
		{
			return this.Code.CompareTo(reason.Code);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
		public bool Equals(FiniteStateMachineTransitionReason other)
		{
			return this.Code.Equals(other.Code);
		}
	}
}