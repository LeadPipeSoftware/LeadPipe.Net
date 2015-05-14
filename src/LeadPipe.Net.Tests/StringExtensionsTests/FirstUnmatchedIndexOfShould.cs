// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FirstUnmatchedIndexOfShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.StringExtensionsTests
{
	/// <summary>
	/// StringExtensions FirstUnmatchedIndexOf tests.
	/// </summary>
	[TestFixture]
	public class FirstUnmatchedIndexOfShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that the correct index is returned.
		/// </summary>
		/// <param name="firstString">The first string.</param>
		/// <param name="secondString">The second string.</param>
		/// <param name="handleDifferentLengths">if set to <c>true</c> [handle different lengths].</param>
		/// <param name="expectedReturnCode">The expected return code.</param>
		[TestCase("ABCD", "ABC", true, 3)]
		[TestCase("ABCD", "ABCD", true, -1)]
		[TestCase("ABCD", "ABC", false, -1)]
		[TestCase("ABCD", "", true, 0)]
		[TestCase("", "ABCD", true, 0)]
		[TestCase("ABCD", "", false, -1)]
		[TestCase("", "ABCD", false, -1)]
		[TestCase("ABCD", "ABCDEF", true, 4)]
		public void ReturnCorrectCode(string firstString, string secondString, bool handleDifferentLengths, int expectedReturnCode)
		{
			var returnCode = firstString.FirstUnmatchedIndexOf(secondString, handleDifferentLengths);

			Assert.IsTrue(returnCode.Equals(expectedReturnCode));
		}

		#endregion
	}
}