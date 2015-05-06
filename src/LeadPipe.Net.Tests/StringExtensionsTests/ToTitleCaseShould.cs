// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToTitleCaseShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.StringExtensionsTests
{
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// StringExtensions ToTitleCase tests.
	/// </summary>
	[TestFixture]
	public class ToTitleCaseShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure a proper title case is returned.
		/// </summary>
		/// <param name="inputString">The input string.</param>
		/// <param name="titleCaseString">The title case string.</param>
		[TestCase("this is a title", "This Is A Title")]
		[TestCase("ThisIsTechnicallyTitleCased", "Thisistechnicallytitlecased")]
		[TestCase("CoMe and lIsT3n 70 my 5Tory 4B0u7 A MAN nAmEd Jed", "Come And List3n 70 My 5Tory 4B0u7 A MAN Named Jed")]
		public void ReturnInputAsTitleCase(string inputString, string titleCaseString)
		{
			var convertedInput = inputString.ToTitleCase();

			Assert.IsTrue(convertedInput.Equals(titleCaseString));
		}

		#endregion
	}
}