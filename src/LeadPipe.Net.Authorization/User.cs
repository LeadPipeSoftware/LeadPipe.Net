// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using LeadPipe.Net.Extensions;
using LeadPipe.Net.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
    /// A user.
    /// </summary>
    public class User : PersistableObject<Guid>, IEntity
    {
        private DateTime? expirationDate;
        private bool isActive;
        private IList<UserGrant> userGrants;

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="login">The user's login.</param>
        /// <param name="application">The application.</param>
        public User(string login, Application application)
            : this()
        {
            this.Login = login;
            this.Application = application;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        protected User()
        {
            this.userGrants = new List<UserGrant>();
        }

        /// <summary>
        /// Gets or sets the application the user is associated with.
        /// </summary>
        public virtual Application Application { get; protected set; }

        /// <summary>
        /// Gets or sets the authorization request log entries.
        /// </summary>
        /// <value>The authorization request log entries.</value>
        public virtual IList<AuthorizationRequestLogEntry> AuthorizationRequestLogEntries { get; protected set; }

        /// <summary>
        /// Gets the effective activities.
        /// </summary>
        public virtual IEnumerable<Activity> EffectiveActivities
        {
            get
            {
                var validUserGrants = this.UserGrants.Where(x => x.ExpirationDate.IsNull() || x.ExpirationDate >= DateTime.Now);

                var effectiveActivities = validUserGrants.SelectMany(x => x.EffectiveActivities);

                return effectiveActivities;
            }
        }

        /// <summary>
        /// Gets or sets the user's expiration date.
        /// </summary>
        /// <value>The expiration date.</value>
        public virtual DateTime? ExpirationDate
        {
            get
            {
                return this.expirationDate;
            }

            set
            {
                this.expirationDate = value;

                // If we're expired then automatically inactivate...
                if (this.IsExpired)
                {
                    this.isActive = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the user is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public virtual bool IsActive
        {
            get
            {
                // If we're expired then automatically inactivate...
                if (this.IsExpired)
                {
                    this.isActive = false;
                }

                return this.isActive;
            }

            set
            {
                // If we're expired then automatically inactivate...
                if (this.IsExpired)
                {
                    this.isActive = false;
                }

                this.isActive = value;
            }
        }

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
        /// Gets or sets the natural id.
        /// </summary>
        public virtual string Key
        {
            get
            {
                return this.Login;
            }

            set
            {
                this.Login = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's login.
        /// </summary>
        [Required]
        [NoTrailingWhitespace]
        [NoLeadingWhitespace]
        public virtual string Login { get; protected set; }

        /// <summary>
        /// Gets the user grants for the user.
        /// </summary>
        public virtual IEnumerable<UserGrant> UserGrants
        {
            get { return userGrants; }
        }

        /// <summary>
        /// Expires the user immediately.
        /// </summary>
        public virtual void ExpireNow()
        {
            ExpirationDate = DateTime.Now.Subtract(5.Seconds()); // We fudge just a little to avoid a race condition
        }

        /// <summary>
        /// Grants the user the ability to perform an activity.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <param name="grantingUserLogin">The granting user's login.</param>
        public virtual void GrantUserActivity(Activity activity, string grantingUserLogin)
        {
            Guard.Will.ProtectAgainstNullArgument(() => activity);

            AddUserGrant(new UserGrant(this, activity, grantingUserLogin));
        }

        /// <summary>
        /// Grants a user the ability to perform any of the activities in an activity group.
        /// </summary>
        /// <param name="activityGroup">The activity group.</param>
        /// <param name="grantingUserLogin">The granting user's login.</param>
        public virtual void GrantUserActivityGroup(ActivityGroup activityGroup, string grantingUserLogin)
        {
            Guard.Will.ProtectAgainstNullArgument(() => activityGroup);

            AddUserGrant(new UserGrant(this, activityGroup, grantingUserLogin));
        }

        /// <summary>
        /// Grants a user the ability to perform any of the activities in a role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <param name="grantingUserLogin">The granting user's login.</param>
        public virtual void GrantUserRole(Role role, string grantingUserLogin)
        {
            Guard.Will.ProtectAgainstNullArgument(() => role);

            AddUserGrant(new UserGrant(this, role, grantingUserLogin));
        }

        /// <summary>
        /// Adds a user grant.
        /// </summary>
        /// <param name="userGrant">The user grant.</param>
        protected virtual void AddUserGrant(UserGrant userGrant)
        {
            Guard.Will.ProtectAgainstNullArgument(() => userGrant);

            if (userGrants.Contains(userGrant)) return;

            userGrants.Add(userGrant);
        }
    }
}