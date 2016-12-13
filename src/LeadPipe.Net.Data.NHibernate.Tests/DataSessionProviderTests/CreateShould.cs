// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
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
    }
}