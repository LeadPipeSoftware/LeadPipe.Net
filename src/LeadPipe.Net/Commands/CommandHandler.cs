// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandHandler.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

namespace LeadPipe.Net.Commands
{
	/// <summary>
	/// A base class for command handlers that do not have a return type.
	/// </summary>
	/// <typeparam name="TMessage">The type of the message.</typeparam>
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "GBM: Suppression is OK here.")]
	public abstract class CommandHandler<TMessage> : ICommandHandler<TMessage>
	{
		/// <summary>
		/// Handles the specified command.
		/// </summary>
		/// <param name="message">The command message.</param>
		/// <returns>Returns UnitType.Default (void).</returns>
		public UnitType Handle(TMessage message)
		{
			this.OnHandle(message);

			return UnitType.Default;
		}

		/// <summary>
		/// Called when the command is handled.
		/// </summary>
		/// <param name="command">The message.</param>
		protected abstract void OnHandle(TMessage command);
	}
}