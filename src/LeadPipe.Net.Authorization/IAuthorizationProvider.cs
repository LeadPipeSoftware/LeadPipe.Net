// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Authorization
{
    /// <summary>
    /// The authorization provider interface.
    /// </summary>
    public interface IAuthorizationProvider
    {
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
    }
}