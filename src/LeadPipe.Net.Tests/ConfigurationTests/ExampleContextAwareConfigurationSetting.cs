// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExampleContextAwareConfigurationSetting.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Configuration;

namespace LeadPipe.Net.Tests.ConfigurationTests
{
	/// <summary>
	/// An example context-aware configuration setting.
	/// </summary>
	public class ExampleContextAwareConfigurationSetting : ConfigurationSetting
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ExampleContextAwareConfigurationSetting" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="key">The key.</param>
		public ExampleContextAwareConfigurationSetting(string context, string key)
			: base(key)
		{
			this.Context = context;
		}

		#endregion
	}
}