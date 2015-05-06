// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsOrContainsExceptionOfTypeShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.ExceptionExtensionTests
{
	using System;
	using System.IO;

	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// ExceptionExtensions IsOrContainsExceptionOfType tests.
	/// </summary>
	[TestFixture]
	public class IsOrContainsExceptionOfTypeShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure true is returned if the exception is of a particular type.
		/// </summary>
		[Test]
		public void ReturnTrueGivenExceptionIsOfType()
		{
			// Arrange
			var exception = new NullReferenceException();

			// Act
			var isOfType = exception.IsOrContainsExceptionOfType<NullReferenceException>();

			// Assert
			Assert.IsTrue(isOfType);
		}

		/// <summary>
		/// Tests to make sure true is returned if the downcasted exception is of a particular type.
		/// </summary>
		[Test]
		public void ReturnTrueGivenDowncastedExceptionIsOfType()
		{
			// Arrange
			var exception = new NullReferenceException();
			var downcastedException = exception as Exception;

			// Act
			var isOfType = downcastedException.IsOrContainsExceptionOfType<NullReferenceException>();

			// Assert
			Assert.IsTrue(isOfType);
		}

		/// <summary>
		/// Tests to make sure true is returned if the exception contains a particular type.
		/// </summary>
		[Test]
		public void ReturnTrueGivenExceptionContainsType()
		{
			// Arrange
			var innerException = new NotImplementedException();
			var exception = new NullReferenceException("Test", innerException);

			// Act
			var isOfType = exception.IsOrContainsExceptionOfType<NotImplementedException>();

			// Assert
			Assert.IsTrue(isOfType);
		}

		/// <summary>
		/// Tests to make sure false is returned if the exception is not of a particular type.
		/// </summary>
		[Test]
		public void ReturnFalseGivenExceptionIsNotOfType()
		{
			// Arrange
			var exception = new NullReferenceException();

			// Act
			var isOfType = exception.IsOrContainsExceptionOfType<NotImplementedException>();

			// Assert
			Assert.IsFalse(isOfType);
		}

		/// <summary>
		/// Tests to make sure false is returned if the exception does not contain a particular type.
		/// </summary>
		[Test]
		public void ReturnFalseGivenExceptionDoesNotContainType()
		{
			// Arrange
			var innerException = new NotImplementedException();
			var exception = new NullReferenceException("Test", innerException);

			// Act
			var isOfType = exception.IsOrContainsExceptionOfType<FileNotFoundException>();

			// Assert
			Assert.IsFalse(isOfType);
		}

		#endregion
	}
}