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
        /// Gets or sets the activity's activity groups.
        /// </summary>
        public virtual IList<ActivityGroup> ActivityGroups { get; protected set; }

        /// <summary>
        /// Gets or sets the activity's application.
        /// </summary>
        [Required]
        public virtual Application Application { get; set; }

        /// <summary>
        /// Gets or sets the authorization request log entries.
        /// </summary>
        public virtual IList<AuthorizationRequestLogEntry> AuthorizationRequestLogEntries { get; protected set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the Key.
        /// </summary>
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
        [Required]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the activity's roles.
        /// </summary>
        public virtual IList<Role> Roles { get; protected set; }

        /// <summary>
        /// Gets or sets the activity's users.
        /// </summary>
        public virtual IList<User> Users { get; protected set; }

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