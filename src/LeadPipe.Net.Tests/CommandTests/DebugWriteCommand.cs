// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Commands;

namespace LeadPipe.Net.Tests.CommandTests
{
    /// <summary>
    /// A command that writes to the debug console for unit testing.
    /// </summary>
    public class DebugWriteCommand : ICommand<UnitType>
    {
        /// <summary>
        /// Gets or sets the text to write.
        /// </summary>
        /// <value>The text to write.</value>
        public string TextToWrite { get; set; }
    }
}