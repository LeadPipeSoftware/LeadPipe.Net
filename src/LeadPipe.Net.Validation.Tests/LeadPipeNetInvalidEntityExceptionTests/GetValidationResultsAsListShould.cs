// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetValidationResultsAsListShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using NUnit.Framework;

namespace LeadPipe.Net.Validation.Tests.LeadPipeNetInvalidEntityExceptionTests
{
    /// <summary>
	/// GetValidationResultsAsList method tests.
	/// </summary>
	[TestFixture]
	public class GetValidationResultsAsListShould
	{
		#region Public Methods

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

		#endregion
	}
}