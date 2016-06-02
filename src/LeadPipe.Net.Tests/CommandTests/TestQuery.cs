// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Commands;
using System;

namespace LeadPipe.Net.Tests.CommandTests
{
    /// <summary>
    /// A query used for unit testing.
    /// </summary>
    public class TestQuery : IQuery<string>
    {
        /// <summary>
        /// The answer.
        /// </summary>
        public const string Answer = "Hooray!";

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <returns>The query result.</returns>
        public string Execute()
        {
            return Answer;
        }

        /// <summary>
        /// Explodes this instance.
        /// </summary>
        /// <returns>The query result.</returns>
        public string Explode()
        {
            throw new Exception("Kaboom!");
        }
    }
}