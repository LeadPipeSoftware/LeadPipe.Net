// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Configuration
{
    /// <summary>
    /// Defines an application configuration service.
    /// </summary>
    public interface IApplicationSettingService
    {
        /// <summary>
        /// Gets a setting.
        /// </summary>
        /// <param name="settingName">The name of the setting.</param>
        /// <returns>The setting value.</returns>
        string GetSetting(string settingName);
    }
}