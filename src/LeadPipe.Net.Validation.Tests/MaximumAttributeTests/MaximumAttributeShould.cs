// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaximumAttributeShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Validation.Tests.MaximumAttributeTests
{
    /// <summary>
	/// Test the maximum attribute.
	/// </summary>
	[TestFixture]
	public class MaximumAttributeShould
	{
		#region Public Methods

		/// <summary>
		/// Ensures that it causes validation to fail given a non-numeric value.
		/// </summary>
		/// <param name="nonNumericString">
		/// The non-numeric string.
		/// </param>
		[TestCase("012-")]
		[TestCase("A00")]
		[TestCase("0A2")]
		[TestCase("_01")]
		[TestCase("B999")]
		[TestCase("ABC")]
		public void CauseValidationToFailGivenNonNumericString(string nonNumericString)
		{
			var entity = new ValidatableEntity { MaximumStringOf5Property = nonNumericString };

			Assert.IsTrue(entity.Validate().Count > 0);
		}

		/// <summary>
		/// Ensures that it causes validation to succeed given a valid numeric string.
		/// </summary>
		/// <param name="validNumericString">
		/// The numeric string.
		/// </param>
		[TestCase("04")]
		[TestCase("3")]
		[TestCase("5")]
		[TestCase("004")]
		[TestCase("+4")]
		[TestCase("0")]
		[TestCase(null)]
		public void CauseValidationToSucceedGivenValidNumericString(string validNumericString)
		{
			var entity = new ValidatableEntity { MaximumStringOf5Property = validNumericString };

			var validationResults = entity.Validate();

			Assert.IsTrue(validationResults.Count == 0);
		}

		/// <summary>
		/// Ensures that it causes the validation to succeed given a valid number.
		/// </summary>
		/// <param name="validNumber">The valid number.</param>
		[TestCase(4)]
		[TestCase(5)]
		[TestCase(Int32.MinValue)]
		public void CauseValidationToSucceedGivenAValidNumber(int validNumber)
		{
			var entity = new ValidatableEntity { MaximumIntOf5Property = validNumber };

			Assert.IsTrue(entity.Validate().Count == 0);
		}

		/// <summary>
		/// Ensure that it returns validation results with the member name given invalid numeric string.
		/// </summary>
		/// <param name="invalidNumericString">
		/// The invalid numeric string.
		/// </param>
		[TestCase("006")]
		[TestCase("00099")]
		[TestCase("6")]
		[TestCase("99")]
		[TestCase("+09")]
		[TestCase("")]
		public void ReturnValidationResultsWithMemberNameGivenInvalidNumericString(string invalidNumericString)
		{
			var entity = new ValidatableEntity { MaximumStringOf5Property = invalidNumericString };

			var results = entity.Validate();

			// The NumericProperty is causing the failure so that property should be included in the MemberNames...
			var result = results.FirstOrDefault(r => r.MemberNames.Contains("MaximumStringOf5Property"));

			Assert.IsTrue(result.IsNotNull());
		}

		/// <summary>
		/// Ensure that it returns validation results with the member name given invalid numeric string.
		/// </summary>
		/// <param name="invalidNumber">
		/// The invalid numeric string.
		/// </param>
		[TestCase(6)]
		[TestCase(10)]
		[TestCase(99)]
		[TestCase(Int32.MaxValue)]
		public void ReturnValidationResultsWithMemberNameGivenInvalidNumber(int invalidNumber)
		{
			var entity = new ValidatableEntity { MaximumIntOf5Property = invalidNumber };

			var results = entity.Validate();

			// The NumericProperty is causing the failure so that property should be included in the MemberNames...
			var result = results.FirstOrDefault(r => r.MemberNames.Contains("MaximumIntOf5Property"));

			Assert.IsTrue(result.IsNotNull());
		}

		#endregion
	}
}