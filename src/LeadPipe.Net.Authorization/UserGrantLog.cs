// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using System;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
    /// The user grant log.
    /// </summary>
    public class UserGrantLog : PersistableObject<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserGrantLog" /> class.
        /// </summary>
        /// <param name="applicationName">Name of the application.</param>
        /// <param name="userGrant">The user grant.</param>
        public UserGrantLog(string applicationName, UserGrant userGrant)
        {
            this.ApplicationName = applicationName;

            this.ActivityName = userGrant.Activity.IsNotNull() ? userGrant.Activity.Name : null;
            this.ActivityGroupName = userGrant.ActivityGroup.IsNotNull() ? userGrant.ActivityGroup.Name : null;
            this.RoleName = userGrant.Role.IsNotNull() ? userGrant.Role.Name : null;

            this.UserName = userGrant.User.Login;
            this.GrantingUser = userGrant.GrantingUser;
            this.GrantedOn = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserGrantLog" /> class.
        /// </summary>
        protected UserGrantLog()
        {
        }

        /// <summary>
        /// Gets or sets the name of the activity group.
        /// </summary>
        /// <value>
        /// The name of the activity group.
        /// </value>
        public virtual string ActivityGroupName { get; protected set; }

        /// <summary>
        /// Gets or sets the name of the activity.
        /// </summary>
        /// <value>
        /// The name of the activity.
        /// </value>
        public virtual string ActivityName { get; protected set; }

        /// <summary>
        /// Gets or sets the name of the application.
        /// </summary>
        /// <value>
        /// The name of the application.
        /// </value>
        public virtual string ApplicationName { get; protected set; }

        /// <summary>
        /// Gets or sets the granted on.
        /// </summary>
        /// <value>
        /// The granted on.
        /// </value>
        public virtual DateTime GrantedOn { get; protected set; }

        /// <summary>
        /// Gets or sets the granting user.
        /// </summary>
        /// <value>
        /// The granting user.
        /// </value>
        public virtual string GrantingUser { get; protected set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>
        /// The name of the role.
        /// </value>
        public virtual string RoleName { get; protected set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public virtual string UserName { get; protected set; }
    }
}