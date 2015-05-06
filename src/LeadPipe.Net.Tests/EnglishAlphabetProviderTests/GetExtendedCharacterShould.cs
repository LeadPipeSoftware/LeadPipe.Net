// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetExtendedCharacterShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.EnglishAlphabetProviderTests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using LeadPipe.Net.Core.Extensions;

	using LeadPipeSoftware.Net.Core;

	using NUnit.Framework;

	/// <summary>
	/// GetExtendedCharacters tests.
	/// </summary>
	[TestFixture]
	public class GetExtendedCharacterShould
	{
		#region Public Methods and Operators

		/// <summary>
		/// Tests to make sure we can get all the Extended characters.
		/// </summary>
		[Test]
		public void ReturnExtendedCharacters()
		{
			// Arrange
			var expectedCharacters = new List<char> { Convert.ToChar(176), Convert.ToChar(177) };

			IAlphabetProvider provider = new EnglishAlphabetProvider();

			// Act
			var result = new string(provider.GetExtendedCharacters().ToArray());

			// Assert
			Assert.AreEqual(expectedCharacters, result);
		}

		#endregion
	}
}