// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetConnectionStringSettingsShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Configuration;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.ConfigurationTests
{
	/// <summary>
	/// GetConnectionStringSettings tests.
	/// </summary>
	[TestFixture]
	public class GetConnectionStringSettingsShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to ensure that we can retrieve a connection string setting a context value exists and is supplied.
		/// </summary>
		[Test]
		public void ReturnValueGivenContextSettingExistsAndContextSupplied()
		{
			// Arrange

			// Act
			var settings = ConfigurationService.GetConnectionStringSettings("11-UnitTest", "TestConnection");

			// Assert
			Assert.That(settings != null);
		}

		/// <summary>
		/// Tests to ensure that we can retrieve a connection string setting a context value exists and is not supplied.
		/// </summary>
		[Test]
		public void ReturnValueGivenContextSettingExistsAndContextIsNotSupplied()
		{
			// Arrange

			// Act
			var settings = ConfigurationService.GetConnectionStringSettings("TestConnection");

			// Assert
			Assert.That(settings != null);
		}

		#endregion
	}
}