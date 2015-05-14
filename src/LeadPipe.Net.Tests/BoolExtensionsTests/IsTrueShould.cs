// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsTrueShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.BoolExtensionsTests
{
	/// <summary>
	/// BoolExtensions IsTrue tests.
	/// </summary>
	[TestFixture]
	public class IsTrueShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure true is returned if the Boolean value is true.
		/// </summary>
		[Test]
		public void ReturnTrueGivenBoolIsTrue()
		{
			var trueBool = true;

			Assert.IsTrue(trueBool.IsTrue());
		}

		/// <summary>
		/// Tests to make sure true is returned if the Boolean value is true.
		/// </summary>
		[Test]
		public void ReturnFalseGivenBoolIsFalse()
		{
			var falseBool = false;

			Assert.IsFalse(falseBool.IsTrue());
		}

		#endregion
	}
}