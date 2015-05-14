// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormattedWithShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
	/// <summary>
	///     StringExtensions FormattedWith method tests.
	/// </summary>
	[TestFixture]
	public class FormattedWithShould
	{
		/// <summary>
		///     Tests to make sure strings are formatted.
		/// </summary>
		/// <param name="value">The string to insert.</param>
		[TestCase("99999")]
		[TestCase("ABC")]
		[TestCase("")]
		public void ReturnFormattedString(string value)
		{
			Assert.IsTrue(value.FormattedWith("AAA{0}ZZZ").Equals("AAA" + value + "ZZZ"));
		}

		/// <summary>
		///     Tests to make sure an exception is NOT thrown if there is no format token.
		/// </summary>
		[Test]
		public void NotThrowExceptionGivenNoFormatToken()
		{
			"ABC".FormattedWith("ZZZ");
		}

		/// <summary>
		///  Tests to make sure strings are formatted.
		/// </summary>
		[Test]
		public void ReturnFormattedStringUsingMultipleParams()
		{
			var param1 = "the count is";
			var param2 = 2;
			var result = "Given the list {0} = {1}".FormattedWith(param1, param2);

			Assert.IsTrue(string.CompareOrdinal(result, "Given the list the count is = 2") == 0);
		}
	}
}