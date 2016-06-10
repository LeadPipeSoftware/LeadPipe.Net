// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
    /// The user grant.
    /// </summary>
    public class UserGrant : PersistableObject<Guid>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserGrant"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="activity">The activity.</param>
        /// <param name="grantingUserLogin">The granting user's login.</param>
        public UserGrant(User user, Activity activity, string grantingUserLogin)
        {
            Guard.Will.ProtectAgainstNullArgument(() => user);
            Guard.Will.ProtectAgainstNullArgument(() => activity);

            User = user;
            Activity = activity;
            GrantingUserLogin = grantingUserLogin;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserGrant"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="activityGroup">The activity group.</param>
        /// <param name="grantingUserLogin">The granting user's login.</param>
        public UserGrant(User user, ActivityGroup activityGroup, string grantingUserLogin)
        {
            Guard.Will.ProtectAgainstNullArgument(() => user);
            Guard.Will.ProtectAgainstNullArgument(() => activityGroup);

            User = user;
            ActivityGroup = activityGroup;
            GrantingUserLogin = grantingUserLogin;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserGrant"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="role">The role.</param>
        /// <param name="grantingUserLogin">The granting user's login.</param>
        public UserGrant(User user, Role role, string grantingUserLogin)
        {
            Guard.Will.ProtectAgainstNullArgument(() => user);
            Guard.Will.ProtectAgainstNullArgument(() => role);

            User = user;
            Role = role;
            GrantingUserLogin = grantingUserLogin;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserGrant"/> class.
        /// </summary>
        protected UserGrant()
        {
        }

        /// <summary>
        /// Gets or sets the granted activity.
        /// </summary>
        public virtual Activity Activity { get; protected set; }

        /// <summary>
        /// Gets or sets the granted activity group.
        /// </summary>
        public virtual ActivityGroup ActivityGroup { get; protected set; }

        /// <summary>
        /// Gets the effective activities.
        /// </summary>
        public virtual IEnumerable<Activity> EffectiveActivities
        {
            get
            {
                var effectiveActivities = new List<Activity>();

                if (Activity != null)
                {
                    effectiveActivities.Add(Activity);
                }
                else if (ActivityGroup.IsNotNull() && ActivityGroup.Activities.Any())
                {
                    effectiveActivities.AddRange(ActivityGroup.Activities);
                }
                else if (Role.IsNotNull())
                {
                    if (Role.Activities.Any())
                    {
                        effectiveActivities.AddRange(Role.Activities);
                    }

                    if (Role.ActivityGroups.Any())
                    {
                        foreach (ActivityGroup activityGroup in Role.ActivityGroups)
                        {
                            if (activityGroup.Activities.Any())
                            {
                                effectiveActivities.AddRange(activityGroup.Activities);
                            }
                        }
                    }
                }

                return effectiveActivities.Distinct().ToList();
            }
        }

        /// <summary>
        /// Gets or sets the grant's expiration date.
        /// </summary>
        public virtual DateTime? ExpirationDate { get; protected set; }

        /// <summary>
        /// Gets or sets the granting user's login.
        /// </summary>
        public virtual string GrantingUserLogin { get; protected set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public virtual Role Role { get; protected set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        [Required]
        public virtual User User { get; protected set; }

        /// <summary>
        /// Sets the expiration date for the user grant.
        /// </summary>
        /// <param name="expirationDate">The expiration date.</param>
        public virtual void SetExpirationDate(DateTime expirationDate)
        {
            this.ExpirationDate = expirationDate;
        }

        /// <summary>
        /// Determines whether the specified object is valid.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>
        /// A collection that holds failed-validation information.
        /// </returns>
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Activity.IsNull() && ActivityGroup.IsNull() && Role.IsNull())
            {
                yield return
                    new ValidationResult("Either an Activity, Activity Group, or a Role is required to create a user grant.");
            }
        }
    }
}