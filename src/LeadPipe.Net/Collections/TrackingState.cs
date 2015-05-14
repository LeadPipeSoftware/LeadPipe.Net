// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrackingState.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Collections
{
	/// <summary>
	/// The tracking state.
	/// </summary>
	public enum TrackingState
	{
		/// <summary>
		/// Indicates that the tracking state is unknown (which should really never happen).
		/// </summary>
		Unknown,

		/// <summary>
		/// Indicates that an item is not changed, deleted or added.
		/// </summary>
		Unchanged,

		/// <summary>
		/// Indicates an item was changed.
		/// </summary>
		Changed,

		/// <summary>
		/// Indicates an item was removed.
		/// </summary>
		Removed,

		/// <summary>
		/// Indicates an item was added.
		/// </summary>
		Added
	}
}