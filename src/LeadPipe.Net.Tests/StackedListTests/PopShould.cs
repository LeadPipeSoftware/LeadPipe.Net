// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Collections;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StackedListTests
{
    /// <summary>
    /// Tests for the StackedList Pop method.
    /// </summary>
    [TestFixture]
    public class PopShould
    {
        /// <summary>
        /// Test to ensure that the popped item is the last item pushed.
        /// </summary>
        [Test]
        public void RemoveThePoppedItem()
        {
            // Arrange
            var stackedList = new StackedList<int>();
            stackedList.Push(0);
            stackedList.Push(1);
            stackedList.Push(2);
            stackedList.Push(3);

            // Act
            stackedList.Pop();

            // Assert
            Assert.That(!stackedList.Items.Contains(3));
        }

        /// <summary>
        /// Test to ensure that the popped item is the last item pushed.
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
            var poppedItem = stackedList.Pop();

            // Assert
            Assert.That(poppedItem.Equals(3));
        }
    }
}