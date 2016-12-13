// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Commands;

namespace LeadPipe.Net.Tests.CommandTests
{
    /// <summary>
    /// A command that throws an exception for unit testing.
    /// </summary>
    public class ExplodingTestCommand : ICommand<UnitType>
    {
        /// <summary>
        /// Gets or sets the exception message.
        /// </summary>
        /// <value>The exception message.</value>
        public string ExceptionMessage { get; set; }
    }
}