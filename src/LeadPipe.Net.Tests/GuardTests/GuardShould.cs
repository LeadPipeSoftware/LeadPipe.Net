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
		public void ThrowExceptionGivenAssertionFails()
		{
			// Arrange

			// Act
			Guard.Will.ThrowExceptionOfType<InvalidOperationException>().When(false.IsFalse());

			// Assert
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
		/// Test to make sure that an action is invoked AND exception is thrown when an assertion fails.
		/// </summary>
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void InvokeActionAndThrowExceptionGivenAssertionFails()
		{
			// Arrange
			var testVariable = false;

			// Act
			Guard
				.Will
					.ThrowExceptionOfType<InvalidOperationException>()
					.Execute(() => testVariable = true)
				.When(false.IsFalse());

			// Assert
			Assert.That(testVariable.IsTrue());
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
		/// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with a null value.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[TestCase(null)]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowArgumentNullExceptionGivenNullDefaultTypeArgument(string argument)
		{
			Guard.Will.ProtectAgainstDefaultValueArgument(() => argument);
		}

		/// <summary>
		/// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with int default.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowArgumentOutOfRangeExceptionGivenDefaultIntArgument()
		{
			Guard.Will.ProtectAgainstDefaultValueArgument(() => new int());
		}

		/// <summary>
		/// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with byte default.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowArgumentOutOfRangeExceptionGivenDefaultByteArgument()
		{
			Guard.Will.ProtectAgainstDefaultValueArgument(() => new byte());
		}

		/// <summary>
		/// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with char default.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowArgumentOutOfRangeExceptionGivenDefaultCharArgument()
		{
			Guard.Will.ProtectAgainstDefaultValueArgument(() => new char());
		}

		/// <summary>
		/// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with decimal default.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowArgumentOutOfRangeExceptionGivenDefaultDecimalArgument()
		{
			Guard.Will.ProtectAgainstDefaultValueArgument(() => new decimal());
		}

		/// <summary>
		/// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with double default.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowArgumentOutOfRangeExceptionGivenDefaultDoubleArgument()
		{
			Guard.Will.ProtectAgainstDefaultValueArgument(() => new double());
		}

		/// <summary>
		/// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with float default.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowArgumentOutOfRangeExceptionGivenDefaultFloatArgument()
		{
			Guard.Will.ProtectAgainstDefaultValueArgument(() => new float());
		}

		/// <summary>
		/// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with long default.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowArgumentOutOfRangeExceptionGivenDefaultLongArgument()
		{
			Guard.Will.ProtectAgainstDefaultValueArgument(() => new long());
		}

		/// <summary>
		/// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with sbyte default.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowArgumentOutOfRangeExceptionGivenDefaultSbyteArgument()
		{
			Guard.Will.ProtectAgainstDefaultValueArgument(() => new sbyte());
		}

		/// <summary>
		/// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with short default.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowArgumentOutOfRangeExceptionGivenDefaultShortArgument()
		{
			Guard.Will.ProtectAgainstDefaultValueArgument(() => new short());
		}

		/// <summary>
		/// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with uint default.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowArgumentOutOfRangeExceptionGivenDefaultUintArgument()
		{
			Guard.Will.ProtectAgainstDefaultValueArgument(() => new uint());
		}

		/// <summary>
		/// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with ulong default.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowArgumentOutOfRangeExceptionGivenDefaultUlongArgument()
		{
			Guard.Will.ProtectAgainstDefaultValueArgument(() => new ulong());
		}

		/// <summary>
		/// Test to ensure that exception is thrown when calling ProtectAgainstDefaultValueArgument with ushort default.
		/// </summary>
		/// <param name="argument">The argument.</param>
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ThrowArgumentOutOfRangeExceptionGivenDefaultUshortArgument()
		{
			Guard.Will.ProtectAgainstDefaultValueArgument(() => new ushort());
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

		/// <summary>
		/// Test to make sure that an exception with a relationship is thrown when an assertion fails.
		/// </summary>
		[Test]
		[ExpectedException(typeof(InvalidOperationException), ExpectedMessage = "[TEST]")]
		public void ThrowAnInvalidOperationExceptionWithRelationshipIdGivenNullObject()
		{
			// Arrange
			string nullString = null;
			string relationship = "TEST";

			// Act
			Guard
				.Will
				.AssociateExceptionsWith(relationship)
				.And
				.ThrowExceptionOfType<InvalidOperationException>()
				.When(nullString.IsNull());

			// Assert
		}

		/// <summary>
		/// Test to make sure that an exception with a relationship and custom message is thrown when an assertion fails.
		/// </summary>
		[Test]
		[ExpectedException(typeof(InvalidOperationException), ExpectedMessage = "[TEST] Custom message goes here.")]
		public void ThrowAnInvalidOperationExceptionWithCustomMessageAndRelationshipIdGivenNullObject()
		{
			// Arrange
			string nullString = null;
			string relationship = "TEST";

			// Act
			Guard
				.Will
				.AssociateExceptionsWith(relationship)
				.And
				.ThrowExceptionOfType<InvalidOperationException>("Custom message goes here.")
				.When(nullString.IsNull());

			// Assert
		}

		#endregion
	}
}