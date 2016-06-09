// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using System;
using System.Linq;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
    /// The authorization provider.
    /// </summary>
    public class AuthorizationProvider : IAuthorizationProvider
    {
        private readonly IAuthorizationLogger authorizationLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationProvider"/> class.
        /// </summary>
        /// <param name="authorizationLogger">The authorization logger.</param>
        public AuthorizationProvider(IAuthorizationLogger authorizationLogger)
        {
            this.authorizationLogger = authorizationLogger;
        }

        /// <summary>
        /// Performs an authorization request.
        /// </summary>
        /// <param name="authorizationRequest">
        /// The authorization request.
        /// </param>
        /// <returns>
        /// True if the request is authorized. False otherwise.
        /// </returns>
        public bool Authorize(AuthorizationRequest authorizationRequest)
        {
            Guard.Will.ThrowExceptionOfType<LeadPipeNetSecurityException>("Authorization requests must supply a user context.").When(authorizationRequest.ApplicationUser.User == null);
            Guard.Will.ThrowExceptionOfType<LeadPipeNetSecurityException>("Authorization requests must supply a name in the user context.").When(string.IsNullOrEmpty(authorizationRequest.ApplicationUser.User.Name));
            Guard.Will.ThrowExceptionOfType<LeadPipeNetSecurityException>("Authorization requests must supply activity names.").When(authorizationRequest.Activities == null);
            Guard.Will.ThrowExceptionOfType<LeadPipeNetSecurityException>("Authorization requests must supply an application name.").When(string.IsNullOrEmpty(authorizationRequest.ApplicationUser.Application.Name));

            var grantedActivities = authorizationRequest.ApplicationUser.GetEffectivePermissions();

            var isGranted = false;

            // For each of the activity names in the request...
            foreach (var activity in authorizationRequest.Activities)
            {
                // Check to see if the user has been granted the activity...
                isGranted = grantedActivities.Any(x => x.Name.Equals(activity.Name, StringComparison.OrdinalIgnoreCase));

                // Log the request...
                authorizationLogger.LogAuthorizationRequest(new AuthorizationRequestLogEntry() { Activity = activity, User = authorizationRequest.ApplicationUser.User, RequestedOn = DateTime.Now, Granted = isGranted });

                // If the user is authorized then we may as well stop here...
                if (isGranted && authorizationRequest.AuthorizeAll.IsFalse())
                {
                    return true;
                }
            }

            return isGranted;
        }
    }
}