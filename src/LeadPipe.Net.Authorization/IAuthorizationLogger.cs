// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Authorization
{
    /// <summary>
    /// Logs authorization requests.
    /// </summary>
    public interface IAuthorizationLogger
    {
        /// <summary>
        /// Logs the authorization request.
        /// </summary>
        /// <param name="authorizationRequestLogEntry">The authorization request log entry.</param>
        void LogAuthorizationRequest(AuthorizationRequestLogEntry authorizationRequestLogEntry);
    }
}