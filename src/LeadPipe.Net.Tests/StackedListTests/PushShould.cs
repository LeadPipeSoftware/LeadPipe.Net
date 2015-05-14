// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PushShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Collections;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StackedListTests
{
	/// <summary>
	/// Tests for the StackedList Push method.
	/// </summary>
	[TestFixture]
	public class PushShould
	{
		#region Public Methods

		/// <summary>
		/// Test to ensure that pushing a value onto an empty stacked list results in the item existing at position zero.
		/// </summary>
		[Test]
		public void AddItemAtPositionZeroGivenEmptyStackedList()
		{
			// Arrange
			var stackedList = new StackedList<int>();

			// Act
			stackedList.Push(0);

			// Assert
			Assert.That(stackedList.ElementAt(0) == 0);
		}

		/// <summary>
		/// Test to ensure that pushing a value onto a stacked list results in the item existing at position one.
		/// </summary>
		[Test]
		public void AddItemAtPositionOneGivenStackedListWithOneItem()
		{
			// Arrange
			var stackedList = new StackedList<int>();
			stackedList.Push(0);

			// Act
			stackedList.Push(1);

			// Assert
			Assert.That(stackedList.ElementAt(1) == 1);
		}

		/// <summary>
		/// Test to ensure that pushing a value onto a stacked list does not change the position of an existing item.
		/// </summary>
		[Test]
		public void NotChangeThePositionOfAnExistingElement()
		{
			// Arrange
			var stackedList = new StackedList<int>();
			stackedList.Push(0);

			// Act
			stackedList.Push(1);

			// Assert
			Assert.That(stackedList.ElementAt(0) == 0);
		}

		#endregion
	}
}