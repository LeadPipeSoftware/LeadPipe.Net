// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using LeadPipe.Net.Commands;

namespace LeadPipe.Net.Tests.CommandTests
{
    /// <summary>
    /// Handles execution of the debug write unit test command.
    /// </summary>
    public class DebugWriteWithValidationCommandHandler : CommandHandler<DebugWriteWithValidationCommand>
    {
        protected override void OnHandle(DebugWriteWithValidationCommand command)
        {
            Debug.WriteLine(command.TextToWrite);
        }
    }
}