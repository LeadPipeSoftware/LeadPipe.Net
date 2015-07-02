// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationUser.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
    /// This object creates the glue between applications and users.
    /// </summary>
    public class ApplicationUser : PersistableObject<Guid>
    {
        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value>The application.</value>
        [Required]
        public virtual Application Application { get; set; }

        /// <summary>
        /// Gets or sets the client version.
        /// </summary>
        /// <value>The client version.</value>
        public virtual string ClientVersion { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>The expiration date.</value>
        public virtual DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets a value indicating whether the user has expired.
        /// </summary>
        /// <value><c>true</c> if this instance is expired; otherwise, <c>false</c>.</value>
        public virtual bool IsExpired
        {
            get
            {
                if (this.ExpirationDate == null)
                {
                    return false;
                }

                return this.ExpirationDate <= DateTime.Now;
            }
        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        [Required]
        public virtual User User { get; set; }

        /// <summary>
        /// Gets the effective permissions.
        /// </summary>
        /// <returns>
        /// The list of effective permissions.
        /// </returns>
        public IList<Activity> GetEffectivePermissions()
        {
            var effectivePermissions = new List<Activity>();

            if (this.User.IsNotNull() && !this.User.IsExpired && this.User.IsActive)
            {
                effectivePermissions = this.User.GetEffectiveActivities(this.Application).ToList();
            }

            return effectivePermissions;
        }
    }
}