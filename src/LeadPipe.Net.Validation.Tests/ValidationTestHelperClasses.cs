// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationTestHelperClasses.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LeadPipe.Net.Validation.Tests
{
    /// <summary>
	/// A series of helper classes for testing the custom validation attributes and extension methods.
	/// </summary>
	public class ValidationTestHelperClasses
	{
	}

	/// <summary>
	/// A class that does not have validation attributes.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
		Justification = "Reviewed. Suppression is OK here because these are for unit testing only.")]
	public class DoesNotHaveValidationAttributes
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets an alphanumeric string.
		/// </summary>
		public string Alphanumeric { get; set; }

		/// <summary>
		/// Gets or sets a string that is required.
		/// </summary>
		public string Required { get; set; }

		/// <summary>
		/// Gets or sets a required alphanumeric string.
		/// </summary>
		public string RequiredAlphanumeric { get; set; }

		#endregion
	}

	/// <summary>
	/// A class that has validation attributes.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
		Justification = "Reviewed. Suppression is OK here because these are for unit testing only.")]
	public class HasValidationAttributes
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets an alphanumeric string.
		/// </summary>
		[Alphanumeric]
		public string Alphanumeric { get; set; }

		/// <summary>
		/// Gets or sets a string that is required.
		/// </summary>
		[Required]
		public string Required { get; set; }

		/// <summary>
		/// Gets or sets a required alphanumeric string.
		/// </summary>
		[Required]
		[Alphanumeric]
		public string RequiredAlphanumeric { get; set; }

		#endregion
	}

	/// <summary>
	/// A class that has validation attributes that match those found on HasValidationAttributes.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
		Justification = "Reviewed. Suppression is OK here because these are for unit testing only.")]
	public class HasMatchingValidationAttributes
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets an alphanumeric string.
		/// </summary>
		[Alphanumeric]
		public string Alphanumeric { get; set; }

		/// <summary>
		/// Gets or sets a string that is required.
		/// </summary>
		[Required]
		public string Required { get; set; }

		/// <summary>
		/// Gets or sets a required alphanumeric string.
		/// </summary>
		[Required]
		[Alphanumeric]
		public string RequiredAlphanumeric { get; set; }

		#endregion
	}

	/// <summary>
	/// A class that has validation attributes that do not match those found on HasValidationAttributes.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
		Justification = "Reviewed. Suppression is OK here because these are for unit testing only.")]
	public class HasNonMatchingValidationAttributes
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets an alphanumeric string.
		/// </summary>
		[Required]
		public string Alphanumeric { get; set; }

		/// <summary>
		/// Gets or sets a string that is required.
		/// </summary>
		[Alphanumeric]
		public string Required { get; set; }

		/// <summary>
		/// Gets or sets a required alphanumeric string.
		/// </summary>
		[Required]
		public string RequiredAlphanumeric { get; set; }

		#endregion
	}

	/// <summary>
	/// A validatable entity that will be used for testing the validation attributes.
	/// </summary>
	/// <remarks>
	/// Each property applies different validation attributes. Unit tests can create this entity and set
	/// valid or invalid valid for different properties and check the Validate or IsValid methods on the entity
	/// to ensure that the attributes behave as expected.
	/// </remarks>
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
		Justification = "Reviewed. Suppression is OK here because these are for unit testing only.")]
	public class ValidatableEntity : IValidatableObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ValidatableEntity"/> class.
		/// </summary>
		public ValidatableEntity()
		{
			// Make sure that the default values are valid...
			this.MaximumIntOf5Property = 3;
			this.MaximumStringOf5Property = "3";

			this.MinimumIntOf5Property = 10;
			this.MinimumStringOf5Property = "10";
		}

		#region Public Properties

		/// <summary>
		/// Gets or sets AlphaPlusProperty.
		/// </summary>
		[Alpha("+", "-", " ")]
		public string AlphaPlusProperty { get; set; }

		/// <summary>
		/// Gets or sets AlphaPlusWithNoLeadingNoTrailing.
		/// </summary>
		[Alpha("$", "#", " ")]
		[NoLeadingWhitespace]
		[NoTrailingWhitespace]
		public string AlphaPlusWithNoLeadingNoTrailing { get; set; }

		/// <summary>
		/// Gets or sets AlphaProperty.
		/// </summary>
		[Alpha]
		public string AlphaProperty { get; set; }

		/// <summary>
		/// Gets or sets AlphanumericPlusProperty.
		/// </summary>
		[Alphanumeric("+", "-", " ")]
		public string AlphanumericPlusProperty { get; set; }

		/// <summary>
		/// Gets or sets AlphanumericPlusWithNoLeadingNoTrailing.
		/// </summary>		
		[Alphanumeric("$", "#", " ")]
		[NoLeadingWhitespace]
		[NoTrailingWhitespace]
		public string AlphanumericPlusWithNoLeadingNoTrailing { get; set; }

		/// <summary>
		/// Gets or sets AlphanumericProperty.
		/// </summary>
		[Alphanumeric]
		public string AlphanumericProperty { get; set; }

		/// <summary>
		/// Gets or sets ExtendedCharacterProperty.
		/// </summary>
		[ExtendedCharacter]
		public string ExtendedCharacterProperty { get; set; }

		/// <summary>
		/// Gets or sets AlphaProperty.
		/// </summary>
		[Alpha(true)]
		public string ConvertedAlphaProperty { get; set; }

		/// <summary>
		/// Gets or sets NumericPlusAbcProperty.
		/// </summary>
		/// <remarks>
		/// Can be used to test that Numeric with extra characters works.
		/// </remarks>
		[Numeric("A", "B", "C")]
		public string NumericPlusAbcProperty { get; set; }

		/// <summary>
		/// Gets or sets a NumericProperty.
		/// </summary>
		[Numeric]
		public string NumericProperty { get; set; }

		/// <summary>
		/// Gets or sets the maximum int of 5 property.
		/// </summary>
		/// <value>
		/// The maximum int of 5 property.
		/// </value>
		[Maximum(5)]
		public int MaximumIntOf5Property { get; set; }

		/// <summary>
		/// Gets or sets the maximum string of 5 property.
		/// </summary>
		/// <value>
		/// The maximum string of 5 property.
		/// </value>
		[Maximum(5)]
		public string MaximumStringOf5Property { get; set; }

		/// <summary>
		/// Gets or sets the minimum int or 5 property.
		/// </summary>
		[Minimum(5)]
		public int MinimumIntOf5Property { get; set; }

		/// <summary>
		/// Gets or sets the minimum string of 5 property.
		/// </summary>
		[Minimum(5)]
		public string MinimumStringOf5Property { get; set; }

		/// <summary>
		/// Gets or sets PrintableCharacterProperty.
		/// </summary>
		[PrintableCharacter]
		public string PrintableCharacterProperty { get; set; }

		#endregion

		#region Public Methods

		/// <summary>
		/// The validate.
		/// </summary>
		/// <param name="validationContext">
		/// The validation context.
		/// </param>
		/// <returns>
		/// Validation results.
		/// </returns>
		public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			yield return ValidationResult.Success;
		}

		#endregion
	}
}