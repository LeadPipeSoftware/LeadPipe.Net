// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Configuration;

namespace LeadPipe.Net.Tests.ConfigurationTests
{
    /// <summary>
    /// An example parsed configuration setting.
    /// </summary>
    public class ExampleParsedConfigurationSetting : ConfigurationSetting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleParsedConfigurationSetting"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="exampleArgument">The example argument.</param>
        public ExampleParsedConfigurationSetting(string key, string exampleArgument)
            : base(key)
        {
            this.ExampleArgument = exampleArgument;
        }

        /// <summary>
        /// Gets or sets the example argument.
        /// </summary>
        /// <value>
        /// The example argument.
        /// </value>
        public string ExampleArgument { get; set; }

        /// <summary>
        /// Parses this instance.
        /// </summary>
        /// <returns>
        /// The parsed value.
        /// </returns>
        public override string Parse()
        {
            return this.UnparsedValue.Replace("{PARSE THIS}", this.ExampleArgument);
        }
    }
}