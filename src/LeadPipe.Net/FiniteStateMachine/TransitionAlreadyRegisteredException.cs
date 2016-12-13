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
    public class TransitionAlreadyRegisteredException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransitionAlreadyRegisteredException"/> class.
        /// </summary>
        public TransitionAlreadyRegisteredException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransitionAlreadyRegisteredException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public TransitionAlreadyRegisteredException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransitionAlreadyRegisteredException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public TransitionAlreadyRegisteredException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransitionAlreadyRegisteredException"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="transition">The transition.</param>
        public TransitionAlreadyRegisteredException(IFiniteState state, IFiniteStateTransition transition)
            : base(
                string.Format(
                    CultureInfo.CurrentCulture, "The {0} state is already registered with the {1} transition.", state.Name, transition.Name))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransitionAlreadyRegisteredException"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="transition">The transition.</param>
        /// <param name="innerException">The inner exception.</param>
        public TransitionAlreadyRegisteredException(IFiniteState state, IFiniteStateTransition transition, Exception innerException)
            : base(
                string.Format(
                    CultureInfo.CurrentCulture, "The {0} state is already registered with the {1} transition.", state.Name, transition.Name),
                innerException)
        {
        }
    }
}