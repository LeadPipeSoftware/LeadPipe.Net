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
        private IList<User> users;
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
            this.users = new List<User>();
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
        public virtual IEnumerable<User> Users
        {
            get
            {
                return this.users;
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

            var user = new User(command.Login, this);

            this.administrators.Add(user);
        }

        /// <summary>
        /// Adds a user to the application.
        /// </summary>
        /// <param name="command">The command.</param>
        public virtual void AddUser(AddUserCommand command)
        {
            Guard.Will.ProtectAgainstNullArgument(() => command);

            var user = new User(command.Login, this);

            this.users.Add(user);
        }

        /// <summary>
        /// Grants a user the ability to perform an activity.
        /// </summary>
        /// <param name="command">The command.</param>
        public virtual void GrantUserActivity(GrantUserActivityCommand command)
        {
            Guard.Will.ProtectAgainstNullArgument(() => command);

            var user = GetUser(command.Login);

            if (user.UserGrants.Any(g => g.Activity.Name.Equals(command.ActivityName, StringComparison.OrdinalIgnoreCase))) return;

            var activity = GetActivity(command.ActivityName);

            user.GrantUserActivity(activity, command.GrantingUserLogin);
        }

        /// <summary>
        /// Grants a user the ability to perform any of the activities in an activity group.
        /// </summary>
        /// <param name="command">The command.</param>
        public virtual void GrantUserActivityGroup(GrantUserActivityGroupCommand command)
        {
            Guard.Will.ProtectAgainstNullArgument(() => command);

            var user = GetUser(command.Login);

            if (user.UserGrants.Any(g => g.ActivityGroup.Name.Equals(command.ActivityGroupName, StringComparison.OrdinalIgnoreCase))) return;

            var activityGroup = GetActivityGroup(command.ActivityGroupName);

            user.GrantUserActivityGroup(activityGroup, command.GrantingUserLogin);
        }

        /// <summary>
        /// Grants a user the ability to perform any of the activities in a role.
        /// </summary>
        /// <param name="command">The command.</param>
        public virtual void GrantUserRole(GrantUserRoleCommand command)
        {
            Guard.Will.ProtectAgainstNullArgument(() => command);

            var user = GetUser(command.Login);

            if (user.UserGrants.Any(g => g.Role.Name.Equals(command.RoleName, StringComparison.OrdinalIgnoreCase))) return;

            var role = GetRole(command.RoleName);

            user.GrantUserRole(role, command.GrantingUserLogin);
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

            var existingUser = this.users.FirstOrDefault(x => x.Login.Equals(command.Login, StringComparison.OrdinalIgnoreCase));

            this.users.Remove(existingUser);
        }

        /// <summary>
        /// Gets a user.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>The user.</returns>
        protected virtual User GetUser(string login)
        {
            var user = users.FirstOrDefault(u => u.Login.Equals(login, StringComparison.OrdinalIgnoreCase));

            Guard.Will.ThrowExceptionOfType<LeadPipeNetSecurityException>($"User {login} has not been added as a user of {Name}.");

            return user;
        }

        /// <summary>
        /// Gets an activity.
        /// </summary>
        /// <param name="activityName">Name of the activity.</param>
        /// <returns>The activity.</returns>
        protected virtual Activity GetActivity(string activityName)
        {
            var activity = activities.FirstOrDefault(a => a.Name.Equals(activityName, StringComparison.OrdinalIgnoreCase));

            Guard.Will.ThrowExceptionOfType<LeadPipeNetSecurityException>($"{activityName} is not an activity in {Name}.");

            return activity;
        }

        /// <summary>
        /// Gets an activity group.
        /// </summary>
        /// <param name="activityName">Name of the activity group.</param>
        /// <returns>The activity group.</returns>
        protected virtual ActivityGroup GetActivityGroup(string activityName)
        {
            var activityGroup = activityGroups.FirstOrDefault(a => a.Name.Equals(activityName, StringComparison.OrdinalIgnoreCase));

            Guard.Will.ThrowExceptionOfType<LeadPipeNetSecurityException>($"{activityName} is not an activity group in {Name}.");

            return activityGroup;
        }

        /// <summary>
        /// Gets a role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>The role.</returns>
        protected virtual Role GetRole(string roleName)
        {
            var role = roles.FirstOrDefault(a => a.Name.Equals(roleName, StringComparison.OrdinalIgnoreCase));

            Guard.Will.ThrowExceptionOfType<LeadPipeNetSecurityException>($"{roleName} is not a role in {Name}.");

            return role;
        }
    }
}