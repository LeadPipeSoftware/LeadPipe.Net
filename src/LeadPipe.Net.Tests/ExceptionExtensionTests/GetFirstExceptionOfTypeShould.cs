// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetFirstExceptionOfTypeShould.cs" company="Lead Pipe Software">
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
	/// ExceptionExtensions GetFirstExceptionOfType tests.
	/// </summary>
	[TestFixture]
	public class GetFirstExceptionOfTypeShould
	{
		#region Public Methods

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

		#endregion
	}
}