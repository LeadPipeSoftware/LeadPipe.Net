// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace LeadPipe.Net.FiniteStateMachine
{
    /// <summary>
    /// An base exception for the domain layer.
    /// </summary>
    [Serializable]
    public class StateInUseException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StateInUseException"/> class.
        /// </summary>
        public StateInUseException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateInUseException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public StateInUseException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateInUseException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public StateInUseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateInUseException"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        public StateInUseException(IFiniteState state)
            : base(
                string.Format(
                    CultureInfo.CurrentCulture, "The {0} state is currently in use.", state.Name))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateInUseException"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="innerException">The inner exception.</param>
        public StateInUseException(IFiniteState state, Exception innerException)
            : base(
                string.Format(
                    CultureInfo.CurrentCulture, "The {0} state is currently in use.", state.Name),
                innerException)
        {
        }
    }
}