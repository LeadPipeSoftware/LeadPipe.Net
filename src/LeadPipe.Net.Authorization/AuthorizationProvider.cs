// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorizationProvider.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
	/// The authorization provider.
	/// </summary>
	public class AuthorizationProvider : IAuthorizationProvider
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
		public bool Authorize(AuthorizationRequest authorizationRequest)
		{
			Guard.Will.ThrowExceptionOfType<LeadPipeNetSecurityException>("Authorization requests must supply a user context.").When(authorizationRequest.ApplicationUser.User == null);
			Guard.Will.ThrowExceptionOfType<LeadPipeNetSecurityException>("Authorization requests must supply a name in the user context.").When(string.IsNullOrEmpty(authorizationRequest.ApplicationUser.User.Name));
			Guard.Will.ThrowExceptionOfType<LeadPipeNetSecurityException>("Authorization requests must supply activity names.").When(authorizationRequest.Activities == null);
			Guard.Will.ThrowExceptionOfType<LeadPipeNetSecurityException>("Authorization requests must supply an application name.").When(string.IsNullOrEmpty(authorizationRequest.ApplicationUser.Application.Name));
		
			var grantedActivities = authorizationRequest.ApplicationUser.GetEffectivePermissions();

			var isGranted = false;

			// For each of the activity names in the request...
			foreach (var activityName in authorizationRequest.Activities)
			{
				// Check to see if the user has been granted the activity...
				isGranted = grantedActivities.Any(x => x.Name.Equals(activityName));

				// TODO: Fire a domain event here to handle this.

                // Log the request...
                var authorizationRequestLogEntry = new AuthorizationRequestLogEntry() { Activity = activityName, User = authorizationRequest.ApplicationUser.User, RequestedOn = DateTime.Now, Granted = isGranted };

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