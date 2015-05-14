// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommandHandler.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
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