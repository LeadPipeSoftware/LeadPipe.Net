// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommitShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Data.NHibernate.Tests.DataSessionProviderTests
{
	using DataSessionProvider = NHibernate.DataSessionProvider;

	/// <summary>
	/// The DataSessionProvider Create method tests.
	/// </summary>
	[TestFixture]
	public class CreateShould
	{
		#region Public Methods and Operators

		/// <summary>
		/// Tests that Create returns a valid session when there is a properly configured session factory.
		/// </summary>
		[Test]
		public void ReturnDataSessionGivenValidSessionFactoryConfiguration()
		{
			// Arrange
			var dataSessionProvider = new DataSessionProvider(new UnitTestSessionFactoryBuilder());

			// Act
			var dataSession = dataSessionProvider.Create();

			// Assert
			Assert.That(dataSession != null);
		}

		#endregion
	}
}