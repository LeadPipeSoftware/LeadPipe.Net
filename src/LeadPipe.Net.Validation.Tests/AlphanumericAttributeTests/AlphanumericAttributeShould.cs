// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AlphanumericAttributeShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Validation.Tests.AlphanumericAttributeTests
{
    /// <summary>
	/// The alphanumeric attribute should.
	/// </summary>
	[TestFixture]
	public class AlphanumericAttributeShould
	{
		#region Public Methods

		/// <summary>
		/// Test to ensure that when the Alphanumeric attribute is present with extra characters allowed that it only
		/// allows the extra characters specified.
		/// </summary>
		/// <param name="invalidValue">
		/// The invalid value that is expected to cause validation to fail.
		/// </param>
		[TestCase("34&")]
		[TestCase("ABC+")]
		[TestCase("123%")]
		public void CauseValidationToFailGivenAlphanumericPlusWithInvalidCharacters(string invalidValue)
		{
			var validatableEntity = new ValidatableEntity { AlphanumericPlusWithNoLeadingNoTrailing = invalidValue };

			Assert.IsFalse(validatableEntity.Validate().Count == 0);
		}

		/// <summary>
		/// Test to ensure that if spaces are permitted by the Alphanumeric attribute that it does not interfere
		/// with the NoLeadingWhitespace and NoTrailingWhitespace attributes.
		/// </summary>
		/// <param name="validValue">
		/// The valid value that is expected to pass validation.
		/// </param>
		[TestCase("# 34")]
		[TestCase("$45")]
		[TestCase("$ #")]
		[TestCase("$   32")]
		public void CauseValidationToSucceedGivenAlphanumericPlusSpaceWithNoLeadingNoTrailing(string validValue)
		{
			var validatableEntity = new ValidatableEntity { AlphanumericPlusWithNoLeadingNoTrailing = validValue };

			Assert.IsTrue(validatableEntity.Validate().Count == 0);
		}

		/// <summary>
		/// The cause validation to succeed given extra characters.
		/// </summary>
		/// <param name="validValue">
		/// The valid value that is expected to pass validation.
		/// </param>
		[TestCase("1 2")]
		[TestCase("-345")]
		[TestCase("C++")]
		[TestCase("+-45 Degrees")]
		public void CauseValidationToSucceedGivenExtraCharacters(string validValue)
		{
			var validatableEntity = new ValidatableEntity { AlphanumericPlusProperty = validValue };

			Assert.IsTrue(validatableEntity.Validate().Count == 0);
		}

		#endregion
	}
}