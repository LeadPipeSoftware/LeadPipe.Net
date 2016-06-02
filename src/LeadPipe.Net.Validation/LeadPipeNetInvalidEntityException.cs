// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LeadPipe.Net.Validation
{
    /// <summary>
    /// An exception thrown when an entity is invalid.
    /// </summary>
    [Serializable]
    public class LeadPipeNetInvalidEntityException : LeadPipeNetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetInvalidEntityException"/> class.
        /// </summary>
        public LeadPipeNetInvalidEntityException()
        {
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Validation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetInvalidEntityException"/> class.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <param name="validationResults">The validation results.</param>
        public LeadPipeNetInvalidEntityException(string entityId, List<ValidationResult> validationResults)
        {
            this.EntityId = entityId;
            this.ValidationResults = validationResults;
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Validation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetInvalidEntityException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="entityId">The entity id.</param>
        /// <param name="validationResults">This ValidationResults that contain information about why the entity is invalid.</param>
        public LeadPipeNetInvalidEntityException(string message, string entityId, List<ValidationResult> validationResults)
            : base(message)
        {
            this.EntityId = entityId;
            this.ValidationResults = validationResults;
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Validation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetInvalidEntityException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="entityId">The entity id.</param>
        /// <param name="validationResults">The validation results that contain information about why the entity is invalid.</param>
        public LeadPipeNetInvalidEntityException(string message, Exception innerException, string entityId, List<ValidationResult> validationResults)
            : base(message, innerException)
        {
            this.EntityId = entityId;
            this.ValidationResults = validationResults;
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Validation;
        }

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        /// <value>
        /// The entity id.
        /// </value>
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or sets ValidationResults.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "GBM: Reviewed.")]
        public List<ValidationResult> ValidationResults { get; set; }

        /// <summary>
        /// Gets the validation results as a list of key value pairs.
        /// </summary>
        /// <returns>A list of key (member name) value (error message) pairs.</returns>
        public IList<KeyValuePair<string, string>> GetValidationResultsAsList()
        {
            return (from validationResult
                        in this.ValidationResults
                    from memberName
                        in validationResult.MemberNames
                    select new KeyValuePair<string, string>(memberName, validationResult.ErrorMessage)).ToList();
        }
    }
}