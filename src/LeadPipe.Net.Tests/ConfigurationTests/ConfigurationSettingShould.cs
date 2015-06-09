// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationSettingShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.ConfigurationTests
{
	/// <summary>
	/// ConfigurationSetting tests.
	/// </summary>
	[TestFixture]
	public class ConfigurationSettingShould
	{
		#region Public Methods

		/// <summary>
		/// Tests to ensure that we can retrieve a configuration setting.
		/// </summary>
		[Test]
		public void ReturnValueGivenNoLocationSpecificValueExists()
		{
			// Arrange

			// Act
			var exampleConfigurationSetting = new ExampleConfigurationSetting("UnitTestPlain");

			// Assert
			Assert.True(exampleConfigurationSetting.Value.Equals("UnitTestPlain.VALUE"));
		}

		/// <summary>
		/// Tests to ensure that we get null instead of an exception if the key doesn't exist.
		/// </summary>
		public void ReturnNullGivenKeyDoesNotExist()
		{
			// Arrange

			// Act
			var exampleConfigurationSetting = new ExampleConfigurationSetting("SomeKeyThatShouldNeverBe");

			// Assert
			Assert.True(exampleConfigurationSetting.Value.IsNull());
		}

		/// <summary>
		/// Tests to ensure that the Location-specific value is returned even when the Location value matches.
		/// </summary>
		[Test]
		public void ReturnLocationSpecificValueGivenLocationSpecificValueExistsAndMatchesCurrentLocation()
		{
			// Arrange

			// Act
			var exampleConfigurationSetting = new ExampleContextAwareConfigurationSetting("11-UnitTest", "UnitTestLocationSpecific");

			// Assert
			Assert.True(exampleConfigurationSetting.Value.Equals("11-UnitTest.UnitTestLocationSpecific.VALUE"));
		}

		/// <summary>
		/// Tests to ensure that the specific Location value is returned when it is specified.
		/// </summary>
		[Test]
		public void ReturnLocationSpecificValueGivenLocationSpecificValueExists()
		{
			// Arrange

			// Act
			var exampleConfigurationSetting = new ExampleContextAwareConfigurationSetting("17-UnitTest", "UnitTestLocationSpecific");

			// Assert
			Assert.True(exampleConfigurationSetting.Value.Equals("17-UnitTest.UnitTestLocationSpecific.VALUE"));
		}

		/// <summary>
		/// Tests to ensure that the Location code is accurate when it is not explicit.
		/// </summary>
		[Test]
		public void ReturnDefaultValueGivenLocationSpecificValueDoesNotExist()
		{
			// Arrange

			// Act
			var exampleConfigurationSetting = new ExampleContextAwareConfigurationSetting("14-UnitTest", "UnitTestLocationSpecific");

			// Assert
			Assert.True(exampleConfigurationSetting.Value.Equals("DEFAULT.UnitTestLocationSpecific.VALUE"));
		}

		/// <summary>
		/// Tests to ensure a parsed configuration setting parses correctly.
		/// </summary>
		[Test]
		public void ReturnParsedLocationSpecificValueGivenLocationSpecificValueExistsAndMatchesCurrentLocation()
		{
			// Arrange

			// Act
			var exampleConfigurationSetting = new ExampleParsedConfigurationSetting("UnitTestParsed", "I PARSED THIS");

			var value = exampleConfigurationSetting.Value;

			// Assert
			Assert.True(value.Equals("11-UnitTest.I PARSED THIS AND NOT THIS"));
		}

		/// <summary>
		/// Tests to ensure a parsed configuration setting parses correctly.
		/// </summary>
		[Test]
		public void ReturnParsedLocationSpecificValueGivenLocationSpecificValueExists()
		{
			// Arrange

			// Act
			var exampleConfigurationSetting = new ExampleParsedConfigurationSetting("UnitTestParsed", "I PARSED THIS")
				{
					Context = "17-UnitTest"
				};

			var value = exampleConfigurationSetting.Value;

			// Assert
			Assert.True(value.Equals("17-UnitTest.I PARSED THIS AND NOT THIS"));
		}

		/// <summary>
		/// Tests to ensure a parsed configuration setting parses correctly.
		/// </summary>
		[Test]
		public void ReturnParsedLocationSpecificValueGivenLocationSpecificValueDoesNotExist()
		{
			// Arrange

			// Act
			var exampleConfigurationSetting = new ExampleParsedConfigurationSetting("UnitTestParsed", "I PARSED THIS")
			{
				Context = "14-UnitTest"
			};

			var value = exampleConfigurationSetting.Value;

			// Assert
			Assert.True(value.Equals("DEFAULT.I PARSED THIS AND NOT THIS"));
		}

		/// <summary>
		/// Tests to ensure that the IConfigurationSetting Enumeration behaves well.
		/// </summary>
		[Test]
		public void BehaveWellAsAnEnumeration()
		{
			//// TODO: De-lame this unit test!

			// Arrange

			// Act
			var value = ExampleConfiguration.Location17Setting.Value;

			// Assert
			Assert.True(value.Equals("17-UnitTest.UnitTestLocationSpecific.VALUE"));
		}

		#endregion
	}
}