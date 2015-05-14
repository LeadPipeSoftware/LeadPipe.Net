// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandHandlerResponse.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;

namespace LeadPipe.Net.Commands
{
	/// <summary>
	/// The command handler response.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "GBM: Suppression is OK here.")]
	public class CommandHandlerResponse
	{
		/// <summary>
		/// Gets or sets the exception that occurred while handling the request.
		/// </summary>
		/// <value>The exception.</value>
		public virtual Exception Exception { get; set; }

		/// <summary>
		/// Gets or sets the execution result.
		/// </summary>
		/// <value>The execution result.</value>
		public virtual CommandExecutionResult CommandExecutionResult { get; set; }

		/// <summary>
		/// Determines whether an exception occurred while handling the request.
		/// </summary>
		/// <returns><c>true</c> if this instance has an exception; otherwise, <c>false</c>.</returns>
		public virtual bool HasException()
		{
			return this.Exception != null;
		}
	}

	/// <summary>
	/// The handler response.
	/// </summary>
	/// <typeparam name="TResponseData">The type of the response data.</typeparam>
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "GBM: Suppression is OK here.")]
	public class CommandHandlerResponse<TResponseData> : CommandHandlerResponse
	{
		/// <summary>
		/// Gets or sets the response data.
		/// </summary>
		/// <value>The response data.</value>
		public virtual TResponseData Data { get; set; }
	}
}