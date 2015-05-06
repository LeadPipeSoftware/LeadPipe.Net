// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PeekShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.StackedListTests
{
	using LeadPipe.Net.Core.Collections;
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// Tests for the StackedList Peek method.
	/// </summary>
	[TestFixture]
	public class PeekShould
	{
		#region Public Methods

		/// <summary>
		/// Test to ensure that the last item pushed is shown by peek.
		/// </summary>
		[Test]
		public void ReturnTheLastItemPushed()
		{
			// Arrange
			var stackedList = new StackedList<int>();
			stackedList.Push(0);
			stackedList.Push(1);
			stackedList.Push(2);
			stackedList.Push(3);

			// Act
			var peekedItem = stackedList.Peek();

			// Assert
			Assert.That(peekedItem.Equals(3));
		}

		/// <summary>
		/// Test to ensure that peeking does not remove the item from the list.
		/// </summary>
		[Test]
		public void NotRemoveThePeekedItem()
		{
			// Arrange
			var stackedList = new StackedList<int>();
			stackedList.Push(0);
			stackedList.Push(1);
			stackedList.Push(2);
			stackedList.Push(3);

			// Act
			stackedList.Peek();

			// Assert
			Assert.That(stackedList.Items.Contains(3));
		}

		/// <summary>
		/// Test to ensure that peeking does not change the position of an item in the list.
		/// </summary>
		[Test]
		public void NotChangeThePositionOfThePeekedItem()
		{
			// Arrange
			var stackedList = new StackedList<int>();
			stackedList.Push(0);
			stackedList.Push(1);
			stackedList.Push(2);
			stackedList.Push(3);

			// Act
			stackedList.Peek();
			stackedList.Peek();
			stackedList.Peek();

			// Assert
			Assert.That(stackedList.Peek() == 3);
		}

		/// <summary>
		/// Test to ensure peek returns the item before the last item pushed when the last item is removed.
		/// </summary>
		[Test]
		public void ReturnTheItemBeforeTheLastItemPushedGivenLastItemRemoved()
		{
			// Arrange
			var stackedList = new StackedList<int>();
			stackedList.Push(0);
			stackedList.Push(1);
			stackedList.Push(2);
			stackedList.Push(3);
			stackedList.Push(4);

			// Act
			stackedList.Remove(4);

			// Assert
			Assert.That(stackedList.Peek() == 3);
		}

		/// <summary>
		/// Test to ensure peek returns the correct item when multiple items beneath it are removed.
		/// </summary>
		[Test]
		public void ReturnTheCorrectItemGivenMultipleItemsRemoved()
		{
			// Arrange
			var stackedList = new StackedList<int>();
			stackedList.Push(0);
			stackedList.Push(1);
			stackedList.Push(2);
			stackedList.Push(3);
			stackedList.Push(4);

			// Act
			stackedList.Remove(3);
			stackedList.Remove(1);

			// Assert
			Assert.That(stackedList.Peek() == 4);
		}

		#endregion
	}
}