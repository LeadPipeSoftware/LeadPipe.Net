// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigurationSetting.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Configuration
{
	/// <summary>
	/// Defines a configuration setting.
	/// </summary>
	public interface IConfigurationSetting : IComparable
	{
		#region Public Properties

		/// <summary>
		/// Gets the configuration key.
		/// </summary>
		string Key { get; }

		/// <summary>
		/// Gets the configuration value.
		/// </summary>
		string Value { get; }

		#endregion
	}
}