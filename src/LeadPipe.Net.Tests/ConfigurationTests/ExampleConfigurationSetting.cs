// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExampleConfigurationSetting.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Configuration;

namespace LeadPipe.Net.Tests.ConfigurationTests
{
	/// <summary>
	/// An example configuration setting.
	/// </summary>
	public class ExampleConfigurationSetting : ConfigurationSetting
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ExampleConfigurationSetting"/> class.
		/// </summary>
		/// <param name="key">The key.</param>
		public ExampleConfigurationSetting(string key)
			: base(key)
		{
		}

		#endregion
	}
}