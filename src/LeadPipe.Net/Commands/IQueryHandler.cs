// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQueryHandler.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Commands
{
	/// <summary>
	/// Handles queries.
	/// </summary>
	/// <typeparam name="TRequest">The type of the query request.</typeparam>
	/// <typeparam name="TResponse">The type of the response.</typeparam>
	public interface IQueryHandler<in TRequest, out TResponse>
		where TRequest : IQuery<TResponse>
	{
		/// <summary>
		/// Handles the specified query request.
		/// </summary>
		/// <param name="request">The query request.</param>
		/// <returns>The response.</returns>
		TResponse Handle(TRequest request);
	}
}