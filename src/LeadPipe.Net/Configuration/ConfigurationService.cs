// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using System.Configuration;
using System.Reflection;

namespace LeadPipe.Net.Configuration
{
    /// <summary>
    /// An application settings service provider.
    /// </summary>
    public static class ConfigurationService
    {
        /// <summary>
        /// The application setting service.
        /// </summary>
        private static readonly ContextAwareApplicationSettingService ApplicationSettingService = new ContextAwareApplicationSettingService();

        /// <summary>
        /// The connection strings setting service.
        /// </summary>
        private static readonly ContextAwareConnectionStringsSettingService ContextAwareConnectionStringsSettingService = new ContextAwareConnectionStringsSettingService();

        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <returns>The application name.</returns>
        public static string GetApplicationName()
        {
            // Try to use what's in the config file...
            var configName = GetApplicationSetting("ApplicationName");

            if (!string.IsNullOrEmpty(configName))
            {
                return configName;
            }

            // Try to use the calling assembly title...
            var attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

            // If there is at least one Title attribute...
            if (attributes.Length > 0)
            {
                // Select the first one...
                var titleAttribute = (AssemblyTitleAttribute)attributes[0];

                // If it is not an empty string, return it...
                if (titleAttribute.Title != string.Empty)
                {
                    return titleAttribute.Title;
                }
            }

            // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name...
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetCallingAssembly().CodeBase);
        }

        /// <summary>
        /// Gets an application setting from the configuration file.
        /// </summary>
        /// <param name="settingName">The name of the setting</param>
        /// <returns>
        /// The value of the setting.
        /// </returns>
        public static string GetApplicationSetting(string settingName)
        {
            Guard.Will.ProtectAgainstNullArgument(() => settingName);

            return ApplicationSettingService.GetSetting(settingName);
        }

        /// <summary>
        /// Gets an application setting from the configuration file.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settingName">The name of the setting</param>
        /// <returns>
        /// The value of the setting.
        /// </returns>
        public static string GetApplicationSetting(string context, string settingName)
        {
            Guard.Will.ProtectAgainstNullArgument(() => settingName);

            return ApplicationSettingService.GetSetting(context, settingName);
        }

        /// <summary>
        /// Gets the connection provider name from the configuration file.
        /// </summary>
        /// <param name="connectionName">The name of the connection.</param>
        /// <returns>
        /// The connection string.
        /// </returns>
        public static string GetConnectionProviderName(string connectionName)
        {
            Guard.Will.ProtectAgainstNullArgument(() => connectionName);

            return ContextAwareConnectionStringsSettingService.GetConnectionProviderName(connectionName);
        }

        /// <summary>
        /// Gets the connection string from the configuration file.
        /// </summary>
        /// <param name="connectionName">The name of the connection.</param>
        /// <returns>
        /// The connection string.
        /// </returns>
        public static string GetConnectionString(string connectionName)
        {
            Guard.Will.ProtectAgainstNullArgument(() => connectionName);
            Guard.Will.ThrowException("No connection strings were found.").When(ConfigurationManager.ConnectionStrings.IsNull());

            return ContextAwareConnectionStringsSettingService.GetConnectionString(connectionName);
        }

        /// <summary>
        /// Gets the connection string from the configuration file.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="connectionName">The name of the connection.</param>
        /// <returns>
        /// The connection string.
        /// </returns>
        public static string GetConnectionString(string context, string connectionName)
        {
            Guard.Will.ProtectAgainstNullArgument(() => context);
            Guard.Will.ProtectAgainstNullArgument(() => connectionName);
            Guard.Will.ThrowException("No connection strings were found.").When(ConfigurationManager.ConnectionStrings.IsNull());

            return ContextAwareConnectionStringsSettingService.GetConnectionString(connectionName);
        }

        /// <summary>
        /// Gets the connection string settings from the configuration file.
        /// </summary>
        /// <param name="connectionName">The name of the connection.</param>
        /// <returns>
        /// The connection string settings.
        /// </returns>
        public static ConnectionStringSettings GetConnectionStringSettings(string connectionName)
        {
            Guard.Will.ProtectAgainstNullArgument(() => connectionName);

            return ContextAwareConnectionStringsSettingService.GetConnectionStringSettings(connectionName);
        }

        /// <summary>
        /// Gets the connection string settings from the configuration file.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="connectionName">The name of the connection.</param>
        /// <returns>
        /// The connection string settings.
        /// </returns>
        public static ConnectionStringSettings GetConnectionStringSettings(string context, string connectionName)
        {
            Guard.Will.ProtectAgainstNullArgument(() => context);
            Guard.Will.ProtectAgainstNullArgument(() => connectionName);

            return ContextAwareConnectionStringsSettingService.GetConnectionStringSettings(context, connectionName);
        }
    }
}