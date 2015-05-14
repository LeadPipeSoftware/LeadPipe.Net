// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuardShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.GuardTests
{
	using Guard = Guard;

	/// <summary>
	/// Guard tests.
	/// </summary>
	[TestFixture]
	public class GuardShould
	{
		#region Public Methods

		/// <summary>
		/// Test to make sure that an exception is thrown when an assertion fails.
		/// </summary>
		[Test]
		public void NotThrowInvalidOperationExceptionGivenInvalidOperationExceptionTypeAndAssertionIsTrue()
		{
			// Arrange

			// Act
			Guard.Will.ThrowExceptionOfType<InvalidOperationException>().When(false.IsTrue());

			// Assert
		}

		/// <summary>
		/// Test to make sure that an exception is thrown when an assertion fails.
		/// </summary>
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ThrowExceptionGivenFalseEqualsFalseAssertion()
		{
			// Arrange

			// Act
			Guard.Will.ThrowExceptionOfType<InvalidOperationException>().When(false.IsFalse());

			// Assert
		}

		/// <summary>
		/// Test to make sure that an ArgumentNullException is thrown when checking for a null argument.
		/// </summary>
		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ThrowArgumentNullExceptionGivenNullArgument()
		{
			// Arrange
			string nullArgument = null;

			// Act
			Guard.Will.ProtectAgainstNullArgument(() => nullArgument);

			// Assert
		}

		/// <summary>
		/// Test to ensure that exception is thrown for both null or empty string when calling
		/// ProtectAgainstNullOrEmptyStringArgument.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[TestCase(null)]
		[TestCase("")]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ThrowArgumentNullExceptionGivenNullOrEmptyStringArgument(string argument)
		{
			Guard.Will.ProtectAgainstNullOrEmptyStringArgument(() => argument);
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
		[ExpectedException(typeof(InvalidOperationException))]
		public void ThrowAnExceptionGivenNullObject()
		{
			// Arrange
			string nullString = null;

			// Act
			Guard.Will.ThrowException().When(nullString.IsNull());

			// Assert
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
		/// Test to make sure that an exception is thrown when an assertion fails.
		/// </summary>
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ThrowAnInvalidOperationExceptionGivenNullObject()
		{
			// Arrange
			string nullString = null;

			// Act
			Guard.Will.ThrowExceptionOfType<InvalidOperationException>().When(nullString.IsNull());

			// Assert
		}

		#endregion
	}
}