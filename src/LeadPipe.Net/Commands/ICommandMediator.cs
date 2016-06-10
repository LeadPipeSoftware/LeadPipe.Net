// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeadPipe.Net.Commands
{
    /// <summary>
    /// Mediates command execution requests.
    /// </summary>
    public interface ICommandMediator
    {
        /// <summary>
        /// Requests execution of the specified command.
        /// </summary>
        /// <typeparam name="TResponseData">The type of the response data.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns>The command response.</returns>
        [Obsolete("Please use the Submit method instead.")]
        CommandHandlerResponse<TResponseData> Request<TResponseData>(ICommand<TResponseData> command);

        /// <summary>
        /// Submits the specified command for execution.
        /// </summary>
        /// <typeparam name="TResponseData">The type of the response data.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns>The command response.</returns>
        CommandHandlerResponse<TResponseData> Submit<TResponseData>(ICommand<TResponseData> command);

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command to validate.</param>
        /// <returns>An enumeration of validation results.</returns>
        IEnumerable<ValidationResult> Validate(IValidatableObject command);
    }
}