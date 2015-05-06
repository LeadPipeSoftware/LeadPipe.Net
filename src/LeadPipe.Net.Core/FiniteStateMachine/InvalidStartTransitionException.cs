// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidStartTransitionException.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.FiniteStateMachine
{
	using System;

	/// <summary>
	/// An base exception for the domain layer.
	/// </summary>
	[Serializable]
	public class InvalidStartTransitionException : Exception
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidStartTransitionException"/> class. 
		/// </summary>
		/// <param name="message">
		/// The exception message.
		/// </param>
		public InvalidStartTransitionException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidStartTransitionException"/> class.
		/// </summary>
		/// <param name="message">
		/// The exception message.
		/// </param>
		/// <param name="innerException">
		/// The inner exception.
		/// </param>
		public InvalidStartTransitionException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		#endregion
	}
}