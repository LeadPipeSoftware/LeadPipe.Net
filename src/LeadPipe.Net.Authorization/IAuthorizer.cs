// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Authorization
{
    /// <summary>
    /// The authorizer entry point.
    /// </summary>
    public interface IAuthorizer
    {
        /// <summary>
        /// Gets or sets the authorization provider.
        /// </summary>
        IAuthorizationProvider AuthorizationProvider { get; set; }

        /// <summary>
        /// Gets the fluent entry point.
        /// </summary>
        IAuthorizerActions Will { get; }
    }

    /// <summary>
    /// The authorizer actions.
    /// </summary>
    public interface IAuthorizerActions
    {
        /// <summary>
        /// Gets Assert.
        /// </summary>
        IAuthorizerUser Assert { get; }

        /// <summary>
        /// The throw access denied exception.
        /// </summary>
        /// <returns>
        /// The authorizer.
        /// </returns>
        IAuthorizerWhen ThrowAccessDeniedException();

        /// <summary>
        /// The throw access denied exception.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The authorizer.
        /// </returns>
        IAuthorizerWhen ThrowAccessDeniedException(string message);
    }

    /// <summary>
    /// The i authorizer application.
    /// </summary>
    public interface IAuthorizerApplication
    {
        /// <summary>
        /// The in.
        /// </summary>
        /// <param name="application">
        /// The application.
        /// </param>
        /// <returns>
        /// The authorizer.
        /// </returns>
        bool In(Application application);
    }

    /// <summary>
    /// The i authorizer assertions.
    /// </summary>
    public interface IAuthorizerAssertions
    {
        /// <summary>
        /// Gets Not.
        /// </summary>
        IAuthorizerAssertions Not { get; }

        /// <summary>
        /// Executes all of these activities.
        /// </summary>
        /// <param name="activities">The activities.</param>
        /// <returns></returns>
        IAuthorizerApplication ExecuteAllOfTheseActivities(params Activity[] activities);

        /// <summary>
        /// Executes any of these activities.
        /// </summary>
        /// <param name="activities">The activities.</param>
        /// <returns>The authorizer.</returns>
        IAuthorizerApplication ExecuteAnyOfTheseActivities(params Activity[] activities);
    }

    /// <summary>
    /// The i authorizer can.
    /// </summary>
    public interface IAuthorizerCan
    {
        /// <summary>
        /// Gets Can.
        /// </summary>
        IAuthorizerAssertions Can { get; }
    }

    /// <summary>
    /// The i authorizer user.
    /// </summary>
    public interface IAuthorizerUser
    {
        /// <summary>
        /// The user.
        /// </summary>
        /// <param name="user">
        /// The user context.
        /// </param>
        /// <returns>
        /// The authorizer.
        /// </returns>
        IAuthorizerCan User(User user);
    }

    /// <summary>
    /// The i authorizer when.
    /// </summary>
    public interface IAuthorizerWhen
    {
        /// <summary>
        /// Gets When.
        /// </summary>
        IAuthorizerUser When { get; }
    }
}