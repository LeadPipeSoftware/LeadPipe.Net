// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToDictionaryShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.ObjectExtensionsTests
{
	using System;

	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// ObjectExtensions ToDictionary tests.
	/// </summary>
	[TestFixture]
	public class ToDictionaryShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that a dictionary representing the objects properties is returned.
		/// </summary>
		[Test]
		public void ReturnDictionary()
		{
			var testObject = DateTime.Now.ToDictionary();

			Assert.IsTrue(testObject.Keys.Contains("Day"));
		}

		#endregion
	}
}