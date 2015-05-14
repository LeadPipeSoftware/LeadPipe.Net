// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrackingObservableCollectionChangedEventArgs.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Collections
{
	/// <summary>
	/// The tracking observable collection changed event args.
	/// </summary>
	public class TrackingObservableCollectionChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TrackingObservableCollectionChangedEventArgs"/> class.
		/// </summary>
		/// <param name="action">The action.</param>
		public TrackingObservableCollectionChangedEventArgs(TrackingObservableCollectionChangedAction action) : this(action, TrackingState.Changed)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TrackingObservableCollectionChangedEventArgs"/> class.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <param name="trackingState">State of the tracking.</param>
		public TrackingObservableCollectionChangedEventArgs(TrackingObservableCollectionChangedAction action, TrackingState trackingState)
		{
			this.Action = action;
			this.TrackingState = trackingState;
		}

		/// <summary>
		/// Gets the action.
		/// </summary>
		public TrackingObservableCollectionChangedAction Action { get; private set; }

		/// <summary>
		/// Gets the state of the tracking.
		/// </summary>
		/// <value>
		/// The state of the tracking.
		/// </value>
		public TrackingState TrackingState { get; private set; }
	}
}