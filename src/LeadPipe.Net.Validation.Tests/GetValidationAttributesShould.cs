// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Validation.Tests
{
    /// <summary>
    /// GetValidationAttributes tests.
    /// </summary>
    [TestFixture]
    public class GetValidationAttributesShould
    {
        /// <summary>
        /// Test to make sure that a complete set of validation attributes is returned.
        /// </summary>
        [Test]
        public void ReturnAllValidationAttributes()
        {
            var attributes = typeof(HasValidationAttributes).GetValidationAttributes();

            Assert.That(attributes.Count == 4);
        }
    }
}