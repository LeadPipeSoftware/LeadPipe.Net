// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApplicationSettingService.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Configuration
{
	/// <summary>
	/// Defines an application configuration service.
	/// </summary>
	public interface IApplicationSettingService
	{
		#region Public Methods

		/// <summary>
		/// Gets a setting.
		/// </summary>
		/// <param name="settingName">The name of the setting.</param>
		/// <returns>The setting value.</returns>
		string GetSetting(string settingName);

		#endregion
	}
}