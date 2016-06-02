// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

namespace LeadPipe.Net.Commands
{
    /// <summary>
    /// Handles commands.
    /// </summary>
    /// <typeparam name="TCommand">The type of the T command.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "GBM: Suppression is OK here.")]
    public interface ICommandHandler<in TCommand, out TResult>
    {
        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The command result.</returns>
        TResult Handle(TCommand command);
    }

    /// <summary>
    /// Handles commands.
    /// </summary>
    /// <typeparam name="TCommand">The type of the T command.</typeparam>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "GBM: Suppression is OK here.")]
    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, UnitType>
    {
    }
}