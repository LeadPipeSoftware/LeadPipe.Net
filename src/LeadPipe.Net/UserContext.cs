// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace LeadPipe.Net
{
    /// <summary>
    /// The user context.
    /// </summary>
    public class UserContext : IUserContext
    {
        /// <summary>
        /// The short name.
        /// </summary>
        private string accountName = string.Empty;

        /// <summary>
        /// The identity.
        /// </summary>
        private IIdentity identity;

        /// <summary>
        /// Gets or sets the user name without domain name.
        /// </summary>
        /// <value>User name without domain name.</value>
        public string AccountName
        {
            get
            {
                if (this.accountName.IsNullOrEmpty())
                {
                    this.accountName = Regex.Replace(this.Name, @"^.+\\", string.Empty);
                }

                return this.accountName;
            }

            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the type of the authentication.
        /// </summary>
        /// <value>The type of the authentication.</value>
        /// <remarks>The authentication type is passed to the common language runtime by the operating system or by another
        /// authentication provider. Basic authentication, NTLM, Kerberos, and Passport are examples of authentication
        /// types.</remarks>
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the identity of the current principal.
        /// </summary>
        /// <value>The identity.</value>
        /// <returns>The <see cref="T:System.Security.Principal.IIdentity" /> object associated with the current principal.</returns>
        public IIdentity Identity
        {
            get
            {
                return this.identity ?? (this.identity = new GenericIdentity(this.Name));
            }

            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the initials.
        /// </summary>
        /// <value>The initials.</value>
        public string Initials { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is authenticated.
        /// </summary>
        /// <value><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</value>
        /// <remarks>The setting for this property is determined by the Windows SECURITY_AUTHENTICATED_USER_RID security
        /// identifier (SID).</remarks>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Locale.
        /// </summary>
        /// <value>The locale.</value>
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets Location Code.
        /// </summary>
        /// <value>The location code.</value>
        public int LocationCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the location.
        /// </summary>
        /// <value>The name of the location.</value>
        public string LocationName { get; set; }

        /// <summary>
        /// Gets or sets User Name.
        /// </summary>
        /// <value>The name including the domain. ie americas\johndoe</value>
        /// <remarks>The user name is passed to the common language runtime by the operating system or other authentication
        /// provider (such as ASP.NET). Name is typically set to the empty string ("") for an unauthenticated entity,
        /// but can take other values.</remarks>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Password Hash.
        /// </summary>
        /// <value>The password hash.</value>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Determines whether the current principal belongs to the specified role.
        /// </summary>
        /// <param name="role">The name of the role for which to check membership.</param>
        /// <returns>True if the current principal is a member of the specified role; otherwise, false.</returns>
        public bool IsInRole(string role)
        {
            // Required by IPrincipal
            return true;
        }
    }
}