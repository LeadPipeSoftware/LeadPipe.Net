// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PercentOfShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.DecimalExtensionsTests
{
	/// <summary>
	/// PercentOf extension method tests.
	/// </summary>
	public class PercentOfShould
	{
		#region Public Methods and Operators

		/// <summary>
		/// Tests to ensure that the percent of a decimal is returned.
		/// </summary>
		[Test]
		public void ReturnPercentOfDecimal()
		{
			Assert.AreEqual(33.3M, 33.3M.PercentOf(100.0M));
		}

		/// <summary>
		/// Tests to ensure that the percent of an integer is returned.
		/// </summary>
		[Test]
		public void ReturnPercentOfInt()
		{
			Assert.AreEqual(33.0M, 33.0M.PercentOf(100));
		}

		/// <summary>
		/// Tests to ensure that the percent of a long is returned.
		/// </summary>
		[Test]
		public void ReturnPercentOfLong()
		{
			Assert.AreEqual(200.0M, 200.0M.PercentOf((long)100));
		}

		#endregion
	}
}