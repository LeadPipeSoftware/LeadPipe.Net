// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsPrintableCharacterShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.StringExtensionsTests
{
	using LeadPipe.Net.Core.Extensions;

	using NUnit.Framework;

	/// <summary>
	/// StringExtensions IsPrintableCharacter tests.
	/// </summary>
	[TestFixture]
	public class IsPrintableCharacterShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to make sure that true is returned when the string has only printable characters.
		/// </summary>
		/// <param name="printableString">The string that is printable.</param>
		[TestCase("ABC")]
		[TestCase("abc")]
		[TestCase("123")]
		[TestCase("ABCabc1230")]
		[TestCase("ABCabc1230&^#!_)")]
		public void ReturnTrueGivenPrintableString(string printableString)
		{
			Assert.IsTrue(printableString.IsPrintableCharacter());
		}

		/// <summary>
		/// Test to make sure that false is returned when the string is empty.
		/// </summary>
		[Test]
		public void ReturnFalseGivenEmptyString()
		{
			Assert.IsFalse(string.Empty.IsPrintableCharacter());
		}

		/// <summary>
		/// Tests to make sure that false is returned when the string contains non-printable characters.
		/// </summary>
		/// <param name="nonPrintableString">The string that is not printable.</param>
		[TestCase("±")]
		[TestCase("°")]
		public void ReturnFalseGivenStringWithNonPrintableCharcaters(string nonPrintableString)
		{
			Assert.IsFalse(nonPrintableString.IsPrintableCharacter());
		}

		#endregion
	}
}