// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DuplicateTransitionCodeException.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace LeadPipe.Net.FiniteStateMachine
{
	/// <summary>
	/// An base exception for the domain layer.
	/// </summary>
	[Serializable]
	public class DuplicateTransitionCodeException : Exception
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateTransitionCodeException"/> class.
		/// </summary>
		public DuplicateTransitionCodeException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateTransitionCodeException"/> class. 
		/// </summary>
		/// <param name="message">
		/// The exception message.
		/// </param>
		public DuplicateTransitionCodeException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateTransitionCodeException"/> class.
		/// </summary>
		/// <param name="message">
		/// The exception message.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		public DuplicateTransitionCodeException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateTransitionCodeException"/> class.
		/// </summary>
		/// <param name="transition">The transition.</param>
		public DuplicateTransitionCodeException(IFiniteStateTransition transition)
			: base(
				string.Format(
					CultureInfo.CurrentCulture, "The {0} transition's Code value is already in use.", transition.Name))
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateTransitionCodeException"/> class.
		/// </summary>
		/// <param name="transition">The transition.</param>
		/// <param name="innerException">The inner exception.</param>
		public DuplicateTransitionCodeException(IFiniteStateTransition transition, Exception innerException)
			: base(
				string.Format(
					CultureInfo.CurrentCulture, "The {0} transition's Code value is already in use.", transition.Name),
				innerException)
		{
		}

		#endregion
	}
}