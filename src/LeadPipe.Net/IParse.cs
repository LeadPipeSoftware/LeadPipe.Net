// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IParse.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net
{
	/// <summary>
	/// Defines an object that can parse a type.
	/// </summary>
	/// <typeparam name="T">The type to parse.</typeparam>
	public interface IParse<T>
	{
		#region Public Properties

		/// <summary>
		/// Gets the unparsed value.
		/// </summary>
		/// <value>The unparsed value.</value>
		T UnparsedValue { get; }

		#endregion

		#region Public Methods

		/// <summary>
		/// Parses this instance.
		/// </summary>
		/// <returns>The parsed value.</returns>
		T Parse();

		#endregion
	}
}