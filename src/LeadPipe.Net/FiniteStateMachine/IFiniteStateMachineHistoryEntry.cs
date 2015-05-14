// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFiniteStateMachineHistoryEntry.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.FiniteStateMachine
{
	/// <summary>
	/// The finite state machine history entry.
	/// </summary>
	public interface IFiniteStateMachineHistoryEntry
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets the comments.
		/// </summary>
		string Comments { get; set; }

		/// <summary>
		/// Gets or sets the entry date.
		/// </summary>
		DateTime EntryDate { get; set; }

		/// <summary>
		/// Gets or sets the entry number.
		/// </summary>
		int EntryNumber { get; set; }

		/// <summary>
		/// Gets or sets the executed by name.
		/// </summary>
		string ExecutedBy { get; set; }

		/// <summary>
		/// Gets or sets the reason code.
		/// </summary>
		string ReasonCode { get; set; }

		/// <summary>
		/// Gets or sets the surrogate id.
		/// </summary>
		/// <remarks>
		/// This field is usually for persistence-related concerns.
		/// </remarks>
		Guid Sid { get; set; }

		/// <summary>
		/// Gets or sets the state code.
		/// </summary>
		int StateCode { get; set; }

		#endregion
	}
}