// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Collections;
using NUnit.Framework;
using System.Collections.Generic;

namespace LeadPipe.Net.Tests.TrackingObservableCollectionTests
{
    /// <summary>
    /// Tests for the TrackingObservableCollection type.
    /// </summary>
    [TestFixture]
    public class TrackingObservableCollectionShould
    {
        /// <summary>
        /// The tracking observable collection.
        /// </summary>
        private TrackingObservableCollection<NotifyingStringClass> trackingObservableCollection;

        /// <summary>
        /// The tracking state
        /// </summary>
        private TrackingState trackingState;

        /// <summary>
        /// Raises an event with tracking state of changed.
        /// </summary>
        [Test]
        public void RaiseAnEventWithTrackingStateChangedAfterAddingNewItem()
        {
            // Arrange
            var newItem = new NotifyingStringClass();

            // Act
            this.trackingObservableCollection.Add(newItem);

            // Assert
            Assert.That(this.trackingState, Is.EqualTo(TrackingState.Changed));
        }

        /// <summary>
        /// Raises an event with tracking state changed after adding then removing and adding again.
        /// </summary>
        [Test]
        public void RaiseAnEventWithTrackingStateChangedAfterAddingThenRemovingAndAddingAgain()
        {
            // Arrange
            var firstItem = new NotifyingStringClass();
            var secondItem = new NotifyingStringClass();

            // Act
            this.trackingObservableCollection.Add(firstItem);
            this.trackingObservableCollection.Remove(firstItem);
            this.trackingObservableCollection.Add(secondItem);

            // Assert
            Assert.That(this.trackingState, Is.EqualTo(TrackingState.Changed));
        }

        /// <summary>
        /// Raises an event with tracking state changed after modifying existing item.
        /// </summary>
        [Test]
        public void RaiseAnEventWithTrackingStateChangedAfterModifyingExistingItem()
        {
            // Arrange
            var newItem = this.trackingObservableCollection[0];

            // Act
            newItem.Value = "New Value";

            // Assert
            Assert.That(this.trackingState, Is.EqualTo(TrackingState.Changed));
        }

        /// <summary>
        /// Raises an event with tracking state changed after removing existing item.
        /// </summary>
        [Test]
        public void RaiseAnEventWithTrackingStateChangedAfterRemovingExistingItems()
        {
            // Act
            this.trackingObservableCollection.Clear();

            // Assert
            Assert.That(this.trackingState, Is.EqualTo(TrackingState.Changed));
        }

        /// <summary>
        /// Raises an event with tracking state of unchanged.
        /// </summary>
        [Test]
        public void RaiseAnEventWithTrackingStateUnchangedAfterAddingThenRemovingSameItem()
        {
            // Arrange
            var newItem = new NotifyingStringClass();

            // Act
            this.trackingObservableCollection.Add(newItem);
            this.trackingObservableCollection.Remove(newItem);

            // Assert
            Assert.That(this.trackingState, Is.EqualTo(TrackingState.Unchanged));
        }

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            var originalList = new List<NotifyingStringClass> { new NotifyingStringClass() };
            this.trackingObservableCollection = new TrackingObservableCollection<NotifyingStringClass>(originalList);

            this.trackingObservableCollection.TrackingObservableCollectionChanged += (sender, eventArgs) =>
                {
                    this.trackingState = eventArgs.TrackingState;
                };
        }
    }
}