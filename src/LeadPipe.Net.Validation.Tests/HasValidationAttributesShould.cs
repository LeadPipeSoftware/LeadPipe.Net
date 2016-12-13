// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Validation.Tests
{
    /// <summary>
    /// HasValidationAttributes tests.
    /// </summary>
    [TestFixture]
    public class HasValidationAttributesShould
    {
        /// <summary>
        /// Test to make sure that a false is returned when a type does not have validation attributes.
        /// </summary>
        [Test]
        public void ReturnFalseIfTypeDoesNotHaveValidationAttributes()
        {
            Assert.False(typeof(DoesNotHaveValidationAttributes).HasValidationAttributes());
        }

        /// <summary>
        /// Test to make sure that a true is returned when a type has validation attributes.
        /// </summary>
        [Test]
        public void ReturnTrueIfTypeHasValidationAttributes()
        {
            Assert.True(typeof(HasValidationAttributes).HasValidationAttributes());
        }
    }
}