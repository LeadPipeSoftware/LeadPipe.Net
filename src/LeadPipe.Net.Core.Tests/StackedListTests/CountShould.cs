// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CountShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.StackedListTests
{
	using LeadPipe.Net.Core.Collections;
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// Tests for the StackedList Count property.
	/// </summary>
	[TestFixture]
	public class CountShould
	{
		#region Public Methods

		/// <summary>
		/// Test to ensure that the count is accurate.
		/// </summary>
		/// <param name="numberOfItems">The number of items.</param>
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(10)]
		[TestCase(500)]
		public void ReturnTheCorrectCount(int numberOfItems)
		{
			// Arrange
			var stackedList = new StackedList<int>();

			for (var i = 1; i <= numberOfItems; i++)
			{
				stackedList.Push(i);
			}

			// Act
			var itemCount = stackedList.Count;

			// Assert
			Assert.That(itemCount.Equals(numberOfItems));
		}

		/// <summary>
		/// Test to ensure that the count is accurate after items are removed.
		/// </summary>
		/// <param name="initialNumberOfItems">The number of items.</param>
		/// <param name="numberOfItemsToRemove">The number of items to remove.</param>
		[TestCase(10, 3)]
		[TestCase(500, 75)]
		public void ReturnTheCorrectCountGivenRemovedItems(int initialNumberOfItems, int numberOfItemsToRemove)
		{
			// Arrange
			var stackedList = new StackedList<int>();

			// Add the items...
			for (var i = 1; i <= initialNumberOfItems; i++)
			{
				stackedList.Push(i);
			}

			// Remove some items...
			for (var i = 1; i <= numberOfItemsToRemove; i++)
			{
				stackedList.Remove(i);
			}

			// Act
			var itemCount = stackedList.Count;

			// Assert
			Assert.That(itemCount.Equals(initialNumberOfItems - numberOfItemsToRemove));
		}

		/// <summary>
		/// Test to ensure that the count is accurate after items are poked.
		/// </summary>
		/// <param name="initialNumberOfItems">The number of items.</param>
		/// <param name="numberOfItemsToPop">The number of items to remove.</param>
		[TestCase(100, 40)]
		[TestCase(750, 500)]
		public void ReturnTheCorrectCountGivenPoppedItems(int initialNumberOfItems, int numberOfItemsToPop)
		{
			// Arrange
			var stackedList = new StackedList<int>();

			// Add the items...
			for (var i = 1; i <= initialNumberOfItems; i++)
			{
				stackedList.Push(i);
			}

			// Pop some items...
			for (var i = 1; i <= numberOfItemsToPop; i++)
			{
				stackedList.Pop();
			}

			// Act
			var itemCount = stackedList.Count;

			// Assert
			Assert.That(itemCount.Equals(initialNumberOfItems - numberOfItemsToPop));
		}

		#endregion
	}
}