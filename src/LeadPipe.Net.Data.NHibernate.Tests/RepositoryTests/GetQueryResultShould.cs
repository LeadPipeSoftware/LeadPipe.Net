// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System.Linq;

namespace LeadPipe.Net.Data.NHibernate.Tests.RepositoryTests
{
    /// <summary>
    /// The QueryRunner GetQueryResult tests.
    /// </summary>
    [TestFixture]
    public class GetQueryResultShould
    {
        /// <summary>
        /// Tests that all matching objects are returned.
        /// </summary>
        [Test]
        [Category("RequiresDatabase")]
        public void ReturnAllMatchingObjects()
        {
            // Arrange
            Bootstrapper.Start();

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var query = Bootstrapper.AmbientContainer.GetInstance<TestModelsWithTestPropertiesThatStartWithABC>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var testModel01 = new TestModel("ABCDEF");
            var testModel02 = new TestModel("HIJKLM");
            var testModel03 = new TestModel("ABCZZZ");

            // Act
            using (unitOfWork.Start())
            {
                repository.Create(testModel01);
                repository.Create(testModel02);
                repository.Create(testModel03);

                unitOfWork.Commit();
            }

            // Assert
            using (unitOfWork.Start())
            {
                var foundModel = repository.Find.AllMatchingQuery(query);

                Assert.That(foundModel.Count().Equals(2));
            }
        }
    }
}