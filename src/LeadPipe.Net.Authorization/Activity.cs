// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using System;
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
        /// Gets or sets the activity's application.
        /// </summary>
        [Required]
        public virtual Application Application { get; protected set; }

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
        /// Updates the description.
        /// </summary>
        /// <param name="newDescription">The new description.</param>
        public virtual void UpdateDescription(string newDescription)
        {
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