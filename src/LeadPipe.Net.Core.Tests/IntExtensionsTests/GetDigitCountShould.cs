// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetDigitCountShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.IntExtensionsTests
{
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// IntExtensions GetDigitCount tests.
	/// </summary>
	[TestFixture]
	public class GetDigitCountShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that true is returned when the string has only alphanumeric characters.
		/// </summary>
		/// <param name="intToInspect">The integer to inspect.</param>
		/// <param name="expectedDigitCount">The expected digit count.</param>
		/// <param name="countSignAsDigit">if set to <c>true</c> [count sign as digit].</param>
		[TestCase(0, 1, false)]
		[TestCase(10, 2, false)]
		[TestCase(100, 3, false)]
		[TestCase(1000, 4, false)]
		[TestCase(10000, 5, false)]
		[TestCase(100000, 6, false)]
		[TestCase(1000000, 7, false)]
		[TestCase(10000000, 8, false)]
		[TestCase(100000000, 9, false)]
		[TestCase(-1, 2, true)]
		[TestCase(-10, 3, true)]
		[TestCase(-100, 4, true)]
		[TestCase(-1000, 5, true)]
		[TestCase(-10000, 6, true)]
		[TestCase(-100000, 7, true)]
		[TestCase(-1000000, 8, true)]
		[TestCase(-10000000, 9, true)]
		[TestCase(-100000000, 10, true)]
		public void ReturnAccurateDigitCount(int intToInspect, int expectedDigitCount, bool countSignAsDigit = false)
		{
			Assert.IsTrue(intToInspect.GetDigitCount(countSignAsDigit).Equals(expectedDigitCount));
		}

		#endregion
	}
}