// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsAlphanumericShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.StringExtensionsTests
{
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// StringExtensions ContainsWhiteSpace tests.
	/// </summary>
	[TestFixture]
	public class IsAlphanumericShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that true is returned when the string has only alphanumeric characters.
		/// </summary>
		/// <param name="alphanumericString">The string that is alphanumeric.</param>
		[TestCase("ABC")]
		[TestCase("ABC123")]
		[TestCase("123")]
		public void ReturnTrueGivenAlphanumericString(string alphanumericString)
		{
			Assert.IsTrue(alphanumericString.IsAlphanumeric());
		}

		/// <summary>
		/// Test to make sure that false is returned when the string is empty.
		/// </summary>
		[Test]
		public void ReturnFalseGivenEmptyString()
		{
			Assert.IsFalse(string.Empty.IsAlphanumeric());
		}

		/// <summary>
		/// Tests to make sure that false is returned when the string contains non-alphanumeric characters.
		/// </summary>
		/// <param name="nonAlphanumericString">The string that is not alphanumeric.</param>
		[TestCase(" ")]
		[TestCase("\t")]
		[TestCase("#")]
		[TestCase(",")]
		[TestCase(";")]
		[TestCase("@")]
		[TestCase("#*7A65s")]
		public void ReturnFalseGivenStringWithoutWhiteSpace(string nonAlphanumericString)
		{
			Assert.IsFalse(nonAlphanumericString.IsAlphanumeric());
		}

		#endregion
	}
}