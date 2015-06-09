// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConnectionStringsSettingService.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Configuration;

namespace LeadPipe.Net.Configuration
{
	/// <summary>
	/// Defines a connection strings configuration setting service.
	/// </summary>
	public interface IConnectionStringsSettingService
	{
		#region Public Methods

		/// <summary>
		/// Gets the name of the connection provider.
		/// </summary>
		/// <param name="connectionName">Name of the connection.</param>
		/// <returns>The connection provider name.</returns>
		string GetConnectionProviderName(string connectionName);

		/// <summary>
		/// Gets the connection string.
		/// </summary>
		/// <param name="connectionName">Name of the connection.</param>
		/// <returns>The connection string.</returns>
		string GetConnectionString(string connectionName);

		/// <summary>
		/// Gets the connection string settings.
		/// </summary>
		/// <param name="connectionName">Name of the connection.</param>
		/// <returns>The connection string settings.</returns>
		ConnectionStringSettings GetConnectionStringSettings(string connectionName);

		#endregion
	}
}