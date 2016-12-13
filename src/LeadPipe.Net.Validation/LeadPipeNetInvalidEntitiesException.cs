// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace LeadPipe.Net.Validation
{
    /// <summary>
    /// An exception thrown when an entity is invalid.
    /// </summary>
    [Serializable]
    public class LeadPipeNetInvalidEntitiesException : LeadPipeNetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetInvalidEntitiesException"/> class.
        /// </summary>
        public LeadPipeNetInvalidEntitiesException()
            : base("One or more entities is invalid.")
        {
            this.InvalidEntityExceptions = new List<LeadPipeNetInvalidEntityException>();
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Validation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetInvalidEntitiesException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public LeadPipeNetInvalidEntitiesException(string message)
            : base(message)
        {
            this.InvalidEntityExceptions = new List<LeadPipeNetInvalidEntityException>();
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Validation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetInvalidEntitiesException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="invalidEntityExceptions">The invalid entity exceptions.</param>
        public LeadPipeNetInvalidEntitiesException(string message, List<LeadPipeNetInvalidEntityException> invalidEntityExceptions)
            : base(message)
        {
            this.InvalidEntityExceptions = invalidEntityExceptions;
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Validation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetInvalidEntitiesException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="invalidEntityExceptions">The invalid entity exceptions.</param>
        public LeadPipeNetInvalidEntitiesException(string message, Exception innerException, List<LeadPipeNetInvalidEntityException> invalidEntityExceptions)
            : base(message, innerException)
        {
            this.InvalidEntityExceptions = invalidEntityExceptions;
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Validation;
        }

        /// <summary>
        /// Gets or sets the invalid entity exceptions.
        /// </summary>
        /// <value>
        /// The invalid entity exceptions.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "GBM: Reviewed.")]
        public List<LeadPipeNetInvalidEntityException> InvalidEntityExceptions { get; set; }
    }
}