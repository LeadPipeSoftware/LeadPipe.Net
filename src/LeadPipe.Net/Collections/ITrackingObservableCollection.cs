// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Specialized;

namespace LeadPipe.Net.Collections
{
    /// <summary>
    /// The TrackingObservableCollection interface.
    /// </summary>
    public interface ITrackingObservableCollection
    {
        /// <summary>
        /// Occurs when [collection changed].
        /// </summary>
        event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// Occurs when [tracking observable collection changed].
        /// </summary>
        event TrackingObservableCollectionChangedEventHandler TrackingObservableCollectionChanged;

        /// <summary>
        /// Gets the count.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has added and/or changed items.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has added and/or changed items; otherwise, <c>false</c>.
        /// </value>
        bool HasAddedAndOrChangedItems { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has added items.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has added items; otherwise, <c>false</c>.
        /// </value>
        bool HasAddedItems { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has changed items.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has changed items; otherwise, <c>false</c>.
        /// </value>
        bool HasChangedItems { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has removed items.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has removed items; otherwise, <c>false</c>.
        /// </value>
        bool HasRemovedItems { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has unchanged items.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has unchanged items; otherwise, <c>false</c>.
        /// </value>
        bool HasUnchangedItems { get; }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        void Clear();

        /// <summary>
        /// Gets the tracking state for an object.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The TrackingState of the object.
        /// </returns>
        TrackingState GetTrackingState(object obj);

        /// <summary>
        /// Moves the specified old index.
        /// </summary>
        /// <param name="oldIndex">
        /// The old index.
        /// </param>
        /// <param name="newIndex">
        /// The new index.
        /// </param>
        void Move(int oldIndex, int newIndex);

        /// <summary>
        /// Removes at.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        void RemoveAt(int index);

        /// <summary>
        /// Resets the tracking.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A call to this method will result in all the tracked items being marked as unmodified. Handle with care!
        /// </para>
        /// </remarks>
        void ResetTracking();
    }
}