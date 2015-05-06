// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.StackedListTests
{
	using LeadPipe.Net.Core.Collections;
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// Tests for the StackedList Remove method.
	/// </summary>
	[TestFixture]
	public class RemoveShould
	{
		#region Public Methods

		/// <summary>
		/// Test to ensure remove actually removes an item.
		/// </summary>
		[Test]
		public void RemoveAnItem()
		{
			// Arrange
			var stackedList = new StackedList<int>();
			stackedList.Push(0);
			stackedList.Push(1);
			stackedList.Push(2);
			stackedList.Push(3);

			// Act
			stackedList.Remove(3);

			// Assert
			Assert.That(!stackedList.Items.Contains(3));
		}

		/// <summary>
		/// Test to ensure remove actually removes an item in the middle of the stack.
		/// </summary>
		[Test]
		public void RemoveAnItemFromTheMiddleOfTheStack()
		{
			// Arrange
			var stackedList = new StackedList<int>();
			stackedList.Push(0);
			stackedList.Push(1);
			stackedList.Push(2);
			stackedList.Push(3);
			stackedList.Push(4);

			// Act
			stackedList.Remove(2);

			// Assert
			Assert.That(!stackedList.Items.Contains(2));
		}

		/// <summary>
		/// Test to ensure that removing an item underneath the last item added does not change the peeked item.
		/// </summary>
		[Test]
		public void NotChangeThePeekedValueGivenRemovalOfAnItemBelow()
		{
			// Arrange
			var stackedList = new StackedList<int>();
			stackedList.Push(0);
			stackedList.Push(1);
			stackedList.Push(2);
			stackedList.Push(3);
			stackedList.Push(4);

			// Act
			stackedList.Remove(2);

			// Assert
			Assert.That(stackedList.Peek() == 4);
		}

		#endregion
	}
}