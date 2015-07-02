// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinimumLengthAttribute.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.Validation
{
    /// <summary>
	/// A custom data validation attribute that ensures string length is as long as the minimum.
	/// </summary>
	public class MinimumLengthAttribute : LeadPipeValidationAttribute
	{
		#region Constants and Fields

		/// <summary>
		/// The minimum length.
		/// </summary>
		private readonly uint minimumLength;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="MinimumLengthAttribute"/> class.
		/// </summary>
		/// <param name="minimumLength">The minimum length.</param>
		/// <param name="ignoreIfConverted">if set to <c>true</c> [ignore if converted].</param>
		public MinimumLengthAttribute(uint minimumLength, bool ignoreIfConverted = false) : base(ignoreIfConverted)
		{
			this.minimumLength = minimumLength;
		}

		/// <summary>
		/// Prevents a default instance of the <see cref="MinimumLengthAttribute"/> class from being created.
		/// </summary>
		/// <remarks>
		/// The MinimumLength attribute does not work without a minimum length value so the default constructor is blocked.
		/// </remarks>
		private MinimumLengthAttribute()
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

			int length = value.ToString().Length;

			if (length < this.minimumLength)
			{
				this.ErrorMessage = string.Format(ValidationMessages.ValueLessThanMinimumLength, validationContext.DisplayName, this.minimumLength);

				return new ValidationResult(this.ErrorMessage, memberNames);
			}

			return ValidationResult.Success;
		}

		#endregion
	}
}