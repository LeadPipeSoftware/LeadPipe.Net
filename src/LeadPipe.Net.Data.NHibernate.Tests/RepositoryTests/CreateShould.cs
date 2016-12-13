// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System.Diagnostics;

namespace LeadPipe.Net.Data.NHibernate.Tests.RepositoryTests
{
    /// <summary>
    /// The Repository Create method tests.
    /// </summary>
    [TestFixture]
    public class CreateShould
    {
        /// <summary>
        /// Tests that All property returns matching objects when using Fetch.
        /// </summary>
        [Test]
        [Category("RequiresDatabase")]
        public void EnforceAggregateRootConstraintWhenUsingStrictMode()
        {
            // Arrange
            Bootstrapper.Start();
            const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123";

            var repository = Bootstrapper.AmbientContainer.GetInstance<StrictTestModelRepository>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var testModel = new TestModel(Key);

            // Act
            using (unitOfWork.Start())
            {
                Assert.Throws<LeadPipeNetDataException>(() => repository.Create(testModel));

                unitOfWork.Commit();
            }
        }

        /// <summary>
        /// Tests that All property returns matching objects when using Fetch.
        /// </summary>
        [Test]
        [Category("RequiresDatabase")]
        public void NotEnforceAggregateRootConstraintWhenUsingOpenMode()
        {
            // Arrange
            Bootstrapper.Start();
            const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123";

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var testModel = new TestModel(Key);

            // Act
            using (unitOfWork.Start())
            {
                repository.Create(testModel);

                unitOfWork.Commit();
            }
        }

        /// <summary>
        /// Tests that Create does persist an object if the unit of work is not committed.
        /// </summary>
        [Test]
        [Category("RequiresDatabase")]
        public void NotPersistGivenUnitOfWorkNotCommitted()
        {
            // Arrange
            Bootstrapper.Start();
            const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var testModel = new TestModel(Key);

            // Act
            using (unitOfWork.Start())
            {
                repository.Create(testModel);

                //// NOTE: We would normally commit here.
            }

            // Assert
            using (unitOfWork.Start())
            {
                var foundModel = repository.Find.OneMatchingExpression(x => x.Key.Equals(Key));

                Assert.That(foundModel == null);
            }
        }

        /// <summary>
        /// Tests that Create does persist an object if the unit of work is rolled back.
        /// </summary>
        [Test]
        [Category("RequiresDatabase")]
        public void NotPersistGivenUnitOfWorkRolledBack()
        {
            // Arrange
            Bootstrapper.Start();
            const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var testModel = new TestModel(Key);

            // Act
            using (unitOfWork.Start())
            {
                repository.Create(testModel);

                unitOfWork.Rollback();
            }

            // Assert
            using (unitOfWork.Start())
            {
                var foundModel = repository.Find.OneMatchingExpression(x => x.Key.Equals(Key));

                Assert.That(foundModel == null);
            }
        }

        [Test]
        [Category("RequiresDatabase")]
        public void NotThrowWhenAggregateRootConstraintIsMet()
        {
            // Arrange
            Bootstrapper.Start();
            const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123";

            var repository = Bootstrapper.AmbientContainer.GetInstance<StrictAggregateRootTestModelRepository>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var testModel = new AggregateRootTestModel(Key);

            // Act
            using (unitOfWork.Start())
            {
                repository.Create(testModel);

                unitOfWork.Commit();
            }
        }

        /// <summary>
        /// Tests that Create persists an object.
        /// </summary>
        [Test]
        [Category("RequiresDatabase")]
        public void PersistNewObject()
        {
            // Arrange
            Bootstrapper.Start();
            const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var testModel = new TestModel(Key);

            // Act
            using (unitOfWork.Start())
            {
                repository.Create(testModel);

                unitOfWork.Commit();
            }

            // Assert
            using (unitOfWork.Start())
            {
                var foundModel = repository.Find.OneMatchingExpression(x => x.Key.Equals(Key));

                Assert.That(foundModel != null);
            }
        }

        /// <summary>
        /// Tests that Create persists an object with a lazy reference to another mapped object.
        /// </summary>
        [Test]
        [Category("RequiresDatabase")]
        public void PersistNewObjectWithLazyReference()
        {
            // Arrange
            Bootstrapper.Start();
            const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var testChild = new TestChildModel("FOO");
            var testModel = new TestModel(Key) { TestChild = testChild };

            // Act
            using (unitOfWork.Start())
            {
                Debug.WriteLine(string.Format("A UnitTest in Local.Data exists: {0}", Local.Data["UnitTest"] == null));

                repository.Create(testModel);

                unitOfWork.Commit();

                Debug.WriteLine(string.Format("B UnitTest in Local.Data exists: {0}", Local.Data["UnitTest"] == null));
            }

            // Assert
            using (unitOfWork.Start())
            {
                Debug.WriteLine(string.Format("C UnitTest in Local.Data exists: {0}", Local.Data["UnitTest"] == null));

                var foundModel = repository.Find.OneMatchingExpression(x => x.Key.Equals(Key));

                Assert.That(foundModel.TestChild == testChild);

                Debug.WriteLine(string.Format("D UnitTest in Local.Data exists: {0}", Local.Data["UnitTest"] == null));
            }
        }

        /// <summary>
        /// Tests that Create throws an exception if not in a Unit of Work.
        /// </summary>
        [Test]
        [Category("RequiresDatabase")]
        public void ThrowExceptionGivenNoUnitOfWork()
        {
            // Arrange
            Bootstrapper.Start();
            const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();

            var testModel = new TestModel(Key);

            // Assert
            Assert.Throws<LeadPipeNetDataException>(() => repository.Create(testModel));
        }
    }
}