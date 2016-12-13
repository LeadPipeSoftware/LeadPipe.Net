// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace LeadPipe.Net.Validation
{
    /// <summary>
    /// Base class for all the Lead Pipe custom validation attributes. It contains logic to ignore validation for converted data.
    /// </summary>
    public abstract class LeadPipeValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeValidationAttribute"/> class.
        /// </summary>
        /// <param name="ignoreIfConverted">
        /// if set to <c>true</c> [ignore if converted].
        /// </param>
        protected LeadPipeValidationAttribute(bool ignoreIfConverted = false)
        {
            this.IgnoreIfConverted = ignoreIfConverted;
        }

        /// <summary>
        ///   Gets a value indicating whether converted data should be ignored (return valid).
        /// </summary>
        /// <value> <c>true</c> if [ignore if converted]; otherwise, <c>false</c> . </value>
        protected bool IgnoreIfConverted { get; private set; }

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
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return this.PerformCustomValidation(value, validationContext);
        }

        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult"/> class.
        /// </returns>
        protected abstract ValidationResult PerformCustomValidation(object value, ValidationContext validationContext);
    }
}