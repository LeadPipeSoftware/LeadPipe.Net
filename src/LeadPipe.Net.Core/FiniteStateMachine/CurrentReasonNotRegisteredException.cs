// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentReasonNotRegisteredException.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.FiniteStateMachine
{
	using System;

	using LeadPipe.Net.Core.Extensions;

	/// <summary>
	/// An base exception for the domain layer.
	/// </summary>
	[Serializable]
	public class CurrentReasonNotRegisteredException : Exception
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CurrentReasonNotRegisteredException"/> class.
		/// </summary>
		public CurrentReasonNotRegisteredException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CurrentReasonNotRegisteredException"/> class.
		/// </summary>
		/// <param name="message">The exception message.</param>
		public CurrentReasonNotRegisteredException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CurrentReasonNotRegisteredException"/> class.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <param name="innerException">The inner exception.</param>
		public CurrentReasonNotRegisteredException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CurrentReasonNotRegisteredException"/> class.
		/// </summary>
		/// <param name="reasonCode">The reason code.</param>
		/// <param name="message">The message.</param>
		public CurrentReasonNotRegisteredException(string reasonCode, string message)
			: base(reasonCode.FormattedWith("The current transition reason ({0}) was not found in the list of registered states in the state machine." + Environment.NewLine + message))
		{
		}

		#endregion
	}
}