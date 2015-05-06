// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsNotNullShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.ObjectExtensionsTests
{
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// ObjectExtensions IsNotNullShould tests.
	/// </summary>
	[TestFixture]
	public class IsNotNullShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure true is returned if an object is not null.
		/// </summary>
		[Test]
		public void ReturnTrueGivenObjectIsNotNull()
		{
			string notNullString = "Four score and... how does that go again?";

			Assert.IsTrue(notNullString.IsNotNull());
		}

		/// <summary>
		/// Tests to make sure that false is returned if an object is null.
		/// </summary>
		[Test]
		public void ReturnFalseGivenObjectIsNull()
		{
			string nullString = null;

			Assert.IsFalse(nullString.IsNotNull());
		}

		#endregion
	}
}