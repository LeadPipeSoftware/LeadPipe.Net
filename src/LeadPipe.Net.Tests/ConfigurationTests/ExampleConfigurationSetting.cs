// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Configuration;

namespace LeadPipe.Net.Tests.ConfigurationTests
{
    /// <summary>
    /// An example configuration setting.
    /// </summary>
    public class ExampleConfigurationSetting : ConfigurationSetting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleConfigurationSetting"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public ExampleConfigurationSetting(string key)
            : base(key)
        {
        }
    }
}