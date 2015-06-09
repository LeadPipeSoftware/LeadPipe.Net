// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataSessionProvider.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Data
{
	/// <summary>
	/// The data session provider.
	/// </summary>
	/// <remarks>
	/// The DataSessionProvider's job is to create DataSession objects.
	/// </remarks>
	/// <typeparam name="T">The session type.</typeparam>
	public interface IDataSessionProvider<T>
	{
		#region Public Methods and Operators

		/// <summary>
		/// Creates a data session instance.
		/// </summary>
		/// <returns>
		/// A new data session.
		/// </returns>
		T Create();

		#endregion
	}
}