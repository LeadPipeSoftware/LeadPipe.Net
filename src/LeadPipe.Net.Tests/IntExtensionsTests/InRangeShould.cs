// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InRangeShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.IntExtensionsTests
{
	/// <summary>
	/// IntExtensions InRange tests.
	/// </summary>
	[TestFixture]
	public class InRangeShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that the correct return value is given.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="lowerValue">The lower value.</param>
		/// <param name="upperValue">The upper value.</param>
		/// <param name="expectedResult">if set to <c>true</c> [expected result].</param>
		[TestCase(1, 0, 2, true)]
		[TestCase(1, 1, 2, true)]
		[TestCase(1, 1, 1, true)]
		[TestCase(1, 2, 5, false)]
		[TestCase(50, 1, 100, true)]
		[TestCase(0, 0, 1, true)]
		public void ReturnCorrectValue(int value, int lowerValue, int upperValue, bool expectedResult = false)
		{
			Assert.IsTrue(value.InRange(lowerValue, upperValue) == expectedResult);
		}

		#endregion
	}
}