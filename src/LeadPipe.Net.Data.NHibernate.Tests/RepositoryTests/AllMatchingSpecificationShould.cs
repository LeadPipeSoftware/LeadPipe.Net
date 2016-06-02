// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System.Linq;

namespace LeadPipe.Net.Data.NHibernate.Tests.RepositoryTests
{
    /// <summary>
    /// The Repository AllMatchingSpecification method tests.
    /// </summary>
    [TestFixture]
    public class AllMatchingSpecificationShould
    {
        /// <summary>
        /// Tests that AllMatchingSpecification does not return objects that do not match.
        /// </summary>
        [Test]
        public void NotReturnNonMatchingObjects()
        {
            // Arrange
            Bootstrapper.Start();

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
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
                var foundModel = repository.Find.AllMatchingSpecification(TestModelSpecifications.TestPropertyStartsWithABC()).ToList();

                Assert.That(!foundModel.Contains(testModel02));
            }
        }

        /// <summary>
        /// Tests that AllMatchingSpecification returns all matching objects.
        /// </summary>
        [Test]
        public void ReturnAllMatchingObjects()
        {
            // Arrange
            Bootstrapper.Start();

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
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
                var foundModel = repository.Find.AllMatchingSpecification(TestModelSpecifications.TestPropertyStartsWithABC()).ToList();

                Assert.That(foundModel.Count.Equals(2));
            }
        }

        /// <summary>
        /// Tests that AllMatchingSpecification returns all matching objects given an AndSpecification.
        /// </summary>
        [Test]
        public void ReturnAllMatchingObjectsGivenAndSpecification()
        {
            // Arrange
            Bootstrapper.Start();

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var testModel01 = new TestModel("ABCDEF");
            var testModel02 = new TestModel("HIJKLM");
            var testModel03 = new TestModel("ABCXYZ");

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
                var foundModel = repository.Find.AllMatchingSpecification(TestModelSpecifications.TestPropertyStartsWithABCAndEndsWithXYZ()).ToList();

                Assert.That(foundModel.Count.Equals(1));
            }
        }

        /// <summary>
        /// Tests that AllMatchingSpecification returns all matching objects given a NotSpecification.
        /// </summary>
        [Test]
        public void ReturnAllMatchingObjectsGivenNotSpecification()
        {
            // Arrange
            Bootstrapper.Start();

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var testModel01 = new TestModel("ABCDEF");
            var testModel02 = new TestModel("HIJKLM");
            var testModel03 = new TestModel("ABCXYZ");

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
                var foundModel = repository.Find.AllMatchingSpecification(TestModelSpecifications.NotTestPropertyStartsWithABCOrEndsWithXYZ()).ToList();

                Assert.That(foundModel.Count.Equals(1));
            }
        }

        /// <summary>
        /// Tests that AllMatchingSpecification returns all matching objects given an OrSpecification.
        /// </summary>
        [Test]
        public void ReturnAllMatchingObjectsGivenOrSpecification()
        {
            // Arrange
            Bootstrapper.Start();

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var testModel01 = new TestModel("ABCDEF");
            var testModel02 = new TestModel("HIJKLM");
            var testModel03 = new TestModel("ABCXYZ");

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
                var foundModel = repository.Find.AllMatchingSpecification(TestModelSpecifications.TestPropertyStartsWithABCOrEndsWithXYZ()).ToList();

                Assert.That(foundModel.Count.Equals(2));
            }
        }

        /// <summary>
        /// Tests that AllMatchingSpecification returns an empty enumeration when no matching objects are found.
        /// </summary>
        [Test]
        public void ReturnsEmptyEnumerationGivenNoMatchingObjects()
        {
            // Arrange
            Bootstrapper.Start();

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var testModel01 = new TestModel("BLARG");
            var testModel02 = new TestModel("BENNY");
            var testModel03 = new TestModel("BOOFY");

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
                var foundModel = repository.Find.AllMatchingSpecification(TestModelSpecifications.TestPropertyStartsWithABC());

                Assert.That(!foundModel.Any());
            }
        }
    }
}