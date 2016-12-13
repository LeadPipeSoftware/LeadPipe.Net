// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Commands;
using System;

namespace LeadPipe.Net.Tests.CommandTests
{
    /// <summary>
    /// Handles execution of the test command by exploding.
    /// </summary>
    public class ExplodingTestCommandHandler : CommandHandler<ExplodingTestCommand>
    {
        /// <summary>
        /// Called when the command is handled.
        /// </summary>
        /// <param name="command">The message.</param>
        protected override void OnHandle(ExplodingTestCommand command)
        {
            throw new Exception(command.ExceptionMessage);
        }
    }
}