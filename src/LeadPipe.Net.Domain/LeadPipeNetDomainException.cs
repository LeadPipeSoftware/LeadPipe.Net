// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
    using System;

    /// <summary>
    /// An base exception for the domain layer.
    /// </summary>
    [Serializable]
    public class LeadPipeNetDomainException : LeadPipeNetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetDomainException"/> class.
        /// </summary>
        public LeadPipeNetDomainException()
            : base("A domain error has occurred.")
        {
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Domain;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetDomainException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public LeadPipeNetDomainException(string message)
            : base(message)
        {
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Domain;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetDomainException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public LeadPipeNetDomainException(string message, Exception innerException)
            : base(message, innerException)
        {
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Domain;
        }
    }
}