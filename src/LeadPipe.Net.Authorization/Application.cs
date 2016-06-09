// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
    /// The application.
    /// </summary>
    public class Application : PersistableObject<Guid>, IEntity
    {
        /// <summary>
        /// The application administrators.
        /// </summary>
        private IList<User> administrators;

        /// <summary>
        /// The application users.
        /// </summary>
        private IList<ApplicationUser> users;

        /// <summary>
        /// Initializes a new instance of the <see cref="Application" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Application(string name)
            : this()
        {
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Application" /> class.
        /// </summary>
        protected Application()
        {
            this.Activities = new List<Activity>();
            this.ActivityGroups = new List<ActivityGroup>();
            this.administrators = new List<User>();
            this.Roles = new List<Role>();
            this.users = new List<ApplicationUser>();
        }

        /// <summary>
        /// Gets or sets the application's activities.
        /// </summary>
        /// <value>The activities.</value>
        public virtual IList<Activity> Activities { get; protected set; }

        /// <summary>
        /// Gets or sets the application's activity groups.
        /// </summary>
        /// <value>The activity groups.</value>
        public virtual IList<ActivityGroup> ActivityGroups { get; protected set; }

        /// <summary>
        /// Gets the application's administrators.
        /// </summary>
        /// <value>The administrators.</value>
        public virtual IEnumerable<User> Administrators
        {
            get
            {
                return this.administrators;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow mismatched client versions].
        /// </summary>
        /// <value><c>true</c> if [allow mismatched client versions]; otherwise, <c>false</c>.</value>
        public virtual bool AllowMismatchedClientVersions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow mismatched versions].
        /// </summary>
        /// <value><c>true</c> if [allow mismatched versions]; otherwise, <c>false</c>.</value>
        public virtual bool AllowMismatchedVersions { get; set; }

        /// <summary>
        /// Gets or sets the name of the client (if applicable).
        /// </summary>
        /// <value>The name of the client (if applicable).</value>
        public virtual string ClientName { get; set; }

        /// <summary>
        /// Gets or sets the client's current version.
        /// </summary>
        /// <value>The client's current version.</value>
        public virtual string CurrentClientVersion { get; set; }

        /// <summary>
        /// Gets or sets the current version.
        /// </summary>
        /// <value>The current version.</value>
        public virtual string CurrentVersion { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the Key.
        /// </summary>
        /// <value>The key.</value>
        public virtual string Key
        {
            get
            {
                return this.Name;
            }

            set
            {
                this.Name = value;
            }
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value>The name.</value>
        [Required]
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the application's roles.
        /// </summary>
        /// <value>The roles.</value>
        public virtual IList<Role> Roles { get; protected set; }

        /// <summary>
        /// Gets the application's users.
        /// </summary>
        /// <value>The users.</value>
        public virtual IEnumerable<ApplicationUser> Users
        {
            get
            {
                return this.users;
            }
        }

        /// <summary>
        /// Adds the administrator.
        /// </summary>
        /// <param name="user">The user.</param>
        public virtual void AddAdministrator(User user)
        {
            this.administrators.Add(user);
        }

        /// <summary>
        /// Adds the user to the application.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="expirationDate">The expiration date.</param>
        public virtual void AddUser(User user, DateTime? expirationDate)
        {
            var applicationUser = new ApplicationUser { User = user, ExpirationDate = expirationDate, Application = this, CreatedOn = DateTime.Now };

            this.users.Add(applicationUser);
        }

        /// <summary>
        /// Clients the versions match.
        /// </summary>
        /// <param name="versionToCheck">The version to check.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public virtual bool ClientVersionsMatch(string versionToCheck)
        {
            // If we have something to compare to...
            if (!string.IsNullOrEmpty(this.CurrentClientVersion))
            {
                var currentVersion = new Version(this.CurrentClientVersion).ToString(4);
                var clientVersion = new Version(versionToCheck).ToString(4);

                var comparisonResult = string.CompareOrdinal(currentVersion, clientVersion);

                return comparisonResult == 0;
            }

            return true;
        }

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public virtual void RemoveAdministrator(string userName)
        {
            var existingAdmin = this.administrators.FirstOrDefault(x => x.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));

            this.administrators.Remove(existingAdmin);
        }

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public virtual void RemoveUser(string userName)
        {
            var existingUser = this.users.FirstOrDefault(x => x.User.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));

            this.users.Remove(existingUser);
        }

        /// <summary>
        /// Determines whether a version matches the current version.
        /// </summary>
        /// <param name="versionToCheck">The version to check.</param>
        /// <returns><c>true</c> if [is version out of date] [the specified version to check]; otherwise, <c>false</c>.</returns>
        public virtual bool VersionsMatch(string versionToCheck)
        {
            var match = true;

            // If we have something to compare to...
            if (!string.IsNullOrEmpty(this.CurrentVersion))
            {
                // If the two don't match then we'll return false...
                if (!string.Equals(this.CurrentVersion, versionToCheck, StringComparison.InvariantCulture))
                {
                    match = false;
                }
            }

            return match;
        }
    }
}