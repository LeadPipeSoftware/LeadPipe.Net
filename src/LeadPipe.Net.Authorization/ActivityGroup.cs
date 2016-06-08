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
    /// A logical group of activities that represent macro functionality.
    /// </summary>
    public class ActivityGroup : PersistableObject<Guid>, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityGroup" /> class.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="name">The name.</param>
        public ActivityGroup(Application application, string name)
        {
            this.Application = application;
            this.Name = name;
            this.Activities = new List<Activity>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityGroup" /> class.
        /// </summary>
        protected ActivityGroup()
        {
        }

        /// <summary>
        /// Gets or sets the activity group's activities.
        /// </summary>
        /// <value>The activities.</value>
        public virtual IList<Activity> Activities { get; protected set; }

        /// <summary>
        /// Gets or sets the activity group's application.
        /// </summary>
        /// <value>The application.</value>
        [Required]
        public virtual Application Application { get; set; }

        /// <summary>
        /// Gets or sets the activity group's description.
        /// </summary>
        /// <value>The description.</value>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the natural id.
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
        /// Gets or sets the activity group's name.
        /// </summary>
        /// <value>The name.</value>
        [Required]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public virtual IList<Role> Roles { get; protected set; }
    }
}