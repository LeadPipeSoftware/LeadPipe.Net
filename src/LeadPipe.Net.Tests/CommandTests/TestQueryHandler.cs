// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestQueryHandler.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Commands;

namespace LeadPipe.Net.Tests.CommandTests
{
	/// <summary>
	/// Handles test queries.
	/// </summary>
	public class TestQueryHandler : IQueryHandler<TestQuery, string>
	{
		/// <summary>
		/// Handles the specified query request.
		/// </summary>
		/// <param name="request">The query request.</param>
		/// <returns>The response.</returns>
		public string Handle(TestQuery request)
		{
			return request.Execute();
		}
	}
}