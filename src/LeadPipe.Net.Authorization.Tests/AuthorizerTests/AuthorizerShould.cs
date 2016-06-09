// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Lucene.Tests;
using NUnit.Framework;

namespace LeadPipe.Net.Authorization.Tests.AuthorizerTests
{
    /// <summary>
    /// Tests the fluent authorizer.
    /// </summary>
    [TestFixture]
    public class AuthorizerShould
    {
        /// <summary>
        /// Tests to ensure that the authorizer returns FALSE when the user CAN execute an activity, but the chain is inverted with the Not property.
        /// </summary>
        [Test]
        public void ReturnFalseGivenUserIsAuthorizedWhenInverted()
        {
            // Arrange
            Bootstrapper.Start();

            var authorizer = Bootstrapper.Container.GetInstance<IAuthorizer>();

            var user = new User("testuser", "Test", "User") {IsActive = true};

            var application = new Application("FakeApplication");
            application.AddUser(user, null);

            var activity = new Activity("FakeActivity", application);
            application.Activities.Add(activity);

            var userGrant = new UserGrant
            {
                Activity = activity,
                User = user,
                GrantingUser = "MANAGER"
            };

            user.UserGrants.Add(userGrant);

            // Act
            var result = authorizer.Will.Assert.User(user).Can.Not.ExecuteAnyOfTheseActivities(new[] { activity }).In(application);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Tests to ensure that the authorizer returns true if the user is authorized.
        /// </summary>
        [Test]
        public void ReturnTrueGivenUserIsAuthorized()
        {
            // Arrange
            Bootstrapper.Start();

            var authorizer = Bootstrapper.Container.GetInstance<IAuthorizer>();

            var user = new User("testuser", "Test", "User") { IsActive = true };

            var application = new Application("FakeApplication");
            application.AddUser(user, null);

            var activity = new Activity("FakeActivity", application);
            application.Activities.Add(activity);

            var userGrant = new UserGrant
            {
                Activity = activity,
                User = user,
                GrantingUser = "MANAGER"
            };

            user.UserGrants.Add(userGrant);

            // Act
            var result = authorizer.Will.Assert.User(user).Can.ExecuteAnyOfTheseActivities(new[] { activity }).In(application);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests to ensure that the authorizer will throw an exception if the user is not authorized.
        /// </summary>
        [Test]
        public void ThrowExceptionGivenUserIsNotAuthorized()
        {
            // Arrange
            Bootstrapper.Start();

            var authorizer = Bootstrapper.Container.GetInstance<IAuthorizer>();

            var user = new User("testuser", "Test", "User") { IsActive = true };

            var application = new Application("FakeApplication");
            application.AddUser(user, null);

            var activity = new Activity("FakeActivity", application);
            application.Activities.Add(activity);

            // Act & Assert
            Assert.Throws<LeadPipeNetAccessDeniedException>(() => authorizer.Will.ThrowAccessDeniedException().When.User(user).Can.Not.ExecuteAnyOfTheseActivities(new[] { activity }).In(application));
        }

        /// <summary>
        /// Tests to ensure that the authorizer will throw an exception if the user is not authorized for three or more activities.
        /// </summary>
        [Test]
        public void ThrowExceptionGivenUserIsNotAuthorizedForThreeOrMoreActivities()
        {
            // Arrange
            Bootstrapper.Start();

            var authorizer = Bootstrapper.Container.GetInstance<IAuthorizer>();

            var user = new User("testuser", "Test", "User") { IsActive = true };

            var application = new Application("FakeApplication");
            application.AddUser(user, null);

            var activity1 = new Activity("FakeActivity1", application);
            application.Activities.Add(activity1);

            var activity2 = new Activity("FakeActivity2", application);
            application.Activities.Add(activity2);

            var activity3 = new Activity("FakeActivity3", application);
            application.Activities.Add(activity3);

            // Act & Assert
            Assert.Throws<LeadPipeNetAccessDeniedException>(() => authorizer.Will.ThrowAccessDeniedException().When.User(user).Can.Not.ExecuteAnyOfTheseActivities(new[] { activity1, activity2, activity3 }).In(application));
        }

        /// <summary>
        /// Tests to ensure that the authorizer will throw an exception if the user is not authorized for two activities.
        /// </summary>
        [Test]
        public void ThrowExceptionGivenUserIsNotAuthorizedForTwoActivities()
        {
            // Arrange
            Bootstrapper.Start();

            var authorizer = Bootstrapper.Container.GetInstance<IAuthorizer>();

            var user = new User("testuser", "Test", "User") { IsActive = true };

            var application = new Application("FakeApplication");
            application.AddUser(user, null);

            var activity1 = new Activity("FakeActivity1", application);
            application.Activities.Add(activity1);

            var activity2 = new Activity("FakeActivity2", application);
            application.Activities.Add(activity2);

            // Act
            Assert.Throws<LeadPipeNetAccessDeniedException>(() => authorizer.Will.ThrowAccessDeniedException().When.User(user).Can.Not.ExecuteAnyOfTheseActivities(new[] { activity1, activity2 }).In(application));
        }
    }
}