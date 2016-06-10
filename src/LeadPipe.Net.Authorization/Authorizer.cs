// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.Authorization
{
    /// <summary>
    /// A fluent authorization class.
    /// </summary>
    public class Authorizer :
        IAuthorizer,
        IAuthorizerActions,
        IAuthorizerWhen,
        IAuthorizerUser,
        IAuthorizerCan,
        IAuthorizerAssertions,
        IAuthorizerApplication
    {
        #region Constants and Fields

        /// <summary>
        /// The name of the calling method.
        /// </summary>
        private string callingMethodName;

        /// <summary>
        /// The name of the calling type.
        /// </summary>
        private string callingTypeName;

        /// <summary>
        /// The activity names.
        /// </summary>
        private IList<Activity> activities;

        /// <summary>
        /// The application name.
        /// </summary>
        private Application application;

        /// <summary>
        /// The exception to throw.
        /// </summary>
        private Exception exception;

        /// <summary>
        /// The next Boolean value.
        /// </summary>
        private bool not;

        /// <summary>
        /// Determines if the authorizer should throw an exception if not authorized.
        /// </summary>
        private bool shouldThrow;

        /// <summary>
        /// The user context.
        /// </summary>
        private User user;

        /// <summary>
        /// Determines if all the activities need to be authorized.
        /// </summary>
        private bool authorizeAllActivities;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Authorizer"/> class.
        /// </summary>
        public Authorizer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Authorizer"/> class.
        /// </summary>
        /// <param name="authorizationProvider">The authorization provider.</param>
        public Authorizer(IAuthorizationProvider authorizationProvider)
        {
            this.AuthorizationProvider = authorizationProvider;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the authorization provider.
        /// </summary>
        public virtual IAuthorizationProvider AuthorizationProvider { get; set; }

        /// <summary>
        /// Gets the start of the fluent authorizer chain.
        /// </summary>
        public IAuthorizerActions Will
        {
            get
            {
                Guard.Will.ThrowExceptionOfType<LeadPipeNetSecurityException>("The Authorizer requires an Authorization Provider.").When(this.AuthorizationProvider.IsNull());

                var frame = new StackFrame(1);
                var method = frame.GetMethod();

                this.callingMethodName = method.Name;

                if (method.DeclaringType != null)
                {
                    this.callingTypeName = method.DeclaringType.Name;
                }

                return this;
            }
        }

        /// <summary>
        /// The Assert chain method.
        /// </summary>
        /// <returns>
        /// The Authorizer set to assert the authorization result.
        /// </returns>
        public IAuthorizerUser Assert
        {
            get
            {
                this.shouldThrow = false;

                return this;
            }
        }

        /// <summary>
        /// Determines whether this instance [can].
        /// </summary>
        /// <returns>The Authorizer.</returns>
        public IAuthorizerAssertions Can
        {
            get
            {
                this.not = false;

                return this;
            }
        }

        /// <summary>
        /// Inverts Boolean fluent members.
        /// </summary>
        /// <returns>The Authorizer.</returns>
        public IAuthorizerAssertions Not
        {
            get
            {
                this.not = true;

                return this;
            }
        }

        /// <summary>
        /// Gets the when.
        /// </summary>
        public IAuthorizerUser When
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Sets the activity name(s). If more than one, only one needs to be authorized.
        /// </summary>
        /// <param name="activities">The activities.</param>
        /// <returns>
        /// The Authorizer with an activity name set.
        /// </returns>
        public IAuthorizerApplication ExecuteAnyOfTheseActivities(params Activity[] activities)
        {
            Guard.Will.ProtectAgainstNullArgument(() => activities);

            this.activities = activities;

            return this;
        }

        /// <summary>
        /// Sets the activity name(s). If more than one, all will be authorized.
        /// </summary>
        /// <param name="activities">The activity name(s).</param>
        /// <returns>
        /// The Authorizer with an activity name set.
        /// </returns>
        public IAuthorizerApplication ExecuteAllOfTheseActivities(params Activity[] activities)
        {
            Guard.Will.ProtectAgainstNullArgument(() => activities);

            this.activities = activities;

            this.authorizeAllActivities = true;

            return this;
        }

        /// <summary>
        /// Sets the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// The Authorizer with a user.
        /// </returns>
        public IAuthorizerCan User(User user)
        {
            Guard.Will.ProtectAgainstNullArgument(() => user);

            this.user = user;

            return this;
        }

        /// <summary>
        /// Sets the application name and performs the authorization assertion.
        /// </summary>
        /// <param name="application">
        /// Name of the application.
        /// </param>
        /// <returns>
        /// <c>true</c> if the user can perform the specified activity; otherwise, <c>false</c>.
        /// </returns>
        public bool In(Application application)
        {
            Guard.Will.ProtectAgainstNullArgument(() => application);

            this.application = application;

            var authorizationRequest = new AuthorizationRequest
                {
                    User = this.user,
                    Activities = this.activities,
                    AuthorizeAll = this.authorizeAllActivities
                };

            return this.Authorize(authorizationRequest);
        }

        /// <summary>
        /// The Throw chain method.
        /// </summary>
        /// <returns>
        /// The Authorizer set to throw an exception if the authorization fails.
        /// </returns>
        public IAuthorizerWhen ThrowAccessDeniedException()
        {
            this.shouldThrow = true;

            return this;
        }

        /// <summary>
        /// The Throw chain method.
        /// </summary>
        /// <param name="message">
        /// The exception message.
        /// </param>
        /// <returns>
        /// The Authorizer set to throw an exception if the authorization fails.
        /// </returns>
        public IAuthorizerWhen ThrowAccessDeniedException(string message)
        {
            // Throw an exception of the specified type...
            this.exception =
                (LeadPipeNetAccessDeniedException)Activator.CreateInstance(typeof(LeadPipeNetAccessDeniedException), message);

            return this;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Authorizes this instance.
        /// </summary>
        /// <param name="authorizationRequest">
        /// The authorization request.
        /// </param>
        /// <returns>
        /// True if authorized. False otherwise.
        /// </returns>
        private bool Authorize(AuthorizationRequest authorizationRequest)
        {
            var authorizationResult = this.AuthorizationProvider.Authorize(authorizationRequest);

            if (this.shouldThrow)
            {
                // If we don't already have an exception built up then build the default exception...
                if (this.exception == null)
                {
                    var exceptionMessage = new StringBuilder();

                    exceptionMessage.Append(this.user.Login.FormattedWith("{0} is not authorized to perform "));

                    if (authorizationRequest.Activities != null)
                    {
                        if (authorizationRequest.Activities.Count() > 1)
                        {
                            var activityNames = authorizationRequest.Activities.Select(activity => activity.Name).ToList();

                            if (activityNames.Count() > 2)
                            {
                                activityNames[activityNames.Count() - 1] = "or " + activityNames[activityNames.Count() - 1];

                                exceptionMessage.Append(activityNames.WrapEachWith(string.Empty, string.Empty, ", "));
                            }
                            else
                            {
                                exceptionMessage.Append(activityNames.WrapEachWith(string.Empty, string.Empty, " or "));
                            }
                        }
                        else if (authorizationRequest.Activities.Count() == 1)
                        {
                            var firstOrDefault = authorizationRequest.Activities.FirstOrDefault();

                            exceptionMessage.Append(firstOrDefault != null
                                ? firstOrDefault.Name.ToFriendlyName().FormattedWith("the \"{0}\" activity")
                                : "Unknown".FormattedWith("the \"{0}\" activity"));
                        }
                    }

                    exceptionMessage.Append(this.application.Name.FormattedWith(" in {0}."));

                    this.exception = new LeadPipeNetAccessDeniedException(exceptionMessage.ToString());
                }

                // If CAN...
                if (!this.not)
                {
                    if (authorizationResult)
                    {
                        return true;
                    }

                    throw this.exception;
                }

                // If CAN NOT...
                if (this.not)
                {
                    // Throw if they can...
                    if (authorizationResult)
                    {
                        return true;
                    }

                    throw this.exception;
                }
            }

            // If CAN NOT return the inverse...
            if (this.not)
            {
                return !authorizationResult;
            }

            return authorizationResult;
        }

        #endregion
    }
}