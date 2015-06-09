// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExampleConfiguration.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Configuration;

namespace LeadPipe.Net.Tests.ConfigurationTests
{
	/// <summary>
	/// An example configuration.
	/// </summary>
	public class ExampleConfiguration : Enumeration<IConfigurationSetting>
	{
		#region Constants and Fields

		/// <summary>
		/// The company name.
		/// </summary>
		public static readonly IConfigurationSetting Location = new ExampleConfigurationSetting("Location");

		/// <summary>
		/// The plain unit test configuration setting.
		/// </summary>
		public static readonly IConfigurationSetting UnitTestPlain = new ExampleConfigurationSetting("UnitTestPlain");

		/// <summary>
		/// The company aware unit test configuration setting.
		/// </summary>
		public static readonly IConfigurationSetting Location17Setting = new ExampleContextAwareConfigurationSetting("17-UnitTest", "UnitTestLocationSpecific");

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Prevents a default instance of the <see cref="ExampleConfiguration"/> class from being created.
		/// </summary>
		private ExampleConfiguration()
		{
		}

		#endregion
	}
}