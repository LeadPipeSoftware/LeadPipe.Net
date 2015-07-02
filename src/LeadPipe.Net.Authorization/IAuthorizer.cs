// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuthorizer.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
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
		#region Public Properties

		/// <summary>
		/// Gets Assert.
		/// </summary>
		IAuthorizerUser Assert { get; }

		#endregion

		#region Public Methods and Operators

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

		#endregion
	}

	/// <summary>
	/// The i authorizer when.
	/// </summary>
	public interface IAuthorizerWhen
	{
		#region Public Properties

		/// <summary>
		/// Gets When.
		/// </summary>
		IAuthorizerUser When { get; }

		#endregion
	}

	/// <summary>
	/// The i authorizer user.
	/// </summary>
	public interface IAuthorizerUser
	{
		#region Public Methods and Operators

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

		#endregion
	}

	/// <summary>
	/// The i authorizer can.
	/// </summary>
	public interface IAuthorizerCan
	{
		#region Public Properties

		/// <summary>
		/// Gets Can.
		/// </summary>
		IAuthorizerAssertions Can { get; }

		#endregion
	}

	/// <summary>
	/// The i authorizer assertions.
	/// </summary>
	public interface IAuthorizerAssertions
	{
		#region Public Properties

		/// <summary>
		/// Gets Not.
		/// </summary>
		IAuthorizerAssertions Not { get; }

		#endregion

		#region Public Methods and Operators

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

        #endregion
	}

	/// <summary>
	/// The i authorizer application.
	/// </summary>
	public interface IAuthorizerApplication
	{
		#region Public Methods and Operators

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

		#endregion
	}
}