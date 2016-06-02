// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

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
        CommandHandlerResponse<TResponseData> Request<TResponseData>(ICommand<TResponseData> command);
    }
}