// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetValidationAttributesShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
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
		#region Public Methods

		/// <summary>
		/// Test to make sure that a complete set of validation attributes is returned.
		/// </summary>
		[Test]
		public void ReturnAllValidationAttributes()
		{
			var attributes = typeof(HasValidationAttributes).GetValidationAttributes();

			Assert.That(attributes.Count == 4);
		}

		#endregion
	}
}