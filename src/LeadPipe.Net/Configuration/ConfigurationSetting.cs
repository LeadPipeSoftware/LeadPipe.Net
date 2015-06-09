// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationSetting.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;

namespace LeadPipe.Net.Configuration
{
	/// <summary>
	/// A base configuration setting.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The idea here is to combine some core framework offerings into a very easy to access and use system for app
	/// config. We're elevating settings to first class citizens and inverting the manager/setting relationship and
	/// then (optionally) wrapping settings into one of our nifty enumerations.
	/// </para>
	/// <para>
	/// In other words, we want you to be able to access configuration settings like this:
	/// <code>
	/// if (ApplicationSettings.MyNiftySetting.Value.Equals("Blarg") { ... }
	/// </code>
	/// </para>
	/// <para>
	/// The implementation is smart. It allows for configuration value parsing as well as domain-specific concepts such
	/// as IContextAware for value switching. In other words, you can create config settings like this:
	/// <code>
	/// add key="Location" value="17"
	/// add key="UnitTestPlain" value="UnitTestPlain.VALUE"
	/// add key="11.UnitTestLocationSpecific" value="11.UnitTestLocationSpecific.VALUE"
	/// add key="17.UnitTestLocationSpecific" value="17.UnitTestLocationSpecific.VALUE"
	/// add key="UnitTestLocationSpecific" value="DEFAULT.UnitTestLocationSpecific.VALUE"
	/// add key="11.UnitTestParsed" value="11.{PARSE THIS} AND NOT THIS"
	/// add key="17.UnitTestParsed" value="17.{PARSE THIS} AND NOT THIS"
	/// add key="UnitTestParsed" value="DEFAULT.{PARSE THIS} AND NOT THIS"
	/// </code>
	/// ...then, after a little bit of work, access the settings like this:
	/// </para>
	/// <code>
	/// var myValue = YourConfigSettingsEnumeration.UnitTestLocationSpecific.Value;
	/// </code>
	/// And get "17.UnitTestLocationSpecific.VALUE" as the value of myValue!
	/// </remarks>
	public abstract class ConfigurationSetting : IConfigurationSetting, IParse<string>, IContextAware
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigurationSetting"/> class.
		/// </summary>
		/// <param name="key">
		/// The configuration key.
		/// </param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "GBM: Reviewed.")]
		protected ConfigurationSetting(string key)
		{
			this.Key = key;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigurationSetting"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="key">The key.</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "GBM: Reviewed.")]
		protected ConfigurationSetting(string context, string key)
		{
			this.Context = context;
			this.Key = key;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the context.
		/// </summary>
		public string Context { get; set; }

		/// <summary>
		/// Gets or sets the configuration key.
		/// </summary>
		public virtual string Key { get; protected set; }

		/// <summary>
		/// Gets or sets the unparsed value.
		/// </summary>
		public string UnparsedValue { get; protected set; }

		/// <summary>
		/// Gets the value.
		/// </summary>
		public virtual string Value
		{
			get
			{
				this.Refresh();

				return this.Parse();
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings:
		/// Value
		/// Meaning
		/// Less than zero
		/// This object is less than the <paramref name="other" /> parameter.
		/// Zero
		/// This object is equal to <paramref name="other" />.
		/// Greater than zero
		/// This object is greater than <paramref name="other" />.</returns>
		public int CompareTo(object other)
		{
			if (other == null)
			{
				return 1;
			}

			var otherConfigurationSetting = other as ConfigurationSetting;

			if (otherConfigurationSetting != null)
			{
				return otherConfigurationSetting != null
						   ? string.Compare(this.ToString(), otherConfigurationSetting.ToString(), System.StringComparison.Ordinal)
						   : 1;
			}

			return 1;
		}

		/// <summary>
		/// Parses this instance.
		/// </summary>
		/// <returns>The parsed value.</returns>
		public virtual string Parse()
		{
			return this.UnparsedValue;
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
		public override string ToString()
		{
			var stringValue = new StringBuilder();

			stringValue.Append(this.Context);
			stringValue.Append(".");
			stringValue.Append(this.Key);

			return stringValue.ToString();
		}

		#endregion

		/// <summary>
		/// Refreshes the value of the configuration setting.
		/// </summary>
		protected void Refresh()
		{
			this.UnparsedValue = ConfigurationService.GetApplicationSetting(this.Context, this.Key);
		}
	}
}