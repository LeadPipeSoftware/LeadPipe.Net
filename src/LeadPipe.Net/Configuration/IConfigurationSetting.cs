// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.Configuration
{
    /// <summary>
    /// Defines a configuration setting.
    /// </summary>
    public interface IConfigurationSetting : IComparable
    {
        /// <summary>
        /// Gets the configuration key.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets the configuration value.
        /// </summary>
        string Value { get; }
    }
}