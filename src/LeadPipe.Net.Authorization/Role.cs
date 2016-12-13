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
    /// The role.
    /// </summary>
    /// <remarks>
    /// An Role is a group of Users that can perform the same actions.
    /// </remarks>
    public class Role : PersistableObject<Guid>, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Role" /> class.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="name">The name.</param>
        public Role(Application application, string name)
        {
            this.Application = application;
            this.Name = name;
            this.Activities = new List<Activity>();
            this.ActivityGroups = new List<ActivityGroup>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Role" /> class.
        /// </summary>
        protected Role()
        {
        }

        /// <summary>
        /// Gets or sets the role's activities.
        /// </summary>
        /// <value>
        /// The activities.
        /// </value>
        public virtual IList<Activity> Activities { get; protected set; }

        /// <summary>
        /// Gets or sets the role's activity groups.
        /// </summary>
        /// <value>
        /// The activity groups.
        /// </value>
        public virtual IList<ActivityGroup> ActivityGroups { get; protected set; }

        /// <summary>
        /// Gets or sets Application.
        /// </summary>
        /// <value>
        /// The application.
        /// </value>
        [Required]
        public virtual Application Application { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the natural id.
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
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public virtual string Name { get; set; }
    }
}