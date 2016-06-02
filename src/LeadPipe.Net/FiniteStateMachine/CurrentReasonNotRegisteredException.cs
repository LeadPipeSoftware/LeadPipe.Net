// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using System;

namespace LeadPipe.Net.FiniteStateMachine
{
    /// <summary>
    /// An base exception for the domain layer.
    /// </summary>
    [Serializable]
    public class CurrentReasonNotRegisteredException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentReasonNotRegisteredException"/> class.
        /// </summary>
        public CurrentReasonNotRegisteredException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentReasonNotRegisteredException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public CurrentReasonNotRegisteredException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentReasonNotRegisteredException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public CurrentReasonNotRegisteredException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentReasonNotRegisteredException"/> class.
        /// </summary>
        /// <param name="reasonCode">The reason code.</param>
        /// <param name="message">The message.</param>
        public CurrentReasonNotRegisteredException(string reasonCode, string message)
            : base(reasonCode.FormattedWith("The current transition reason ({0}) was not found in the list of registered states in the state machine." + Environment.NewLine + message))
        {
        }
    }
}