// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;
using System;
using System.IO;

namespace LeadPipe.Net.Tests.ExceptionExtensionTests
{
    /// <summary>
    /// ExceptionExtensions GetFirstExceptionOfType tests.
    /// </summary>
    [TestFixture]
    public class GetFirstExceptionOfTypeShould
    {
        /// <summary>
        /// Tests to make sure the exception is returned if the exception is of a particular type.
        /// </summary>
        [Test]
        public void ReturnGivenExceptionIsOfType()
        {
            // Arrange
            var exception = new NullReferenceException();

            // Act
            var returnedException = exception.GetFirstExceptionOfType<NullReferenceException>();

            // Assert
            Assert.IsTrue(returnedException != null);
        }

        /// <summary>
        /// Tests to make sure null is returned if the exception does not contain a particular type.
        /// </summary>
        [Test]
        public void ReturnNullGivenExceptionDoesNotContainType()
        {
            // Arrange
            var innerException = new NullReferenceException();
            var exception = new NullReferenceException("Test", innerException);

            // Act
            var returnedException = exception.GetFirstExceptionOfType<FileNotFoundException>();

            // Assert
            Assert.IsTrue(returnedException == null);
        }

        /// <summary>
        /// Tests to make sure null is returned if the exception is not of a particular type.
        /// </summary>
        [Test]
        public void ReturnNullGivenExceptionIsNotOfType()
        {
            // Arrange
            var exception = new NullReferenceException();

            // Act
            var returnedException = exception.GetFirstExceptionOfType<NotImplementedException>();

            // Assert
            Assert.IsTrue(returnedException == null);
        }
    }
}