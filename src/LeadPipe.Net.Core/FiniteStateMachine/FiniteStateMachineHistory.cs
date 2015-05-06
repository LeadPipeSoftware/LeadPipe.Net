// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FiniteStateMachineHistory.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.FiniteStateMachine
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq;

	using LeadPipe.Net.Core.Extensions;

	/// <summary>
	/// The finite state machine history.
	/// </summary>
	/// <typeparam name="THistoryEntry">The type of the history entry.</typeparam>
	public class FiniteStateMachineHistory<THistoryEntry> : IFiniteStateMachineHistory<THistoryEntry>
		where THistoryEntry : IFiniteStateMachineHistoryEntry
	{
		#region Constants and Fields

		/// <summary>
		/// The history entries.
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "GBM: Suppression is OK here. Jose said it was okay.")]
		protected IList<THistoryEntry> entries = new List<THistoryEntry>();

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the entries sorted by entry number.
		/// </summary>
		public virtual IEnumerable<THistoryEntry> Entries
		{
			get
			{
				return this.entries.OrderBy(x => x.EntryNumber).ToList().AsReadOnly();
			}

			set
			{
				this.entries = value.ToList();
			}
		}

		/// <summary>
		/// Gets the initial entry.
		/// </summary>
		/// <value>
		/// The initial entry.
		/// </value>
		public virtual THistoryEntry InitialEntry
		{
			get
			{
				return this.entries.FirstOrDefault(x => x.EntryNumber == this.entries.Min(m => m.EntryNumber));
			}
		}

		/// <summary>
		/// Gets the most recent entry.
		/// </summary>
		public virtual THistoryEntry MostRecentEntry
		{
			get
			{
				return this.entries.FirstOrDefault(x => x.EntryNumber == this.entries.Max(m => m.EntryNumber));
			}
		}

		/// <summary>
		/// Gets or sets the surrogate id.
		/// </summary>
		/// <remarks>
		/// This field is usually for persistence-related concerns.
		/// </remarks>
		public virtual Guid Sid { get; set; }

		/// <summary>
		/// Gets or sets the persistence version.
		/// </summary>
		public virtual int Ver { get; set; }

		#endregion

		#region Properties

		/// <summary>
		/// Gets the next history entry number.
		/// </summary>
		protected int NextHistoryEntryNumber
		{
			get
			{
				var mostRecentEntry = this.MostRecentEntry;

				if (mostRecentEntry.IsNull())
				{
					return 1;
				}

				return mostRecentEntry.EntryNumber + 1;
			}
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Adds an entry to the history.
		/// </summary>
		/// <param name="historyEntry">The history entry.</param>
		public virtual void AddEntry(THistoryEntry historyEntry)
		{
			historyEntry.EntryNumber = this.NextHistoryEntryNumber;
			historyEntry.EntryDate = DateTime.Now;

			this.entries.Add(historyEntry);
		}

		#endregion
	}

	/// <summary>
	/// The finite state machine history.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
		Justification = "GBM: Suppression is OK here.")]
	public class FiniteStateMachineHistory : FiniteStateMachineHistory<IFiniteStateMachineHistoryEntry>
	{
		#region Public Methods and Operators

		/// <summary>
		/// Adds an entry to the history.
		/// </summary>
		/// <param name="state">
		/// The state.
		/// </param>
		/// <param name="reason">
		/// The reason.
		/// </param>
		/// <param name="comment">
		/// The comment.
		/// </param>
		public virtual void AddEntry(IFiniteState state, IFiniteStateMachineTransitionReason reason, string comment = null)
		{
			//// TODO: Add some entry checking.
			var historyEntry = new FiniteStateMachineHistoryEntry(this.NextHistoryEntryNumber, state.Code, reason.Code, comment);

			this.entries.Add(historyEntry);
		}

		#endregion
	}
}