// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAlphabetShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.EnglishAlphabetProviderTests
{
	using System.Linq;

	using LeadPipe.Net.Core.Extensions;

	using LeadPipeSoftware.Net.Core;

	using NUnit.Framework;

	/// <summary>
	/// GetAlphabet tests.
	/// </summary>
	[TestFixture]
	public class GetAlphabetShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure we can get all the English alphabet characters.
		/// </summary>
		[Test]
		public void ReturnFullAlphabet()
		{
			// Arrange
			const string ExpectedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			IAlphabetProvider provider = new EnglishAlphabetProvider();

			// Act
			var result = new string(provider.GetAlphabet().ToArray());

			// Assert
			Assert.AreEqual(ExpectedCharacters, result);
		}

		#endregion
	}
}