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
    public class StateAlreadyRegisteredException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StateAlreadyRegisteredException"/> class.
        /// </summary>
        public StateAlreadyRegisteredException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateAlreadyRegisteredException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public StateAlreadyRegisteredException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateAlreadyRegisteredException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public StateAlreadyRegisteredException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateAlreadyRegisteredException"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        public StateAlreadyRegisteredException(IFiniteState state)
            : base(
                string.Format(
                    CultureInfo.CurrentCulture, "The {0} state is already registered with this finite state machine.", state.Name))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateAlreadyRegisteredException"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="innerException">The inner exception.</param>
        public StateAlreadyRegisteredException(IFiniteState state, Exception innerException)
            : base(
                string.Format(
                    CultureInfo.CurrentCulture, "The {0} state is already registered with this finite state machine.", state.Name),
                innerException)
        {
        }
    }
}