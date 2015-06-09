// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExampleParsedConfigurationSetting.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Configuration;

namespace LeadPipe.Net.Tests.ConfigurationTests
{
	/// <summary>
	/// An example parsed configuration setting.
	/// </summary>
	public class ExampleParsedConfigurationSetting : ConfigurationSetting
	{
		#region Constructors and Destructors

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

		#endregion

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