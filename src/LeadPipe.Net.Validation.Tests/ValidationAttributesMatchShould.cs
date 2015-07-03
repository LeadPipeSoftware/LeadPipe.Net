// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationAttributesMatchShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Validation.Tests
{
    /// <summary>
	/// ValidationAttributesMatch tests.
	/// </summary>
	[TestFixture]
	public class ValidationAttributesMatchShould
	{
		#region Public Methods

		/// <summary>
		/// Test to make sure that a true is returned when a type has matching validation attributes.
		/// </summary>
		[Test]
		public void ReturnTrueIfValidationAttributesMatch()
		{
			Assert.True(typeof(HasMatchingValidationAttributes).ValidationAttributesMatch(typeof(HasValidationAttributes)));
		}

		/// <summary>
		/// Test to make sure that a false is returned when a type has mis-matched validation attributes.
		/// </summary>
		[Test]
		public void ReturnFalseIfValidationAttributesDoNotMatch()
		{
			Assert.False(typeof(HasNonMatchingValidationAttributes).ValidationAttributesMatch(typeof(HasValidationAttributes)));
		}

		#endregion
	}
}