// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Commands;
using System.Diagnostics;
using System.Threading;

namespace LeadPipe.Net.Tests.CommandTests
{
    /// <summary>
    /// Handles execution of the debug write unit test command.
    /// </summary>
    public class DebugWriteCommandHandler : CommandHandler<DebugWriteCommand>
    {
        /// <summary>
        /// Called when the command is handled.
        /// </summary>
        /// <param name="command">The command.</param>
        protected override void OnHandle(DebugWriteCommand command)
        {
            Thread.Sleep(51); // Guarantees that this command will take more than 50 milliseconds
            Debug.Write(command.TextToWrite);
        }
    }
}