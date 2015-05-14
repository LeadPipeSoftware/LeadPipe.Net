// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PercentageOfShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.DecimalExtensionsTests
{
	/// <summary>
	/// PercentageOf extension method tests.
	/// </summary>
	public class PercentageOfShould
	{
		#region Public Methods and Operators

		/// <summary>
		/// Tests to ensure that the percentage of a decimal is returned.
		/// </summary>
		[Test]
		public void ReturnPercentageOfDecimal()
		{
			Assert.AreEqual(33.3M, 100.0M.PercentageOf(33.3M));
		}

		/// <summary>
		/// Tests to ensure that the percentage of an integer is returned.
		/// </summary>
		[Test]
		public void ReturnPercentageOfInt()
		{
			Assert.AreEqual(33.0M, 100.0M.PercentageOf(33));
		}

		/// <summary>
		/// Tests to ensure that the percentage of a long is returned.
		/// </summary>
		[Test]
		public void ReturnPercentageOfLong()
		{
			Assert.AreEqual(200.0M, 100.0M.PercentageOf((long)200));
		}

		#endregion
	}
}