// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Commands
{
    /// <summary>
    /// An enumeration of command execution result values.
    /// </summary>
    public enum CommandExecutionResult
    {
        /// <summary>
        /// Indicates the execution was cancelled.
        /// </summary>
        Cancelled,

        /// <summary>
        /// Indicates the execution completed successfully.
        /// </summary>
        Succeeded,

        /// <summary>
        /// Indicates the execution failed.
        /// </summary>
        Failed
    }
}