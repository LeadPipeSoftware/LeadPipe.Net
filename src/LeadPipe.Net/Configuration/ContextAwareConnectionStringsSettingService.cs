// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using System.Configuration;
using System.Text;

namespace LeadPipe.Net.Configuration
{
    /// <summary>
    /// A context-aware connection strings setting service.
    /// </summary>
    public class ContextAwareConnectionStringsSettingService : IConnectionStringsSettingService
    {
        /// <summary>
        /// The context configuration key.
        /// </summary>
        public const string ContextKey = "Context";

        /// <summary>
        /// Gets the name of the connection provider.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns>
        /// The connection provider name.
        /// </returns>
        public string GetConnectionProviderName(string connectionName)
        {
            Guard.Will.ProtectAgainstNullArgument(() => connectionName);

            return ConfigurationManager.ConnectionStrings[connectionName].ProviderName;
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns>
        /// The connection string.
        /// </returns>
        public string GetConnectionString(string connectionName)
        {
            Guard.Will.ProtectAgainstNullArgument(() => connectionName);

            return this.GetConnectionStringSettings(connectionName)
                       .ConnectionString;
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns>
        /// The connection string.
        /// </returns>
        public string GetConnectionString(string context, string connectionName)
        {
            Guard.Will.ProtectAgainstNullArgument(() => connectionName);
            Guard.Will.ThrowException("No connection strings were found.").When(ConfigurationManager.ConnectionStrings.IsNull());

            return this.GetConnectionStringSettings(context, connectionName)
                       .ConnectionString;
        }

        /// <summary>
        /// Gets the connection string settings.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns>
        /// The connection string settings.
        /// </returns>
        public ConnectionStringSettings GetConnectionStringSettings(string connectionName)
        {
            Guard.Will.ProtectAgainstNullArgument(() => connectionName);

            var context = ConfigurationManager.AppSettings[ContextKey];

            return this.GetConnectionStringSettings(context, connectionName);
        }

        /// <summary>
        /// Gets the connection string settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns>
        /// The connection string settings.
        /// </returns>
        public ConnectionStringSettings GetConnectionStringSettings(string context, string connectionName)
        {
            Guard.Will.ProtectAgainstNullArgument(() => connectionName);
            Guard.Will.ThrowException("No connection strings were found.").When(ConfigurationManager.ConnectionStrings.IsNull());

            // If we didn't get a context then...
            if (string.IsNullOrEmpty(context))
            {
                // Try to fetch it from the configuration...
                var defaultContext = ConfigurationManager.AppSettings[ContextKey];

                // If that didn't turn anything up then...
                if (string.IsNullOrEmpty(defaultContext))
                {
                    // Get the raw setting...
                    return ConfigurationManager.ConnectionStrings[connectionName];
                }

                // If we did get something, use that as the context...
                context = defaultContext;
            }

            // Since we managed to get a context then build it up...
            var fullyQualifiedSettingName = new StringBuilder();

            fullyQualifiedSettingName.Append(context);
            fullyQualifiedSettingName.Append(".");
            fullyQualifiedSettingName.Append(connectionName);

            // Try to get the context-specific value otherwise get the default value...
            var connectionString = ConfigurationManager.ConnectionStrings[fullyQualifiedSettingName.ToString()] ?? ConfigurationManager.ConnectionStrings[connectionName];

            Guard.Will
                .ThrowException(connectionName.FormattedWith("No connection string was found for the connection name."))
                .When(connectionString == null);

            return connectionString;
        }
    }
}