// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateRandomStringShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.EnglishAlphabetProviderTests
{
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// CreateRandomString tests.
	/// </summary>
	[TestFixture]
	public class CreateRandomStringShould
	{
		#region Public Methods

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

		#endregion
	}
}