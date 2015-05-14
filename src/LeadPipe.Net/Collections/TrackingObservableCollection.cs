// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrackingObservableCollection.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.Collections
{
	/// <summary>
	/// The tracking observable collection changed event handler delegate.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="args">The args.</param>
	public delegate void TrackingObservableCollectionChangedEventHandler(object sender, TrackingObservableCollectionChangedEventArgs args);

	/// <summary>
	/// An observable collection with change tracking capabilities.
	/// </summary>
	/// <typeparam name="T">
	/// The observable collection type.
	/// </typeparam>
	public class TrackingObservableCollection<T> : ObservableCollection<T>, ITrackingObservableCollection
		where T : INotifyPropertyChanged
	{
		#region Constants and Fields

		/// <summary>
		/// The tracked items.
		/// </summary>
		private readonly List<TrackedItem<T>> trackedItems = new List<TrackedItem<T>>();

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="TrackingObservableCollection{T}"/> class. 
		/// Initializes a new instance of the <see cref="TrackingObservableCollection&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="collection">
		/// The collection.
		/// </param>
		public TrackingObservableCollection(IEnumerable<T> collection)
			: base(collection)
		{
			this.SetTrackedItems(collection);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TrackingObservableCollection{T}"/> class. 
		/// Initializes a new instance of the <see cref="TrackingObservableCollection&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="items">
		/// The items.
		/// </param>
		public TrackingObservableCollection(List<T> items)
			: base(items)
		{
			this.SetTrackedItems(items);
		}

		#endregion

		/// <summary>
		/// Occurs when [tracking observable collection changed].
		/// </summary>
		public event TrackingObservableCollectionChangedEventHandler TrackingObservableCollectionChanged;

		#region Public Properties

		/// <summary>
		/// Gets the added items.
		/// </summary>
		public virtual List<T> AddedItems
		{
			get
			{
				return (from trackedItem in this.trackedItems
						where trackedItem.TrackingState == TrackingState.Added
						select trackedItem.Item).ToList();
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance has added items.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has added items; otherwise, <c>false</c>.
		/// </value>
		public virtual bool HasAddedItems
		{
			get
			{
				return this.trackedItems.Any(item => item.TrackingState == TrackingState.Added);
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance has added and/or changed items.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has added and/or changed items; otherwise, <c>false</c>.
		/// </value>
		public virtual bool HasAddedAndOrChangedItems
		{
			get
			{
				return
					this.trackedItems.Any(
						item => item.TrackingState == TrackingState.Added || item.TrackingState == TrackingState.Changed);
			}
		}

		/// <summary>
		/// Gets the added and/or changed items.
		/// </summary>
		public virtual List<T> AddedAndOrChangedItems
		{
			get
			{
				return (from trackedItem in this.trackedItems
						where trackedItem.TrackingState == TrackingState.Added || trackedItem.TrackingState == TrackingState.Changed
						select trackedItem.Item).ToList();
			}
		}

		/// <summary>
		/// Gets the changed items.
		/// </summary>
		public virtual List<T> ChangedItems
		{
			get
			{
				return (from trackedItem in this.trackedItems
						where trackedItem.TrackingState == TrackingState.Changed
						select trackedItem.Item).ToList();
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance has changed items.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has changed items; otherwise, <c>false</c>.
		/// </value>
		public virtual bool HasChangedItems
		{
			get
			{
				return this.trackedItems.Any(item => item.TrackingState == TrackingState.Changed);
			}
		}

		/// <summary>
		/// Gets the removed items.
		/// </summary>
		public virtual List<T> RemovedItems
		{
			get
			{
				return (from trackedItem in this.trackedItems
						where trackedItem.TrackingState == TrackingState.Removed
						select trackedItem.Item).ToList();
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance has removed items.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has removed items; otherwise, <c>false</c>.
		/// </value>
		public virtual bool HasRemovedItems
		{
			get
			{
				return this.trackedItems.Any(item => item.TrackingState == TrackingState.Removed);
			}
		}

		/// <summary>
		/// Gets the unchanged items.
		/// </summary>
		public virtual List<T> UnchangedItems
		{
			get
			{
				return (from trackedItem in this.trackedItems
						where trackedItem.TrackingState == TrackingState.Unchanged
						select trackedItem.Item).ToList();
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance has unchanged items.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has unchanged items; otherwise, <c>false</c>.
		/// </value>
		public virtual bool HasUnchangedItems
		{
			get
			{
				return this.trackedItems.Any(item => item.TrackingState == TrackingState.Unchanged);
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Gets the tracking state for an object.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns>The TrackingState of the object.</returns>
		public TrackingState GetTrackingState(object obj)
		{
			if (!(obj is T))
			{
				throw new InvalidCastException();
			}

			return this.GetTrackingState((T)obj);
		}

		/// <summary>
		/// Gets the tracking state for an item.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns>The TrackingState of the item.</returns>
		public TrackingState GetTrackingState(T item)
		{
			var trackedItem = this.trackedItems.FirstOrDefault(p => p.Item.Equals(item));

			if (trackedItem.IsNotNull())
			{
				return trackedItem.TrackingState;
			}

			return TrackingState.Unknown;
		}

		/// <summary>
		/// Resets the tracking.
		/// </summary>
		/// <remarks>
		/// <para>
		/// A call to this method will result in all the tracked items being marked as unmodified. Handle with care!
		/// </para>
		/// </remarks>
		public virtual void ResetTracking()
		{
			foreach (var trackedItem in this.trackedItems)
			{
				trackedItem.TrackingState = TrackingState.Unchanged;
			}
		}

		/// <summary>
		/// Resets the collection tracking data.
		/// </summary>
		/// <param name="collection">
		/// The collection.
		/// </param>
		public virtual void SetTrackedItems(IEnumerable<T> collection)
		{
			this.SetTrackedItems(collection.ToList());
		}

		/// <summary>
		/// Resets the collection tracking data.
		/// </summary>
		/// <param name="items">
		/// The items.
		/// </param>
		public virtual void SetTrackedItems(List<T> items)
		{
			// Clear the existing list...
			this.trackedItems.Clear();

			// Add each item in the incoming collection to our tracked items list and wire up the event handler...
			foreach (T item in items)
			{
				this.trackedItems.Add(new TrackedItem<T>(item, TrackingState.Unchanged));

				item.PropertyChanged += this.TrackedItemPropertyChanged;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Raises the <see cref="E:CollectionChanged"/> event.
		/// </summary>
		/// <param name="e">
		/// The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.
		/// </param>
		protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnCollectionChanged(e);

			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:

					foreach (T item in e.NewItems)
					{
						this.trackedItems.Add(new TrackedItem<T>(item, TrackingState.Added));

						item.PropertyChanged += this.TrackedItemPropertyChanged;
					}

					this.OnTrackingObservableCollectionChanged(new TrackingObservableCollectionChangedEventArgs(TrackingObservableCollectionChangedAction.Add));

					break;

				case NotifyCollectionChangedAction.Remove:

					foreach (var trackedItem in from T item in e.OldItems select this.trackedItems.Find(t => t.Item.Equals(item)))
					{
						switch (trackedItem.TrackingState)
						{
							case TrackingState.Unchanged:
							case TrackingState.Changed:
								trackedItem.TrackingState = TrackingState.Removed;
								break;
							case TrackingState.Added:
								this.trackedItems.Remove(trackedItem);
								break;
							default:
								break;
						}
					}

					var trackingState = TrackingState.Unchanged;
					if (this.HasAddedAndOrChangedItems || this.HasRemovedItems)
					{
						trackingState = TrackingState.Changed;
					}

					this.OnTrackingObservableCollectionChanged(new TrackingObservableCollectionChangedEventArgs(TrackingObservableCollectionChangedAction.Remove, trackingState));

					break;

				case NotifyCollectionChangedAction.Move:
					this.OnTrackingObservableCollectionChanged(new TrackingObservableCollectionChangedEventArgs(TrackingObservableCollectionChangedAction.Move));
					break;

				case NotifyCollectionChangedAction.Replace:
					this.OnTrackingObservableCollectionChanged(new TrackingObservableCollectionChangedEventArgs(TrackingObservableCollectionChangedAction.Replace));
					break;

				case NotifyCollectionChangedAction.Reset:
					this.OnTrackingObservableCollectionChanged(new TrackingObservableCollectionChangedEventArgs(TrackingObservableCollectionChangedAction.Reset));
					break;

				default:
					break;
			}
		}

		/// <summary>
		/// Raises the <see cref="TrackingObservableCollectionChanged"/> event.
		/// </summary>
		/// <param name="e">The <see cref="TrackingObservableCollectionChangedEventArgs"/> instance containing the event data.</param>
		protected virtual void OnTrackingObservableCollectionChanged(TrackingObservableCollectionChangedEventArgs e)
		{
			if (this.TrackingObservableCollectionChanged.IsNotNull())
			{
				this.TrackingObservableCollectionChanged(this, e);
			}
		}

		/// <summary>
		/// Occurs when a tracked item changes.
		/// </summary>
		/// <param name="sender">
		/// The sender.
		/// </param>
		/// <param name="e">
		/// The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.
		/// </param>
		private void TrackedItemPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			TrackedItem<T> trackedItem = this.trackedItems.Find(t => t.Item.Equals(sender));

			switch (trackedItem.TrackingState)
			{
				case TrackingState.Unchanged:
					trackedItem.TrackingState = TrackingState.Changed;

					this.OnTrackingObservableCollectionChanged(new TrackingObservableCollectionChangedEventArgs(TrackingObservableCollectionChangedAction.ItemChanged));
					break;
				default:
					break;
			}
		}

		#endregion

		/// <summary>
		/// Represents a tracked item.
		/// </summary>
		/// <typeparam name="TTrackedItemType">
		/// The type of the tracked item type.
		/// </typeparam>
		private class TrackedItem<TTrackedItemType>
		{
			#region Constructors and Destructors

			/// <summary>
			/// Initializes a new instance of the <see cref="TrackedItem{TTrackedItemType}"/> class. 
			/// Initializes a new instance of the <see cref="TrackingObservableCollection&lt;T&gt;.TrackedItem&lt;TTrackedItemType&gt;"/> class.
			/// </summary>
			/// <param name="item">
			/// The item.
			/// </param>
			/// <param name="trackingState">
			/// State of the tracking.
			/// </param>
			public TrackedItem(TTrackedItemType item, TrackingState trackingState)
			{
				this.Item = item;
				this.TrackingState = trackingState;
			}

			#endregion

			#region Public Properties

			/// <summary>
			/// Gets or sets the item.
			/// </summary>
			/// <value>
			/// The item.
			/// </value>
			public TTrackedItemType Item { get; set; }

			/// <summary>
			/// Gets or sets the state of the tracking.
			/// </summary>
			/// <value>
			/// The state of the tracking.
			/// </value>
			public TrackingState TrackingState { get; set; }

			#endregion
		}
	}
}