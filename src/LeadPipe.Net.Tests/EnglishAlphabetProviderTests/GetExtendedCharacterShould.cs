// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetExtendedCharacterShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.EnglishAlphabetProviderTests
{
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