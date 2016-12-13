// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Validation.Tests.AlphaAttributeTests
{
    /// <summary>
    /// The alpha attribute should.
    /// </summary>
    [TestFixture]
    public class AlphaAttributeShould
    {
        /// <summary>
        /// Test to ensure that when the Alpha attribute is present with extra characters allowed that it only
        /// allows the extra characters specified.
        /// </summary>
        /// <param name="invalidValue">
        /// The invalid value that is expected to cause validation to fail.
        /// </param>
        [TestCase("eh&")]
        [TestCase("ABC+")]
        [TestCase("xyz%")]
        public void CauseValidationToFailGivenAlphaPlusWithInvalidCharacters(string invalidValue)
        {
            var validatableEntity = new ValidatableEntity { AlphaPlusWithNoLeadingNoTrailing = invalidValue };

            Assert.IsFalse(validatableEntity.Validate().Count == 0);
        }

        /// <summary>
        /// Test to ensure that if spaces are permitted by the Alpha attribute that it does not interfere
        /// with the NoLeadingWhitespace and NoTrailingWhitespace attributes.
        /// </summary>
        /// <param name="validValue">
        /// The valid value that is expected to pass validation.
        /// </param>
        [TestCase("# AB")]
        [TestCase("$JR")]
        [TestCase("$ #")]
        [TestCase("$   xy")]
        public void CauseValidationToSucceedGivenAlphaPlusSpaceWithNoLeadingNoTrailing(string validValue)
        {
            var validatableEntity = new ValidatableEntity { AlphaPlusWithNoLeadingNoTrailing = validValue };

            Assert.IsTrue(validatableEntity.Validate().Count == 0);
        }

        /// <summary>
        /// The cause validation to succeed given extra characters.
        /// </summary>
        /// <param name="validValue">
        /// The valid value that is expected to pass validation.
        /// </param>
        [TestCase("A B")]
        [TestCase("-Ert")]
        [TestCase("C++")]
        [TestCase("+-X Degrees")]
        public void CauseValidationToSucceedGivenExtraCharacters(string validValue)
        {
            var validatableEntity = new ValidatableEntity { AlphaPlusProperty = validValue };

            Assert.IsTrue(validatableEntity.Validate().Count == 0);
        }

        /// <summary>
        /// Test to make sure the IsValidate return false given invalid string for AlphaPlus property.
        /// </summary>
        /// <param name="validValue">
        /// The valid value that is expected to pass validation.
        /// </param>
        [TestCase("AB?")]
        [TestCase("AB2")]
        [TestCase("C++1")]
        public void ReturnFalseGivenInvalidStringForAlPhaPlusProperty(string validValue)
        {
            var validatableEntity = new ValidatableEntity { AlphaPlusProperty = validValue };

            Assert.False(validatableEntity.IsValid());
        }

        /// <summary>
        /// The cause validation to succeed given extra characters.
        /// </summary>
        /// <param name="validValue">
        /// The valid value that is expected to pass validation.
        /// </param>
        [TestCase("A B")]
        [TestCase("-Ert")]
        [TestCase("C++")]
        [TestCase("+-X Degrees")]
        public void ReturnFalseGivenInvalidStringForAlphaProperty(string validValue)
        {
            var validatableEntity = new ValidatableEntity { AlphaProperty = validValue };

            Assert.False(validatableEntity.IsValid());
        }
    }
}