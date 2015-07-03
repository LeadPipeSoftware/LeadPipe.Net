// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorizerShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Moq;
using NUnit.Framework;

namespace LeadPipe.Net.Authorization.Tests.AuthorizerTests
{
    /// <summary>
	/// Tests the fluent authorizer.
	/// </summary>
	[TestFixture]
	public class AuthorizerShould
	{
		#region Public Methods and Operators

		/// <summary>
		/// Tests to ensure that the authorizer returns true if the user is authorized.
		/// </summary>
		[Test]
		public void ReturnTrueGivenUserIsAuthorized()
		{
			// Arrange
			var authorizationProvider = new Mock<IAuthorizationProvider>();
			authorizationProvider.Setup(x => x.Authorize(It.IsAny<AuthorizationRequest>())).Returns(true);
			var authorizer = new Authorizer(authorizationProvider.Object);

			var user = new User("testuser", "Test", "User");
            var application = new Application("FakeApplication");
            var activity = new Activity("FakeActivity", application);

			// Act
			var result = authorizer.Will.Assert.User(user).Can.ExecuteAnyOfTheseActivities(new[] { activity }).In(application);

			// Assert
			Assert.IsTrue(result);
		}

		/// <summary>
		/// Tests to ensure that the authorizer returns false when the user CAN execute an activity, but the chain is inverted with the Not property.
		/// </summary>
		[Test]
		public void ReturnFalseGivenUserIsAuthorizedWhenInverted()
		{
			// Arrange
			var authorizationProvider = new Mock<IAuthorizationProvider>();
			authorizationProvider.Setup(x => x.Authorize(It.IsAny<AuthorizationRequest>())).Returns(true);
			var authorizer = new Authorizer(authorizationProvider.Object);

            var user = new User("testuser", "Test", "User");
            var application = new Application("FakeApplication");
            var activity = new Activity("FakeActivity", application);

			// Act
			var result = authorizer.Will.Assert.User(user).Can.Not.ExecuteAnyOfTheseActivities(new[] { activity }).In(application);

			// Assert
			Assert.IsFalse(result);
		}

		/// <summary>
		/// Tests to ensure that the authorizer will throw an exception if the user is not authorized.
		/// </summary>
		[Test]
		[ExpectedException(typeof(LeadPipeNetAccessDeniedException))]
		public void ThrowExceptionGivenUserIsNotAuthorized()
		{
			// Arrange
			var authorizationProvider = new Mock<IAuthorizationProvider>();
			authorizationProvider.Setup(x => x.Authorize(It.IsAny<AuthorizationRequest>())).Returns(false);
			var authorizer = new Authorizer(authorizationProvider.Object);

            var user = new User("testuser", "Test", "User");
            var application = new Application("FakeApplication");
            var activity = new Activity("FakeActivity", application);

			// Act
			var result = authorizer.Will.ThrowAccessDeniedException().When.User(user).Can.Not.ExecuteAnyOfTheseActivities(new[] { activity }).In(application);

			// Assert
			Assert.IsTrue(result);
		}

		/// <summary>
		/// Tests to ensure that the authorizer will throw an exception if the user is not authorized for two activities.
		/// </summary>
		[Test]
		[ExpectedException(typeof(LeadPipeNetAccessDeniedException))]
		public void ThrowExceptionGivenUserIsNotAuthorizedForTwoActivities()
		{
			// Arrange
			var authorizationProvider = new Mock<IAuthorizationProvider>();
			authorizationProvider.Setup(x => x.Authorize(It.IsAny<AuthorizationRequest>())).Returns(false);
			var authorizer = new Authorizer(authorizationProvider.Object);

            var user = new User("testuser", "Test", "User");
            var application = new Application("FakeApplication");
            var activity1 = new Activity("FakeActivity1", application);
            var activity2 = new Activity("FakeActivity2", application);

			// Act
			var result = authorizer.Will.ThrowAccessDeniedException().When.User(user).Can.Not.ExecuteAnyOfTheseActivities(new[] { activity1, activity2 }).In(application);

			// Assert
			Assert.IsTrue(result);
		}

		/// <summary>
		/// Tests to ensure that the authorizer will throw an exception if the user is not authorized for three or more activities.
		/// </summary>
		[Test]
		[ExpectedException(typeof(LeadPipeNetAccessDeniedException))]
		public void ThrowExceptionGivenUserIsNotAuthorizedForThreeOrMoreActivities()
		{
			// Arrange
			var authorizationProvider = new Mock<IAuthorizationProvider>();
			authorizationProvider.Setup(x => x.Authorize(It.IsAny<AuthorizationRequest>())).Returns(false);
			var authorizer = new Authorizer(authorizationProvider.Object);

            var user = new User("testuser", "Test", "User");
            var application = new Application("FakeApplication");
            var activity1 = new Activity("FakeActivity1", application);
            var activity2 = new Activity("FakeActivity2", application);
            var activity3 = new Activity("FakeActivity3", application);

			// Act
			var result = authorizer.Will.ThrowAccessDeniedException().When.User(user).Can.Not.ExecuteAnyOfTheseActivities(new[] { activity1, activity2, activity3 }).In(application);

			// Assert
			Assert.IsTrue(result);
		}

        /////// <summary>
        /////// Tests to ensure that the authorizer returns true if the user is authorized to execute the current method.
        /////// </summary>
        ////[Test]
        ////public void ReturnTrueGivenUserIsAuthorizedToExecuteCurrentMethod()
        ////{
        ////    // Arrange
        ////    var authorizationProvider = new Mock<IAuthorizationProvider>();
        ////    authorizationProvider.Setup(x => x.Authorize(It.IsAny<AuthorizationRequest>())).Returns(true);
        ////    var authorizer = new Authorizer(authorizationProvider.Object);

        ////    var user = new User("testuser", "Test", "User");
        ////    var application = new Application("FakeApplication");
        ////    var activity = new Activity("FakeActivity", application);

        ////    // Act
        ////    ////var something = AuthorizerUnitTestClass<string>.TestMethod();
        ////    var result = authorizer.Will.Assert.User(userContext).Can.ExecuteThis();

        ////    // Assert
        ////    Assert.IsTrue(result);
        ////}

        /////// <summary>
        /////// Tests to ensure that the authorizer will throw an exception if the user is not authorized to execute the current method.
        /////// </summary>
        ////[Test]
        ////[ExpectedException(typeof(LeadPipeNetAccessDeniedException))]
        ////public void ThrowExceptionGivenUserIsNotAuthorizedToExecuteCurrentMethod()
        ////{
        ////    // Arrange
        ////    var authorizationProvider = new Mock<IAuthorizationProvider>();
        ////    authorizationProvider.Setup(x => x.Authorize(It.IsAny<AuthorizationRequest>())).Returns(false);
        ////    var authorizer = new Authorizer(authorizationProvider.Object);

        ////    var user = new User("testuser", "Test", "User");
        ////    var application = new Application("FakeApplication");
        ////    var activity = new Activity("FakeActivity", application);

        ////    // Act
        ////    var result = authorizer.Will.ThrowAccessDeniedException().When.User(userContext).Can.Not.ExecuteThis();

        ////    // Assert
        ////    Assert.IsTrue(result);
        ////}

		#endregion
	}

    /////// <summary>
    /////// A generic test class for the authorizer.
    /////// </summary>
    /////// <typeparam name="T">The type.</typeparam>
    ////internal class AuthorizerUnitTestClass<T>
    ////{
    ////    /// <summary>
    ////    /// A simple test method.
    ////    /// </summary>
    ////    /// <returns>True if the authorization was successful.</returns>
    ////    public static bool TestMethod()
    ////    {
    ////        var authorizationProvider = new Mock<IAuthorizationProvider>();
    ////        authorizationProvider.Setup(x => x.Authorize(It.IsAny<AuthorizationRequest>())).Returns(true);
    ////        var authorizer = new Authorizer(authorizationProvider.Object);

    ////        var user = new User("testuser", "Test", "User");

    ////        return authorizer.Will.Assert.User(new UserContext { Name = "AMERICAS\testuser" }).Can.ExecuteThis();
    ////    }
    ////}
}