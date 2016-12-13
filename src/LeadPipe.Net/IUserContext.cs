// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Security.Principal;

namespace LeadPipe.Net
{
    /// <summary>
    /// Defines a user context.
    /// </summary>
    public interface IUserContext : IPrincipal
    {
        /// <summary>
        /// Gets the user name without domain name..
        /// </summary>
        /// <value>user name without domain name.</value>
        string AccountName { get; }

        /// <summary>
        /// Gets or sets the type of the authentication.
        /// </summary>
        /// <value>The type of the authentication.</value>
        /// <remarks>The authentication type is passed to the common language runtime by the operating system or by another
        /// authentication provider. Basic authentication, NTLM, Kerberos, and Passport are examples of authentication
        /// types.</remarks>
        string AuthenticationType { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the initials.
        /// </summary>
        /// <value>The initials.</value>
        string Initials { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is authenticated.
        /// </summary>
        /// <value><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</value>
        /// <remarks>The setting for this property is determined by the Windows SECURITY_AUTHENTICATED_USER_RID security
        /// identifier (SID).</remarks>
        bool IsAuthenticated { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        /// <value>The locale.</value>
        string Locale { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks>The user name is passed to the common language runtime by the operating system or other authentication
        /// provider (such as ASP.NET). Name is typically set to the empty string ("") for an unauthenticated entity,
        /// but can take other values.</remarks>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>The password hash.</value>
        byte[] PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        string Title { get; set; }
    }
}