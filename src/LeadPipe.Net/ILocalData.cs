// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILocalData.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net
{
	/// <summary>
	/// Defines a local data object.
	/// </summary>
	public interface ILocalData
	{
		#region Public Properties

		/// <summary>
		/// Gets a count of the local data objects.
		/// </summary>
		int Count { get; }

		#endregion

		#region Public Indexers

		/// <summary>
		/// Gets or sets local data.
		/// </summary>
		/// <param name="key">The object data key.</param>
		/// <returns>The local data object.</returns>
		object this[object key] { get; set; }

		#endregion

		#region Public Methods

		/// <summary>
		/// Clears all local data objects.
		/// </summary>
		void Clear();

		#endregion
	}
}