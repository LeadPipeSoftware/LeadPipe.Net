// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Configuration;

namespace LeadPipe.Net.Tests.ConfigurationTests
{
    /// <summary>
    /// An example context-aware configuration setting.
    /// </summary>
    public class ExampleContextAwareConfigurationSetting : ConfigurationSetting
    {
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
    }
}