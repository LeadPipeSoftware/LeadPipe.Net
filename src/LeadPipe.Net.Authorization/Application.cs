// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LeadPipe.Net.Authorization.Commands;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
    /// The application.
    /// </summary>
    public class Application : PersistableObject<Guid>, IAggregateRoot
    {
        private IList<User> administrators;
        private IList<ApplicationUser> applicationUsers;
        private IList<Activity> activities;
        private IList<ActivityGroup> activityGroups;
        private IList<Role> roles;

        /// <summary>
        /// Initializes a new instance of the <see cref="Application" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Application(string name)
            : this()
        {
            Guard.Will.ProtectAgainstNullOrEmptyStringArgument(() => name);

            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Application" /> class.
        /// </summary>
        protected Application()
        {
            this.activities = new List<Activity>();
            this.activityGroups = new List<ActivityGroup>();
            this.administrators = new List<User>();
            this.roles = new List<Role>();
            this.applicationUsers = new List<ApplicationUser>();
        }

        /// <summary>
        /// Gets the application's activities.
        /// </summary>
        /// <value>The activities.</value>
        public virtual IEnumerable<Activity> Activities
        {
            get { return activities; }
        }

        /// <summary>
        /// Gets the application's activity groups.
        /// </summary>
        /// <value>The activity groups.</value>
        public virtual IEnumerable<ActivityGroup> ActivityGroups
        {
            get { return activityGroups; }
        }

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
        /// Gets the application's roles.
        /// </summary>
        /// <value>The roles.</value>
        public virtual IEnumerable<Role> Roles
        {
            get { return roles; }
        }

        /// <summary>
        /// Gets the application's users.
        /// </summary>
        /// <value>The users.</value>
        public virtual IEnumerable<ApplicationUser> Users
        {
            get
            {
                return this.applicationUsers;
            }
        }

        /// <summary>
        /// Adds an administrator to the application.
        /// </summary>
        /// <param name="command">The command.</param>
        public virtual void AddAdministrator(AddAdministratorCommand command)
        {
            Guard.Will.ProtectAgainstNullArgument(() => command);

            if (Administrators.Any(admins => admins.Login.Equals(command.Login, StringComparison.OrdinalIgnoreCase))) return;

            var user = new User(command.Login);

            this.administrators.Add(user);
        }

        /// <summary>
        /// Adds a user to the application.
        /// </summary>
        /// <param name="command">The command.</param>
        public virtual void AddUser(AddUserCommand command)
        {
            Guard.Will.ProtectAgainstNullArgument(() => command);

            var user = new User(command.Login);

            var applicationUser = new ApplicationUser { User = user, ExpirationDate = command.ExpirationDate, Application = this, CreatedOn = DateTime.Now };

            this.applicationUsers.Add(applicationUser);
        }

        /// <summary>
        /// Determines if the client versions match.
        /// </summary>
        /// <param name="versionToCheck">The version to check.</param>
        /// <returns><c>true</c> if the client versions match, <c>false</c> otherwise</returns>
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
        /// Removes an application administrator.
        /// </summary>
        /// <param name="command">The command.</param>
        public virtual void RemoveAdministrator(RemoveAdministratorCommand command)
        {
            Guard.Will.ProtectAgainstNullArgument(() => command);

            var existingAdmin = this.administrators.FirstOrDefault(x => x.Login.Equals(command.Login, StringComparison.OrdinalIgnoreCase));

            this.administrators.Remove(existingAdmin);
        }

        /// <summary>
        /// Removes the user from the application.
        /// </summary>
        /// <param name="command">The command.</param>
        public virtual void RemoveUser(RemoveUserCommand command)
        {
            Guard.Will.ProtectAgainstNullArgument(() => command);

            var existingUser = this.applicationUsers.FirstOrDefault(x => x.User.Login.Equals(command.Login, StringComparison.OrdinalIgnoreCase));

            this.applicationUsers.Remove(existingUser);
        }

        /// <summary>
        /// Determines whether a version matches the current version.
        /// </summary>
        /// <param name="versionToCheck">The version to check.</param>
        /// <returns><c>true</c> if the versions match; otherwise, <c>false</c>.</returns>
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