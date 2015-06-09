// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HasActiveDataSessionShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Data.NHibernate.Tests.ActiveDataSessionManager
{
	using ActiveDataSessionManager = LeadPipe.Net.Data.NHibernate.ActiveDataSessionManager;

	/// <summary>
	/// The ActiveDataSessionManager HasActiveDataSession property tests.
	/// </summary>
	[TestFixture]
	public class HasActiveDataSessionShould
	{
		#region Public Methods and Operators

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

		#endregion
	}
}