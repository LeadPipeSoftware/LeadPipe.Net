// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReduceShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.StringExtensionsTests
{
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// StringExtensions Reduce tests.
	/// </summary>
	[TestFixture]
	public class ReduceShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure a proper reduced string is returned.
		/// </summary>
		/// <param name="inputString">The input string.</param>
		/// <param name="reducedString">The reduced string.</param>
		/// <param name="reducedStringLength">Length of the reduced string.</param>
		[TestCase("This is the long string that should be reduced", "This is the long ...", 20)]
		public void ReturnReducedString(string inputString, string reducedString, int reducedStringLength)
		{
			var convertedInput = inputString.Reduce(reducedStringLength);

			Assert.IsTrue(convertedInput.Length.Equals(reducedStringLength));
			Assert.IsTrue(convertedInput.Equals(reducedString));
		}

		#endregion
	}
}