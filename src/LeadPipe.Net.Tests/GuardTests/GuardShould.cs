// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;
using System;

namespace LeadPipe.Net.Tests.GuardTests
{
    using Guard = Guard;

    /// <summary>
    /// Guard tests.
    /// </summary>
    [TestFixture]
    public class GuardShould
    {
        /// <summary>
        /// Test to make sure that an action is invoked AND exception is thrown when an assertion fails.
        /// </summary>
        [Test]
        public void InvokeActionAndThrowExceptionGivenAssertionFails()
        {
            // Arrange
            var testVariable = false;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => Guard
                .Will
                    .ThrowExceptionOfType<InvalidOperationException>()
                    .Execute(() => testVariable = true)
                .When(false.IsFalse()));

            Assert.That(testVariable.IsTrue());
        }

        /// <summary>
        /// Test to make sure that an action is invoked when an assertion fails.
        /// </summary>
        [Test]
        public void InvokeActionGivenAssertionFails()
        {
            // Arrange
            var testVariable = false;

            // Act
            Guard
                .Will.Execute(() => testVariable = true)
                .When(false.IsFalse());

            // Assert
            Assert.That(testVariable.IsTrue());
        }

        /// <summary>
        /// Test to make sure that an exception is thrown when an assertion fails.
        /// </summary>
        [Test]
        public void NotThrowAnExceptionWhenObjectIsEmptyGivenNonEmptyString()
        {
            // Arrange
            var notAnEmptyString = "not an empty string";

            // Act
            Guard.Will.ThrowException().When(string.IsNullOrEmpty(notAnEmptyString));

            // Assert
        }

        /// <summary>
        /// Test to make sure that no exception is thrown when the assertion is true.
        /// </summary>
        [Test]
        public void NotThrowExceptionGivenAssertionFails()
        {
            // Arrange

            // Act
            Guard.Will.ThrowException().When(false);

            // Assert
        }

        /// <summary>
        /// Test to make sure that an exception is thrown when an assertion fails.
        /// </summary>
        [Test]
        public void NotThrowInvalidOperationExceptionGivenInvalidOperationExceptionTypeAndAssertionIsTrue()
        {
            // Arrange

            // Act & Assert
            Guard.Will.ThrowExceptionOfType<InvalidOperationException>().When(false.IsTrue());
        }

        /// <summary>
        /// Test to make sure that an exception is thrown when an assertion fails.
        /// </summary>
        [Test]
        public void ThrowAnExceptionGivenNullObject()
        {
            // Arrange
            string nullString = null;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => Guard.Will.ThrowException().When(nullString.IsNull()));
        }

        /// <summary>
        /// Test to make sure that an exception is thrown when an assertion fails.
        /// </summary>
        [Test]
        public void ThrowAnInvalidOperationExceptionGivenNullObject()
        {
            // Arrange
            string nullString = null;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => Guard.Will.ThrowExceptionOfType<InvalidOperationException>().When(nullString.IsNull()));
        }

        /// <summary>
        /// Test to make sure that an exception with a relationship and custom message is thrown when an assertion fails.
        /// </summary>
        [Test]
        public void ThrowAnInvalidOperationExceptionWithCustomMessageAndRelationshipIdGivenNullObject()
        {
            // Arrange
            string nullString = null;
            string relationship = "TEST";

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                Guard
                    .Will
                    .AssociateExceptionsWith(relationship)
                    .And
                    .ThrowExceptionOfType<InvalidOperationException>("Custom message goes here.")
                    .When(nullString.IsNull());
            }, "[TEST] Custom message goes here.");
        }

        /// <summary>
        /// Test to make sure that an exception with a relationship is thrown when an assertion fails.
        /// </summary>
        [Test]
        public void ThrowAnInvalidOperationExceptionWithRelationshipIdGivenNullObject()
        {
            // Arrange
            string nullString = null;
            string relationship = "TEST";

            // Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                Guard
                    .Will
                    .AssociateExceptionsWith(relationship)
                    .And
                    .ThrowExceptionOfType<InvalidOperationException>()
                    .When(nullString.IsNull());
            }, "[TEST]");

            // Assert
        }

        /// <summary>
        /// Test to make sure that an exception is thrown immediately upon a Now() call.
        /// </summary>
        [Test]
        public void ThrowAnInvalidOperationExceptionWithRelationshipIdGivenNullObjectAndNowCalled()
        {
            // Arrange
            string relationship = "TEST";

            // Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                Guard
                    .Will
                    .AssociateExceptionsWith(relationship)
                    .And
                    .ThrowExceptionOfType<InvalidOperationException>()
                    .Now();
            }, "[TEST]");

            // Assert
        }

        /// <summary>
        /// Test to make sure that an ArgumentNullException is thrown when checking for a null argument.
        /// </summary>
        [Test]
        public void ThrowArgumentNullExceptionGivenNullArgument()
        {
            // Arrange
            string nullArgument = null;

            // Act
            Assert.Throws<ArgumentNullException>(() => Guard.Will.ProtectAgainstNullArgument(() => nullArgument));

            // Assert
        }

        /// <summary>
        /// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with a null value.
        /// </summary>
        /// <param name="argument">The argument.</param>
        [TestCase(null)]
        public void ThrowArgumentNullExceptionGivenNullDefaultTypeArgument(string argument)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Will.ProtectAgainstDefaultValueArgument(() => argument));
        }

        /// <summary>
        /// Test to ensure that exception is thrown for both null or empty string when calling
        /// ProtectAgainstNullOrEmptyStringArgument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        [TestCase(null)]
        [TestCase("")]
        public void ThrowArgumentNullExceptionGivenNullOrEmptyStringArgument(string argument)
        {
            Assert.Throws<ArgumentNullException>(() => Guard.Will.ProtectAgainstNullOrEmptyStringArgument(() => argument));
        }

        /// <summary>
        /// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with byte default.
        /// </summary>
        /// <param name="argument">The argument.</param>
        public void ThrowArgumentOutOfRangeExceptionGivenDefaultByteArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Will.ProtectAgainstDefaultValueArgument(() => new byte()));
        }

        /// <summary>
        /// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with char default.
        /// </summary>
        /// <param name="argument">The argument.</param>
        public void ThrowArgumentOutOfRangeExceptionGivenDefaultCharArgument()
        {
           Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Will.ProtectAgainstDefaultValueArgument(() => new char()));
        }

        /// <summary>
        /// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with decimal default.
        /// </summary>
        /// <param name="argument">The argument.</param>
        public void ThrowArgumentOutOfRangeExceptionGivenDefaultDecimalArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Will.ProtectAgainstDefaultValueArgument(() => new decimal()));
        }

        /// <summary>
        /// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with double default.
        /// </summary>
        /// <param name="argument">The argument.</param>
        public void ThrowArgumentOutOfRangeExceptionGivenDefaultDoubleArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Will.ProtectAgainstDefaultValueArgument(() => new double()));
        }

        /// <summary>
        /// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with float default.
        /// </summary>
        /// <param name="argument">The argument.</param>
        public void ThrowArgumentOutOfRangeExceptionGivenDefaultFloatArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Will.ProtectAgainstDefaultValueArgument(() => new float()));
        }

        /// <summary>
        /// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with int default.
        /// </summary>
        /// <param name="argument">The argument.</param>
        public void ThrowArgumentOutOfRangeExceptionGivenDefaultIntArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Will.ProtectAgainstDefaultValueArgument(() => new int()));
        }

        /// <summary>
        /// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with long default.
        /// </summary>
        /// <param name="argument">The argument.</param>
        public void ThrowArgumentOutOfRangeExceptionGivenDefaultLongArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Will.ProtectAgainstDefaultValueArgument(() => new long()));
        }

        /// <summary>
        /// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with sbyte default.
        /// </summary>
        /// <param name="argument">The argument.</param>
        public void ThrowArgumentOutOfRangeExceptionGivenDefaultSbyteArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Will.ProtectAgainstDefaultValueArgument(() => new sbyte()));
        }

        /// <summary>
        /// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with short default.
        /// </summary>
        /// <param name="argument">The argument.</param>
        public void ThrowArgumentOutOfRangeExceptionGivenDefaultShortArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Will.ProtectAgainstDefaultValueArgument(() => new short()));
        }

        /// <summary>
        /// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with uint default.
        /// </summary>
        /// <param name="argument">The argument.</param>
        public void ThrowArgumentOutOfRangeExceptionGivenDefaultUintArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Will.ProtectAgainstDefaultValueArgument(() => new uint()));
        }

        /// <summary>
        /// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with ulong default.
        /// </summary>
        /// <param name="argument">The argument.</param>
        public void ThrowArgumentOutOfRangeExceptionGivenDefaultUlongArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Will.ProtectAgainstDefaultValueArgument(() => new ulong()));
        }

        /// <summary>
        /// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with ushort default.
        /// </summary>
        /// <param name="argument">The argument.</param>
        public void ThrowArgumentOutOfRangeExceptionGivenDefaultUshortArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Will.ProtectAgainstDefaultValueArgument(() => new ushort()));
        }

        /// <summary>
        /// Test to make sure that an exception is thrown when an assertion fails.
        /// </summary>
        [Test]
        public void ThrowExceptionGivenAssertionFails()
        {
            Assert.Throws<InvalidOperationException>(() => Guard.Will.ThrowExceptionOfType<InvalidOperationException>().When(false.IsFalse()));
        }
    }
}