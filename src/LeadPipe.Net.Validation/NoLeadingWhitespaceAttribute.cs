// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NoLeadingWhitespaceAttribute.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.Validation
{
    /// <summary>
	/// A custom data validation attribute that checks for leading whitespace.
	/// </summary>
	public class NoLeadingWhitespaceAttribute : LeadPipeValidationAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NoLeadingWhitespaceAttribute"/> class.
		/// </summary>
		/// <param name="ignoreIfConverted">if set to <c>true</c> [ignore if converted].</param>
		public NoLeadingWhitespaceAttribute(bool ignoreIfConverted = false) : base(ignoreIfConverted)
		{
		}

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

			string convertedValue;
			if (validationContext.IsNull())
			{
				validationContext = new ValidationContext(value, null, null) { DisplayName = "The value" };
			}

			var memberNames = new string[] { validationContext.MemberName };

			try
			{
				convertedValue = Convert.ToString(value);
			}
			catch (FormatException)
			{
				this.ErrorMessage = validationContext.DisplayName.FormattedWith(ValidationMessages.ValueMustBeString);

				return new ValidationResult(this.ErrorMessage);
			}

			if (convertedValue.ContainsLeadingWhiteSpace())
			{
				this.ErrorMessage = validationContext.DisplayName.FormattedWith(ValidationMessages.CanNotContainLeadingWhitespace);

				return new ValidationResult(this.ErrorMessage, memberNames);
			}

			return ValidationResult.Success;
		}

		#endregion
	}
}