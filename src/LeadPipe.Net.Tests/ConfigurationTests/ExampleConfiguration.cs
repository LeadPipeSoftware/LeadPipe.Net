// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Configuration;

namespace LeadPipe.Net.Tests.ConfigurationTests
{
    /// <summary>
    /// An example configuration.
    /// </summary>
    public class ExampleConfiguration : Enumeration<ExampleConfiguration, int>
    {
        /// <summary>
        /// The company name.
        /// </summary>
        public static readonly IConfigurationSetting Location = new ExampleConfigurationSetting("Location");

        /// <summary>
        /// The company aware unit test configuration setting.
        /// </summary>
        public static readonly IConfigurationSetting Location17Setting = new ExampleContextAwareConfigurationSetting("17-UnitTest", "UnitTestLocationSpecific");

        /// <summary>
        /// The plain unit test configuration setting.
        /// </summary>
        public static readonly IConfigurationSetting UnitTestPlain = new ExampleConfigurationSetting("UnitTestPlain");

        public ExampleConfiguration(int value, string displayName) : base(value, displayName)
        {
        }
    }
}