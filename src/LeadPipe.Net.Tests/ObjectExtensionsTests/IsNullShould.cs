// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsNullShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.ObjectExtensionsTests
{
	/// <summary>
	/// ObjectExtensions IsNull tests.
	/// </summary>
	[TestFixture]
	public class IsNullShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure true is returned if an object is null.
		/// </summary>
		[Test]
		public void ReturnTrueGivenObjectIsNull()
		{
			string nullString = null;

			Assert.IsTrue(nullString.IsNull());
		}

		/// <summary>
		/// Tests to make sure that false is returned if an object is not null.
		/// </summary>
		[Test]
		public void ReturnFalseGivenObjectIsNotNull()
		{
			string notNullString = "I think the past is behind us. It'd be real confusing if not. But anyway.";

			Assert.IsFalse(notNullString.IsNull());
		}

		#endregion
	}
}