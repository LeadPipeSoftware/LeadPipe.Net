// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsNumericShould.cs" company="Lead Pipe Software">
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
	public class IsNumericShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that true is returned when the string has only numeric characters.
		/// </summary>
		/// <param name="numericString">The string that is numeric.</param>
		[TestCase("99999")]
		[TestCase("0")]
		[TestCase("123")]
		public void ReturnTrueGivenNumericString(string numericString)
		{
			Assert.IsTrue(numericString.IsNumeric());
		}

		/// <summary>
		/// Test to make sure that false is returned when the string is empty.
		/// </summary>
		[Test]
		public void ReturnFalseGivenEmptyString()
		{
			Assert.IsFalse(string.Empty.IsNumeric());
		}

		/// <summary>
		/// Tests to make sure that false is returned when the string contains non-numeric characters.
		/// </summary>
		/// <param name="nonNumericString">The string that is not numeric.</param>
		[TestCase(" ")]
		[TestCase("\t")]
		[TestCase("#")]
		[TestCase("ABC")]
		[TestCase(",")]
		[TestCase(";")]
		[TestCase("@")]
		[TestCase("#*7A65s")]
		public void ReturnFalseGivenNonNumericString(string nonNumericString)
		{
			Assert.IsFalse(nonNumericString.IsNumeric());
		}

		#endregion
	}
}