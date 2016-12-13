// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace LeadPipe.Net.Validation
{
    /// <summary>
    /// A custom data validation attribute that ensures a value is equal to or greater than a minimum value.
    /// </summary>
    public class MinimumAttribute : LeadPipeValidationAttribute
    {
        /// <summary>
        /// The minimum.
        /// </summary>
        private readonly double minimum;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinimumAttribute"/> class.
        /// </summary>
        /// <param name="minimum">The minimum.</param>
        /// <param name="ignoreIfConverted">if set to <c>true</c> [ignore if converted].</param>
        public MinimumAttribute(int minimum, bool ignoreIfConverted = false) : base(ignoreIfConverted)
        {
            this.minimum = minimum;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinimumAttribute"/> class.
        /// </summary>
        /// <param name="minimum">The minimum.</param>
        /// <param name="ignoreIfConverted">if set to <c>true</c> [ignore if converted].</param>
        public MinimumAttribute(double minimum, bool ignoreIfConverted = false) : base(ignoreIfConverted)
        {
            this.minimum = minimum;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="MinimumAttribute"/> class from being created.
        /// </summary>
        /// <remarks>
        /// The Minimum attribute does not work without a minimum length value so the default constructor is blocked.
        /// </remarks>
        private MinimumAttribute()
        {
        }

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
                this.ErrorMessage = ValidationMessages.ValueMustBeNumeric;

                return new ValidationResult(this.ErrorMessage, memberNames);
            }

            if (valueAsDouble < this.minimum)
            {
                this.ErrorMessage = string.Format(ValidationMessages.ValueMustBeGreaterThanOrEqualTo, validationContext.DisplayName, this.minimum);

                return new ValidationResult(this.ErrorMessage, memberNames);
            }

            return ValidationResult.Success;
        }
    }
}