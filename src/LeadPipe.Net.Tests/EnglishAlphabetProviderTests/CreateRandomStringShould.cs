// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Tests.EnglishAlphabetProviderTests
{
    /// <summary>
    /// CreateRandomString tests.
    /// </summary>
    [TestFixture]
    public class CreateRandomStringShould
    {
        /// <summary>
        /// Tests to make sure that PROVIDE DESCRIPTION HERE.
        /// </summary>
        [Test]
        public void NotReturnTheSameStringTwice()
        {
            // Arrange

            // Act

            // Assert
            Assert.Inconclusive("This unit test is not complete.");
        }

        /// <summary>
        /// Tests to make sure that PROVIDE DESCRIPTION HERE.
        /// </summary>
        /// <param name="randomStringLength">
        /// The length of the random string.
        /// </param>
        [TestCase(1)]
        [TestCase(int.MinValue)]
        public void ReturnCorrectLengthString(int randomStringLength)
        {
            // Arrange

            // Act

            // Assert
            Assert.Inconclusive("This unit test is not complete.");
        }

        /// <summary>
        /// Tests to make sure that PROVIDE DESCRIPTION HERE.
        /// </summary>
        [Test]
        public void ThrowsExceptionGivenNegativeStringLengthParameter()
        {
            // Arrange

            // Act

            // Assert
            Assert.Inconclusive("This unit test is not complete.");
        }
    }
}