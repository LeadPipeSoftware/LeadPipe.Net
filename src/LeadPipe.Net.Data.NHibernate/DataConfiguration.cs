// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataConfiguration.cs" company="SaltFx">
//   Copyright (c) SaltFx - All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SaltFx.Data
{
	/// <summary>
	/// Defines a data configuration.
	/// </summary>
	public class DataConfiguration
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets the connection string.
		/// </summary>
		/// <value></value>
		public string ConnectionString { get; set; }

		/// <summary>
		/// Gets or sets the name of the data configuration.
		/// </summary>
		/// <value></value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the provider name.
		/// </summary>
		/// <value></value>
		public string ProviderName { get; set; }

		#endregion
	}
}