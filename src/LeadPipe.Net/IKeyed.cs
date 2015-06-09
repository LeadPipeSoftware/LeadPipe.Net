// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IKeyed.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net
{
	/// <summary>
	/// Defines an instance that is keyed.
	/// </summary>
	public interface IKeyed
	{
		#region Public Properties

		/// <summary>
		/// Gets the Key.
		/// </summary>
		string Key { get; }

		#endregion
	}
}