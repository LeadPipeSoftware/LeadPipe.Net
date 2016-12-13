// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.FiniteStateMachine
{
    /// <summary>
    /// An base exception for the domain layer.
    /// </summary>
    [Serializable]
    public class InvalidStartTransitionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidStartTransitionException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public InvalidStartTransitionException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidStartTransitionException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public InvalidStartTransitionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}