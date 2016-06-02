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
    /// A custom data validation attribute that checks for numeric.
    /// </summary>
    public class NumericAttribute : LeadPipeValidationAttribute
    {
        /// <summary>
        /// The extra characters that are permitted beyond the alphanumeric set.
        /// </summary>
        private readonly string[] extraCharacters;

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericAttribute"/> class.
        /// </summary>
        /// <param name="ignoreIfConverted">if set to <c>true</c> [ignore if converted].</param>
        public NumericAttribute(bool ignoreIfConverted = false) : this(ignoreIfConverted, new string[0])
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericAttribute"/> class.
        /// </summary>
        /// <param name="extraCharacters">
        /// The extra characters that are permitted beyond the alphanumeric set. The format is an array of string.
        /// e.g. {"-", "+", "$", " " }.
        /// </param>
        public NumericAttribute(params string[] extraCharacters) : this(false, extraCharacters)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericAttribute"/> class.
        /// </summary>
        /// <param name="ignoreIfConverted">if set to <c>true</c> [ignore if converted].</param>
        /// <param name="extraCharacters">The extra characters.</param>
        public NumericAttribute(bool ignoreIfConverted, params string[] extraCharacters) : base(ignoreIfConverted)
        {
            this.extraCharacters = extraCharacters;
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

            string convertedValue;
            if (validationContext.IsNull())
            {
                validationContext = new ValidationContext(value, null, null) { DisplayName = "The value" };
            }

            var memberNames = new[] { validationContext.MemberName };

            try
            {
                convertedValue = Convert.ToString(value);
            }
            catch (FormatException)
            {
                this.ErrorMessage = validationContext.DisplayName.FormattedWith(ValidationMessages.ValueMustBeString);

                return new ValidationResult(this.ErrorMessage);
            }

            // Remove any of the extra permitted characters before applying the IsAlphanumeric rule...
            foreach (string character in this.extraCharacters)
            {
                convertedValue = convertedValue.Replace(character, string.Empty);
            }

            // The convertedValue might be an empty string after we strip out the extra characters. This should not
            // cause validation to fail.
            if (!string.IsNullOrEmpty(convertedValue) && !convertedValue.IsNumeric())
            {
                if (this.extraCharacters.Length == 0)
                {
                    this.ErrorMessage = validationContext.DisplayName.FormattedWith(ValidationMessages.CanOnlyContainNumbers);
                }
                else
                {
                    this.ErrorMessage = string.Format(
                        ValidationMessages.CanOnlyContainNumbersAndSpecialCharacters,
                        validationContext.DisplayName,
                        string.Join(string.Empty, this.extraCharacters));
                }

                return new ValidationResult(this.ErrorMessage, memberNames);
            }

            return ValidationResult.Success;
        }
    }
}