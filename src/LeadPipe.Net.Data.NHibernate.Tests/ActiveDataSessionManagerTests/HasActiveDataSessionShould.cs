// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Data.NHibernate.Tests.ActiveDataSessionManagerTests
{
    using ActiveDataSessionManager = NHibernate.ActiveDataSessionManager;

    /// <summary>
    /// The ActiveDataSessionManager HasActiveDataSession property tests.
    /// </summary>
    [TestFixture]
    public class HasActiveDataSessionShould
    {
        /// <summary>
        /// Tests that ActiveDataSessionManager returns true when an active session is cleared.
        /// </summary>
        [Test]
        public void ReturnFalseGivenActiveDataSessionCleared()
        {
            // Arrange
            var activeSessionManager = new ActiveDataSessionManager();
            var unitTestSessionFactoryBuilder = new UnitTestSessionFactoryBuilder();
            var sessionFactory = unitTestSessionFactoryBuilder.Build();
            var session = sessionFactory.OpenSession();
            activeSessionManager.SetActiveDataSession(session);

            // Act
            activeSessionManager.ClearActiveDataSession();

            // Assert
            Assert.That(activeSessionManager.HasActiveDataSession == false);
        }

        /// <summary>
        /// Tests that ActiveDataSessionManager returns false when there is no active session.
        /// </summary>
        [Test]
        public void ReturnFalseGivenNoActiveDataSession()
        {
            // Arrange
            var activeDataSessionManager = new ActiveDataSessionManager();

            // Act

            // Assert
            Assert.That(activeDataSessionManager.HasActiveDataSession == false);

            activeDataSessionManager.ClearActiveDataSession();
        }

        /// <summary>
        /// Tests that ActiveDataSessionManager returns true when there is an active session.
        /// </summary>
        [Test]
        public void ReturnTrueGivenActiveDataSession()
        {
            // Arrange
            var activeSessionManager = new ActiveDataSessionManager();
            var unitTestSessionFactoryBuilder = new UnitTestSessionFactoryBuilder();
            var sessionFactory = unitTestSessionFactoryBuilder.Build();
            var session = sessionFactory.OpenSession();

            // Act
            activeSessionManager.SetActiveDataSession(session);

            // Assert
            Assert.That(activeSessionManager.HasActiveDataSession);

            activeSessionManager.ClearActiveDataSession();
        }
    }
}