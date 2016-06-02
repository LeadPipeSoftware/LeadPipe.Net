// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System;
using System.Linq;

namespace LeadPipe.Net.Validation.Tests.LeadPipeNetInvalidEntityExceptionTests
{
    /// <summary>
    /// GetValidationResultsAsList method tests.
    /// </summary>
    [TestFixture]
    public class GetValidationResultsAsListShould
    {
        /// <summary>
        /// Test to make sure that validation results are returned as a list.
        /// </summary>
        [Test]
        public void ReturnValidationResults()
        {
            // Arrange
            var entityId = Guid.NewGuid().ToString();
            var invalidEntity = new ValidatableEntity { NumericProperty = "ABC" };
            var exception = new LeadPipeNetInvalidEntityException("This is a test.", entityId, invalidEntity.Validate());

            // Act
            var validationResults = exception.GetValidationResultsAsList();

            // Assert
            Assert.IsNotNull(validationResults.FirstOrDefault(x => x.Key.Equals("NumericProperty")));
        }
    }
}