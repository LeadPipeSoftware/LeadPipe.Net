// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net
{
    /// <summary>
    /// Defines a Lead Pipe security exception.
    /// </summary>
    [Serializable]
    public class LeadPipeNetSecurityException : LeadPipeNetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetSecurityException"/> class.
        /// </summary>
        public LeadPipeNetSecurityException()
            : base("A security exception has occurred.")
        {
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Security;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetSecurityException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public LeadPipeNetSecurityException(string message)
            : base(message)
        {
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Security;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetSecurityException"/> class.
        /// </summary>
        /// <param name="userContext">The security context.</param>
        public LeadPipeNetSecurityException(IUserContext userContext)
        {
            this.UserContext = userContext;
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Security;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetSecurityException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="userContext">The security context.</param>
        public LeadPipeNetSecurityException(string message, IUserContext userContext)
            : base(message)
        {
            this.UserContext = userContext;
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Security;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetSecurityException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public LeadPipeNetSecurityException(string message, Exception innerException)
            : base(message, innerException)
        {
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Security;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadPipeNetSecurityException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="userContext">The security context.</param>
        /// <param name="innerException">The inner exception.</param>
        public LeadPipeNetSecurityException(string message, IUserContext userContext, Exception innerException)
            : base(message, innerException)
        {
            this.UserContext = userContext;
            this.LeadPipeNetExceptionType = LeadPipeNetExceptionType.Security;
        }

        /// <summary>
        /// Gets or sets the securityContext.
        /// </summary>
        /// <value>
        /// The securityContext.
        /// </value>
        public IUserContext UserContext { get; set; }
    }
}