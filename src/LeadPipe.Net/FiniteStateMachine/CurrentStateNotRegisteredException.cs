// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentStateNotRegisteredException.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.FiniteStateMachine
{
	/// <summary>
	/// An base exception for the domain layer.
	/// </summary>
	[Serializable]
	public class CurrentStateNotRegisteredException : Exception
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CurrentStateNotRegisteredException"/> class.
		/// </summary>
		public CurrentStateNotRegisteredException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CurrentStateNotRegisteredException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public CurrentStateNotRegisteredException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CurrentStateNotRegisteredException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public CurrentStateNotRegisteredException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CurrentStateNotRegisteredException"/> class.
		/// </summary>
		/// <param name="stateCode">The state code.</param>
		public CurrentStateNotRegisteredException(int stateCode)
			: base(stateCode.ToString().FormattedWith("The current state ({0}) was not found in the list of registered states in the state machine."))
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CurrentStateNotRegisteredException"/> class.
		/// </summary>
		/// <param name="stateCode">The state code.</param>
		/// <param name="innerException">The inner exception.</param>
		public CurrentStateNotRegisteredException(int stateCode, Exception innerException)
			: base(stateCode.ToString().FormattedWith("The current state ({0}) was not found in the list of registered states in the state machine."), innerException)
		{
		}

		#endregion
	}
}