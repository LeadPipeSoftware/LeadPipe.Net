// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToMD5HashShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
	/// <summary>
	/// StringExtensions ToMD5Hash tests.
	/// </summary>
	[TestFixture]
	public class ToMD5HashShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that an MD5 hash of a string is returned.
		/// </summary>
		/// <param name="inputString">The input string.</param>
		/// <param name="hashString">The hash string.</param>
		[TestCase("some random string", "76712b27e483bc0ba2ce8d2109210c22")]
		public void ReturnTheMD5HashOfTheString(string inputString, string hashString)
		{
			var convertedInput = inputString.ToMD5Hash();

			Assert.IsTrue(convertedInput.Equals(hashString));
		}

		#endregion
	}
}