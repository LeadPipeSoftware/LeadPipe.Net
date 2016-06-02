// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NHibernate.Linq;
using NUnit.Framework;
using System.Linq;

namespace LeadPipe.Net.Data.NHibernate.Tests.RepositoryTests
{
    /// <summary>
    /// The Repository All property tests.
    /// </summary>
    [TestFixture]
    public class AllShould
    {
        /// <summary>
        /// Tests that All property returns matching objects when using Fetch.
        /// </summary>
        [Test]
        public void ReturnAllMatchingObjectsGivenFetch()
        {
            // Arrange
            Bootstrapper.Start();
            const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var testChildA = new TestChildModel("AAA");
            var testChildB = new TestChildModel("BBB");
            var testChildC = new TestChildModel("CCC");

            var testModel = new TestModel(Key);

            testModel.TestChildren.Add(testChildA);
            testModel.TestChildren.Add(testChildB);
            testModel.TestChildren.Add(testChildC);

            // Act
            using (unitOfWork.Start())
            {
                repository.Create(testModel);

                unitOfWork.Commit();
            }

            // Assert
            using (unitOfWork.Start())
            {
                var foundModel = repository.Find.All.Fetch(x => x.TestChildren).ToList();

                Assert.That(foundModel.Count.Equals(1));
            }
        }
    }
}