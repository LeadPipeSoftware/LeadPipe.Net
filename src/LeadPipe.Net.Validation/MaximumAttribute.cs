// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaximumAttribute.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.Validation
{
    /// <summary>
	/// A custom data validation attribute that ensures a value is equal to or less than a maximum value.
	/// </summary>
	public class MaximumAttribute : LeadPipeValidationAttribute
	{
		#region Constants and Fields

		/// <summary>
		/// The maximum.
		/// </summary>
		private readonly double maximum;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="MaximumAttribute"/> class.
		/// </summary>
		/// <param name="maximum">The maximum.</param>
		/// <param name="ignoreIfConverted">if set to <c>true</c> [ignore if converted].</param>
		public MaximumAttribute(int maximum, bool ignoreIfConverted = false) : base(ignoreIfConverted)
		{
			this.maximum = maximum;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MaximumAttribute"/> class.
		/// </summary>
		/// <param name="maximum">The maximum.</param>
		/// <param name="ignoreIfConverted">if set to <c>true</c> [ignore if converted].</param>
		public MaximumAttribute(double maximum, bool ignoreIfConverted = false) : base(ignoreIfConverted)
		{
			this.maximum = maximum;
		}

		/// <summary>
		/// Prevents a default instance of the <see cref="MaximumAttribute"/> class from being created.
		/// </summary>
		/// <remarks>
		/// The Maximum attribute does not work without a maximum length value so the default constructor is blocked.
		/// </remarks>
		private MaximumAttribute()
		{
		}

		#endregion

		#region Methods

		/// <summary>
		/// Validates the specified value with respect to the current validation attribute.
		/// </summary>
		/// <param name="value">
		/// The value to validate.
		/// </param>
		/// <param name="validationContext">
		/// The context information about the validation operation.
		/// </param>
		/// <returns>
		/// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult"/> class.
		/// </returns>
		protected override ValidationResult PerformCustomValidation(object value, ValidationContext validationContext)
		{
			if (value.IsNull())
			{
				return ValidationResult.Success;
			}

			if (validationContext.IsNull())
			{
				validationContext = new ValidationContext(value, null, null) { DisplayName = "The value" };
			}

			var memberNames = new[] { validationContext.MemberName };

			double valueAsDouble;

			var isDouble = double.TryParse(Convert.ToString(value), out valueAsDouble);

			if (!isDouble)
			{
				this.ErrorMessage = validationContext.DisplayName.FormattedWith(ValidationMessages.ValueMustBeNumeric);

				return new ValidationResult(this.ErrorMessage, memberNames);
			}

			if (valueAsDouble > this.maximum)
			{
				this.ErrorMessage = string.Format(ValidationMessages.ValueMustBeLessThanOrEqualTo, validationContext.DisplayName, this.maximum);

				return new ValidationResult(this.ErrorMessage, memberNames);
			}

			return ValidationResult.Success;
		}

		#endregion
	}
}