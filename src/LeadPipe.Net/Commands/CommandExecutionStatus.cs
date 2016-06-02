// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Commands
{
    /// <summary>
    /// An enumeration of execution statuses for commands.
    /// </summary>
    public enum CommandExecutionStatus
    {
        /// <summary>
        /// Indicates the execution is cancelling.
        /// </summary>
        Canceling,

        /// <summary>
        /// Indicates the execution is executing.
        /// </summary>
        Executing,

        /// <summary>
        /// Indicates the execution is failing.
        /// </summary>
        Failing,

        /// <summary>
        /// Indicates the execution is finished.
        /// </summary>
        Finished
    }
}