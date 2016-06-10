// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
    /// Represents a single, discrete capability in the application. The smallest unit of work possible.
    /// </summary>
    public class Activity : PersistableObject<Guid>, IEntity
    {
        /// <summary>
        /// The users.
        /// </summary>
        protected IList<User> users;

        /// <summary>
        /// The roles.
        /// </summary>
        protected IList<Role> roles;

        /// <summary>
        /// The activity groups.
        /// </summary>
        protected IList<ActivityGroup> activityGroups;

        /// <summary>
        /// Initializes a new instance of the <see cref="Activity" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="application">The application.</param>
        public Activity(string name, Application application)
        {
            this.Application = application;
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Activity" /> class.
        /// </summary>
        protected Activity()
        {
        }

        /// <summary>
        /// Gets the activity's activity groups.
        /// </summary>
        public virtual IEnumerable<ActivityGroup> ActivityGroups
        {
            get { return activityGroups; }
        }

        /// <summary>
        /// Gets or sets the activity's application.
        /// </summary>
        [Required]
        public virtual Application Application { get; protected set; }

        /// <summary>
        /// Gets or sets the authorization request log entries.
        /// </summary>
        public virtual IList<AuthorizationRequestLogEntry> AuthorizationRequestLogEntries { get; protected set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public virtual string Description { get; protected set; }

        /// <summary>
        /// Gets or sets the Key.
        /// </summary>
        public virtual string Key
        {
            get
            {
                return this.Name;
            }

            protected set
            {
                this.Name = value;
            }
        }

        /// <summary>
        /// Gets the name of the activity.
        /// </summary>
        [Required]
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Gets the activity's roles.
        /// </summary>
        public virtual IEnumerable<Role> Roles
        {
            get { return roles; }
        }

        /// <summary>
        /// Gets the activity's users.
        /// </summary>
        public virtual IEnumerable<User> Users
        {
            get { return users; }
        }

        /// <summary>
        /// Deletes the description.
        /// </summary>
        public virtual void DeleteDescription()
        {
            this.Description = null;
        }

        /// <summary>
        /// Updates the description.
        /// </summary>
        /// <param name="newDescription">The new description.</param>
        public virtual void UpdateDescription(string newDescription)
        {
            Guard.Will.ProtectAgainstNullOrEmptyStringArgument(() => newDescription);

            this.Description = newDescription;
        }

        /// <summary>
        /// Updates the name.
        /// </summary>
        /// <param name="newName">The new name.</param>
        public virtual void UpdateName(string newName)
        {
            Guard.Will.ProtectAgainstNullOrEmptyStringArgument(() => newName);

            this.Name = newName;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{Application}:{Name}}}";
        }
    }
}