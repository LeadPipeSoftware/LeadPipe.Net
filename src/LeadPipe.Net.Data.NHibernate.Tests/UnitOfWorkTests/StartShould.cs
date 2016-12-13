// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using NHibernate.Linq;
using NUnit.Framework;
using System.Linq;

namespace LeadPipe.Net.Data.NHibernate.Tests.UnitOfWorkTests
{
    /// <summary>
    /// The Unit of Work Start method tests.
    /// </summary>
    [TestFixture]
    public class StartShould
    {
        /// <summary>
        /// Tests that Start starts a Unit of Work.
        /// </summary>
        [Test]
        [Category("RequiresDatabase")]
        public void CreateUnitOfWork()
        {
            // Arrange
            Bootstrapper.Start();

            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            // Assert
            using (unitOfWork.Start())
            {
                Assert.That(unitOfWork.IsStarted.IsTrue());
            }
        }

        /// <summary>
        /// Tests that Start decrements the nest level when disposing a nested units of work when nesting is enabled.
        /// </summary>
        [Test]
        [Category("RequiresDatabase")]
        public void DecrementNestLevelWhenDisposingNestedUnitOfWorkGivenNestingEnabled()
        {
            // Arrange
            Bootstrapper.Start();

            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            // Assert
            using (unitOfWork.Start())
            {
                using (unitOfWork.Start())
                {
                    Assert.That(unitOfWork.NestLevel.Equals(1));
                }

                Assert.That(unitOfWork.NestLevel.Equals(0));
            }
        }

        /// <summary>
        /// Tests that Start increments and decrements the nest level when starting multiple units of work across methods when nesting is enabled.
        /// </summary>
        [Test]
        [Category("RequiresDatabase")]
        public void IncrementAndDecrementNestLevelWhenStartingMultipleUnitsOfWorkAcrossMethodsGivenNestingEnabled()
        {
            // Arrange
            Bootstrapper.Start();

            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();

            const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var testChildA = new TestChildModel("AAA");
            var testChildB = new TestChildModel("BBB");
            var testChildC = new TestChildModel("CCC");

            var testModel = new TestModel(Key);

            testModel.TestChildren.Add(testChildA);
            testModel.TestChildren.Add(testChildB);
            testModel.TestChildren.Add(testChildC);

            using (unitOfWork.Start())
            {
                repository.Create(testModel);

                unitOfWork.Commit();
            }

            // Act & Assert
            using (unitOfWork.Start())
            {
                Assert.That(unitOfWork.NestLevel.Equals(0));

                this.ParentMethod();

                Assert.That(unitOfWork.NestLevel.Equals(0));
            }
        }

        /// <summary>
        /// Tests that Start increments the nest level when starting multiple units of work when nesting is enabled.
        /// </summary>
        [Test]
        [Category("RequiresDatabase")]
        public void IncrementNestLevelWhenStartingMultipleUnitsOfWorkGivenNestingEnabled()
        {
            // Arrange
            Bootstrapper.Start();

            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            // Assert
            using (unitOfWork.Start())
            {
                unitOfWork.Start();

                Assert.That(unitOfWork.NestLevel.Equals(1));
            }
        }

        /// <summary>
        /// The child method.
        /// </summary>
        private void ChildMethod()
        {
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();

            // Assert
            using (unitOfWork.Start())
            {
                Guard.Will.ThrowException("Expected nest level 2 but was {0}".FormattedWith(unitOfWork.NestLevel)).When(!unitOfWork.NestLevel.Equals(2));

                var foundModel = repository.Find.All.Fetch(x => x.TestChildren).ToList();
            }
        }

        /// <summary>
        /// Parent test method.
        /// </summary>
        private void ParentMethod()
        {
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();

            // Assert
            using (unitOfWork.Start())
            {
                Guard.Will.ThrowException("Expected nest level 1 but was {0}".FormattedWith(unitOfWork.NestLevel)).When(!unitOfWork.NestLevel.Equals(1));

                var foundModel = repository.Find.All.Fetch(x => x.TestChildren).ToList();

                this.ChildMethod();
            }
        }
    }
}