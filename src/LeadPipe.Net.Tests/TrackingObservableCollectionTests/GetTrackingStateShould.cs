// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetTrackingStateShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.TrackingObservableCollectionTests
{
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;

	using LeadPipe.Net.Core.Collections;
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// Tests for the GetTrackingStateShould type.
	/// </summary>
	[TestFixture]
	public class GetTrackingStateShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to ensure that the correct tracking state is returned for an item.
		/// </summary>
		[Test]
		public void ReturnUnchangedGivenUnchangedItem()
		{
			var item = new NotifyingStringClass { Value = "SomeValue" };

			var originalList = new List<NotifyingStringClass>();

			originalList.Add(item);

			var trackingCollection = new TrackingObservableCollection<NotifyingStringClass>(originalList);

			var itemStatus = trackingCollection.GetTrackingState(item);

			Assert.IsTrue(itemStatus.Equals(TrackingState.Unchanged));
		}

		/// <summary>
		/// Tests to ensure that the correct tracking state is returned for an item.
		/// </summary>
		[Test]
		public void ReturnUnchangedGivenUnchangedObject()
		{
			var item = new NotifyingStringClass { Value = "SomeValue" };

			var originalList = new List<NotifyingStringClass>();

			originalList.Add(item);

			var trackingCollection = new TrackingObservableCollection<NotifyingStringClass>(originalList);

			var itemObject = item as object;

			var itemStatus = trackingCollection.GetTrackingState(itemObject);

			Assert.IsTrue(itemStatus.Equals(TrackingState.Unchanged));
		}

		/// <summary>
		/// Tests to ensure that the correct tracking state is returned for an item.
		/// </summary>
		[Test]
		public void ReturnAddedGivenAddedItem()
		{
			var listOfItems = new List<NotifyingStringClass>();

			var trackingCollection = new TrackingObservableCollection<NotifyingStringClass>(listOfItems);

			var addedItem = new NotifyingStringClass { Value = "SomeValue" };

			trackingCollection.Add(addedItem);

			var itemStatus = trackingCollection.GetTrackingState(addedItem);

			Assert.IsTrue(itemStatus.Equals(TrackingState.Added));
		}

		/// <summary>
		/// Tests to ensure that the correct tracking state is returned for an item.
		/// </summary>
		[Test]
		public void ReturnRemovedGivenRemovedItem()
		{
			var item = new NotifyingStringClass { Value = "SomeValue" };

			var originalList = new List<NotifyingStringClass>();

			originalList.Add(item);

			var trackingCollection = new TrackingObservableCollection<NotifyingStringClass>(originalList);

			trackingCollection.Remove(item);

			var itemStatus = trackingCollection.GetTrackingState(item);

			Assert.IsTrue(itemStatus.Equals(TrackingState.Removed));
		}

		/// <summary>
		/// Tests to ensure that the correct tracking state is returned for an item.
		/// </summary>
		[Test]
		public void ReturnChangedGivenChangedItem()
		{
			var item = new NotifyingStringClass { Value = "SomeValue" };

			var originalList = new List<NotifyingStringClass>();

			originalList.Add(item);

			var trackingCollection = new TrackingObservableCollection<NotifyingStringClass>(originalList);

			item.Value = "SomethingElse";

			var itemStatus = trackingCollection.GetTrackingState(item);

			Assert.IsTrue(itemStatus.Equals(TrackingState.Changed));
		}

		#endregion
	}

	/// <summary>
	/// A test class with INotifyPropertyChanged support.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
		Justification = "Reviewed. Suppression is OK here.")]
	internal class NotifyingStringClass : NotifyPropertyChanged
	{
		/// <summary>
		/// The value.
		/// </summary>
		private string value;

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		public string Value
		{
			get
			{
				return this.value;
			}

			set
			{
				this.value = value;

				this.NotifyOfPropertyChange(() => this.Value);
			}
		}
	}
}