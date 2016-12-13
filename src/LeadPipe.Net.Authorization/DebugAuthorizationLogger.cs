// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
    /// Logs authorization requests to the debug window.
    /// </summary>
    /// <seealso cref="LeadPipe.Net.Authorization.IAuthorizationLogger" />
    public class DebugAuthorizationLogger : IAuthorizationLogger
    {
        /// <summary>
        /// Logs the authorization request to the debug window.
        /// </summary>
        /// <param name="authorizationRequestLogEntry">The authorization request log entry.</param>
        public void LogAuthorizationRequest(AuthorizationRequestLogEntry authorizationRequestLogEntry)
        {
            if (authorizationRequestLogEntry.Granted)
            {
                Debug.WriteLine($"{authorizationRequestLogEntry.User} requested {authorizationRequestLogEntry.Activity} on {authorizationRequestLogEntry.RequestedOn} which was granted by {authorizationRequestLogEntry.GrantingUser} on {authorizationRequestLogEntry.GrantedOn}.");
            }

            Debug.WriteLine($"{authorizationRequestLogEntry.User} requested {authorizationRequestLogEntry.Activity} on {authorizationRequestLogEntry.RequestedOn} which was NOT granted.");
        }
    }
}