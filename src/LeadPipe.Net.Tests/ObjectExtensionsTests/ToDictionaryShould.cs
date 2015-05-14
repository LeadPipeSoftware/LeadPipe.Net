// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToDictionaryShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.ObjectExtensionsTests
{
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