// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

namespace LeadPipe.Net.Commands
{
    /// <summary>
    /// The marker interface for commands.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "GBM: Suppression is OK here.")]
    public interface ICommand
    {
    }

    /// <summary>
    /// The marker interface for commands.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "GBM: Suppression is OK here.")]
    public interface ICommand<out TResult> : ICommand
    {
    }
}