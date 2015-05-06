// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FiniteStateMachineHistoryEntry.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.FiniteStateMachine
{
	using System;

	/// <summary>
	/// The finite state machine history entry.
	/// </summary>
	public class FiniteStateMachineHistoryEntry : IFiniteStateMachineHistoryEntry
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateMachineHistoryEntry"/> class.
		/// </summary>
		/// <param name="entryNumber">The entry number.</param>
		/// <param name="stateCode">The state code.</param>
		/// <param name="reasonCode">The reason code.</param>
		public FiniteStateMachineHistoryEntry(int entryNumber, int stateCode, string reasonCode)
		{
			this.EntryNumber = entryNumber;
			this.StateCode = stateCode;
			this.ReasonCode = reasonCode;

			this.EntryDate = DateTime.Now;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateMachineHistoryEntry"/> class.
		/// </summary>
		/// <param name="entryNumber">The entry number.</param>
		/// <param name="stateCode">The state code.</param>
		/// <param name="reasonCode">The reason code.</param>
		/// <param name="comments">The comments.</param>
		public FiniteStateMachineHistoryEntry(
			int entryNumber,
			int stateCode,
			string reasonCode,
			string comments)
			: this(entryNumber, stateCode, reasonCode)
		{
			this.Comments = comments;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FiniteStateMachineHistoryEntry"/> class.
		/// </summary>
		public FiniteStateMachineHistoryEntry()
		{
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the comments.
		/// </summary>
		public virtual string Comments { get; set; }

		/// <summary>
		/// Gets or sets the entry date.
		/// </summary>
		public virtual DateTime EntryDate { get; set; }

		/// <summary>
		/// Gets or sets the entry number.
		/// </summary>
		public virtual int EntryNumber { get; set; }

		/// <summary>
		/// Gets or sets the executed by name.
		/// </summary>
		public virtual string ExecutedBy { get; set; }

		/// <summary>
		/// Gets or sets the owner.
		/// </summary>
		/// <value>
		/// The owner.
		/// </value>
		public virtual string Owner { get; set; }

		/// <summary>
		/// Gets or sets the reason code.
		/// </summary>
		public virtual string ReasonCode { get; set; }

		/// <summary>
		/// Gets or sets the surrogate id.
		/// </summary>
		/// <remarks>
		/// This field is usually for persistence-related concerns.
		/// </remarks>
		public virtual Guid Sid { get; set; }

		/// <summary>
		/// Gets or sets the state code.
		/// </summary>
		public virtual int StateCode { get; set; }

		/// <summary>
		/// Gets or sets the state name.
		/// </summary>
		public virtual string StateName { get; set; }

		/// <summary>
		/// Gets or sets the reason description.
		/// </summary>
		/// <value>
		/// The reason description.
		/// </value>
		public virtual string ReasonDescription { get; set; }

		#endregion
	}
}