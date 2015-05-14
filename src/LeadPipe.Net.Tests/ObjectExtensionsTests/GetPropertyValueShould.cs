// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetPropertyValueShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.ObjectExtensionsTests
{
	/// <summary>
	/// ObjectExtensions GetPropertyValue tests.
	/// </summary>
	[TestFixture]
	public class GetPropertyValueShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that the value of a property is returned.
		/// </summary>
		[Test]
		public void ReturnPropertyValue()
		{
			var testObject = DateTime.Now;

			Assert.IsTrue(testObject.GetPropertyValue("Day").Equals(DateTime.Now.Day));
		}

		#endregion
	}
}