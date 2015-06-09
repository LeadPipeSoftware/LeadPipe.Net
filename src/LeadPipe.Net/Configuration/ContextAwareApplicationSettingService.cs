// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContextAwareApplicationSettingService.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using System.Text;

namespace LeadPipe.Net.Configuration
{
	/// <summary>
	/// A context aware application setting service.
	/// </summary>
	public class ContextAwareApplicationSettingService : IApplicationSettingService
	{
		#region Constants

		/// <summary>
		/// The context configuration key.
		/// </summary>
		public const string ContextKey = "Context";

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Gets a setting.
		/// </summary>
		/// <param name="settingName">
		/// The name of the setting.
		/// </param>
		/// <returns>
		/// The setting value.
		/// </returns>
		public string GetSetting(string settingName)
		{
			Guard.Will.ProtectAgainstNullArgument(() => settingName);

			var context = ConfigurationManager.AppSettings[ContextKey];

			return this.GetSetting(context, settingName);
		}

		/// <summary>
		/// Gets the setting.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="settingName">The name of the setting.</param>
		/// <returns>
		/// The context-specific setting value.
		/// </returns>
		public string GetSetting(string context, string settingName)
		{
			Guard.Will.ProtectAgainstNullArgument(() => settingName);

			// If we didn't get a context then...
			if (string.IsNullOrEmpty(context))
			{
				// Try to fetch it from the configuration...
				var defaultContext = ConfigurationManager.AppSettings[ContextKey];

				// If that didn't turn anything up then...
				if (string.IsNullOrEmpty(defaultContext))
				{
					// Get the raw setting...
					return ConfigurationManager.AppSettings[settingName];
				}

				// If we did get something, use that as the context...
				context = defaultContext;
			}

			// Since we managed to get a context then build it up...
			var fullyQualifiedSettingName = new StringBuilder();

			fullyQualifiedSettingName.Append(context);
			fullyQualifiedSettingName.Append(".");
			fullyQualifiedSettingName.Append(settingName);

			// Try to get the context-specific value...
			var settingValue = ConfigurationManager.AppSettings[fullyQualifiedSettingName.ToString()];

			// If we didn't get a context-specific value then...
			if (string.IsNullOrEmpty(settingValue))
			{
				// Try to get a non-specific value...
				settingValue = ConfigurationManager.AppSettings[settingName];
			}

			return settingValue;
		}

		#endregion
	}
}