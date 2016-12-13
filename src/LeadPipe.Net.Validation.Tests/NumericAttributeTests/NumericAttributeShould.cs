// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LeadPipe.Net.Validation.Tests.NumericAttributeTests
{
    /// <summary>
    /// Test the numeric attribute.
    /// </summary>
    [TestFixture]
    public class NumericAttributeShould
    {
        /// <summary>
        /// Ensures that it causes validation to fail given an invalid numeric string.
        /// </summary>
        /// <param name="invalidNumericString">
        /// The invalid numeric string.
        /// </param>
        [TestCase("012-")]
        [TestCase("A00")]
        [TestCase("0A2")]
        [TestCase("_01")]
        [TestCase("+1")]
        [TestCase("B999")]
        [TestCase("ABC")]
        public void CauseValidationToFailGivenAnInvalidNumericString(string invalidNumericString)
        {
            var entity = new ValidatableEntity { NumericProperty = invalidNumericString };

            Assert.IsTrue(entity.Validate().Count > 0);
        }

        /// <summary>
        /// Ensures that it causes validation to succeed given a valid numeric string.
        /// </summary>
        /// <param name="validNumericString">
        /// The numeric string.
        /// </param>
        [TestCase("012")]
        [TestCase("200")]
        [TestCase("02")]
        [TestCase("001")]
        [TestCase("1")]
        [TestCase("999")]
        [TestCase("000")]
        [TestCase("")]
        [TestCase(null)]
        public void CauseValidationToSucceedGivenAValidNumericString(string validNumericString)
        {
            var entity = new ValidatableEntity { NumericProperty = validNumericString };

            Assert.IsTrue(entity.Validate().Count == 0);
        }

        /// <summary>
        /// Ensures that it causes validation to succeed given valid numeric string with extra characters.
        /// </summary>
        /// <param name="validNumericString">
        /// The valid numeric string.
        /// </param>
        /// <remarks>
        /// The NumericPlusAbcProperty property allows the characters A, B, and C as extra characters. This is case
        /// sensitive so a, b, or c will fail validation using this attribute instance.
        /// </remarks>
        [TestCase("012A")]
        [TestCase("A00")]
        [TestCase("0A2")]
        [TestCase("C01")]
        [TestCase("11C")]
        [TestCase("B9")]
        [TestCase("ABC")]
        [TestCase("B")]
        [TestCase("A")]
        [TestCase("C")]
        [TestCase("")]
        [TestCase(null)]
        public void CauseValidationToSucceedGivenValidNumericStringWithExtraCharacters(string validNumericString)
        {
            var entity = new ValidatableEntity { NumericPlusAbcProperty = validNumericString };

            Assert.IsTrue(entity.Validate().Count == 0);
        }

        /// <summary>
        /// Ensure that it returns validation results with the member name given invalid numeric string.
        /// </summary>
        /// <param name="invalidNumericString">
        /// The invalid numeric string.
        /// </param>
        [TestCase("012-")]
        [TestCase("A00")]
        [TestCase("0A2")]
        [TestCase("_01")]
        [TestCase("+1")]
        [TestCase("B999")]
        [TestCase("ABC")]
        public void ReturnValidationResultsWithMemberNameGivenInvalidNumericString(string invalidNumericString)
        {
            var entity = new ValidatableEntity { NumericProperty = invalidNumericString };

            List<ValidationResult> results = entity.Validate();

            // The NumericProperty is causing the failure so that property should be included in the MemberNames...
            ValidationResult result = results.FirstOrDefault(r => r.MemberNames.Contains("NumericProperty"));

            Assert.IsTrue(result.IsNotNull());
        }
    }
}