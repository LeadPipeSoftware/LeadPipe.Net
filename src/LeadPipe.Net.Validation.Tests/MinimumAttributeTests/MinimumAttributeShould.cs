// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;
using System;
using System.Linq;

namespace LeadPipe.Net.Validation.Tests.MinimumAttributeTests
{
    /// <summary>
    /// Test the minimum attribute.
    /// </summary>
    [TestFixture]
    public class MinimumAttributeShould
    {
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
            var entity = new ValidatableEntity { MinimumStringOf5Property = nonNumericString };

            Assert.IsTrue(entity.Validate().Count > 0);
        }

        /// <summary>
        /// Ensures that it causes the validation to succeed given a valid number.
        /// </summary>
        /// <param name="validNumber">The valid number.</param>
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(Int32.MaxValue)]
        public void CauseValidationToSucceedGivenAValidNumber(int validNumber)
        {
            var entity = new ValidatableEntity { MinimumIntOf5Property = validNumber };

            Assert.IsTrue(entity.Validate().Count == 0);
        }

        /// <summary>
        /// Ensures that it causes validation to succeed given a valid numeric string.
        /// </summary>
        /// <param name="validNumericString">
        /// The numeric string.
        /// </param>
        [TestCase("012")]
        [TestCase("200")]
        [TestCase("08")]
        [TestCase("009")]
        [TestCase("+14")]
        [TestCase("5")]
        [TestCase("999")]
        [TestCase(null)]
        public void CauseValidationToSucceedGivenValidNumericString(string validNumericString)
        {
            var entity = new ValidatableEntity { MinimumStringOf5Property = validNumericString };

            var validationResults = entity.Validate();

            Assert.IsTrue(validationResults.Count == 0);
        }

        /// <summary>
        /// Ensure that it returns validation results with the member name given invalid numeric string.
        /// </summary>
        /// <param name="invalidNumber">
        /// The invalid numeric string.
        /// </param>
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(Int32.MinValue)]
        public void ReturnValidationResultsWithMemberNameGivenInvalidNumber(int invalidNumber)
        {
            var entity = new ValidatableEntity { MinimumIntOf5Property = invalidNumber };

            var results = entity.Validate();

            // The NumericProperty is causing the failure so that property should be included in the MemberNames...
            var result = results.FirstOrDefault(r => r.MemberNames.Contains("MinimumIntOf5Property"));

            Assert.IsTrue(result.IsNotNull());
        }

        /// <summary>
        /// Ensure that it returns validation results with the member name given invalid numeric string.
        /// </summary>
        /// <param name="invalidNumericString">
        /// The invalid numeric string.
        /// </param>
        [TestCase("0")]
        [TestCase("000")]
        [TestCase("02")]
        [TestCase("-14")]
        [TestCase("")]
        [TestCase("3")]
        [TestCase("")]
        public void ReturnValidationResultsWithMemberNameGivenInvalidNumericString(string invalidNumericString)
        {
            var entity = new ValidatableEntity { MinimumStringOf5Property = invalidNumericString };

            var results = entity.Validate();

            // The NumericProperty is causing the failure so that property should be included in the MemberNames...
            var result = results.FirstOrDefault(r => r.MemberNames.Contains("MinimumStringOf5Property"));

            Assert.IsTrue(result.IsNotNull());
        }
    }
}