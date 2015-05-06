// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrackingObservableCollectionChangedAction.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Collections
{
	/// <summary>
	/// Describes the action that took place when a TrackingObservableCollection changes.
	/// </summary>
	public enum TrackingObservableCollectionChangedAction
	{
		/// <summary>
		/// Indicates that an item was added.
		/// </summary>
		Add,

		/// <summary>
		/// Indicates that an item was moved.
		/// </summary>
		Move,

		/// <summary>
		/// Indicates an item was removed.
		/// </summary>
		Remove,

		/// <summary>
		/// Indicates an item was changed.
		/// </summary>
		ItemChanged,

		/// <summary>
		/// Indicates an item was replaced.
		/// </summary>
		Replace,

		/// <summary>
		/// Indicates that the collection changed dramatically.
		/// </summary>
		Reset
	}
}