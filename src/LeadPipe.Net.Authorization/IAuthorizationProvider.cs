// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuthorizationProvider.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Authorization
{
    /// <summary>
	/// The authorization provider interface.
	/// </summary>
	public interface IAuthorizationProvider
	{
		#region Public Methods and Operators

		/// <summary>
		/// Performs an authorization request.
		/// </summary>
		/// <param name="authorizationRequest">
		/// The authorization request.
		/// </param>
		/// <returns>
		/// True if the request is authorized. False otherwise.
		/// </returns>
		bool Authorize(AuthorizationRequest authorizationRequest);

		#endregion
	}
}