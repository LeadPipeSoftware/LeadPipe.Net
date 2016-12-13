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
    /// The Unit of Work Commit method tests.
    /// </summary>
    [TestFixture]
    public class CommitShould
    {
        /// <summary>
        /// Tests that Commit increments and decrements the nest level appropriately.
        /// </summary>
        /// <param name="unitOfWorkBatchMode">The unit of work batch mode.</param>
        [TestCase(UnitOfWorkBatchMode.Singular)]
        [TestCase(UnitOfWorkBatchMode.Nested)]
        [Category("RequiresDatabase")]
        public void IncrementAndDecrementNestLevelWhenStartingMultipleUnitsOfWork(UnitOfWorkBatchMode unitOfWorkBatchMode)
        {
            // Arrange
            Bootstrapper.Start();

            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            unitOfWorkFactory.UnitOfWorkBatchMode = unitOfWorkBatchMode;

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

                unitOfWork.Commit();
            }
        }

        [Test]
        [Category("RequiresDatabase")]
        public void InvokeAfterCommitAction()
        {
            // Arrange
            Bootstrapper.Start();

            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();

            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var wasCalled = false;

            // Act
            using (unitOfWork.Start())
            {
                unitOfWork.InvokeAfterCommit = () => wasCalled = true;

                unitOfWork.Commit();
            }

            // Assert
            Assert.That(wasCalled.Equals(true));
        }

        [Test]
        [Category("RequiresDatabase")]
        public void InvokeBeforeCommitAction()
        {
            // Arrange
            Bootstrapper.Start();

            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();

            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var wasCalled = false;

            // Act
            using (unitOfWork.Start())
            {
                unitOfWork.InvokeBeforeCommit = () => wasCalled = true;

                unitOfWork.Commit();
            }

            // Assert
            Assert.That(wasCalled.Equals(true));
        }

        [Test]
        [Category("RequiresDatabase")]
        public void InvokeOnCommitExceptionAction()
        {
            // Arrange
            Bootstrapper.Start();

            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();

            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var castedUnitOfWork = unitOfWork as UnitOfWork;

            var wasCalled = false;

            // Act
            using (castedUnitOfWork.Start())
            {
                castedUnitOfWork.InvokeOnCommitException = () => wasCalled = true;

                castedUnitOfWork.CurrentSession.Close();

                try
                {
                    castedUnitOfWork.Commit();
                }
                catch (System.Exception ex)
                {
                    Assert.That(ex.IsNotNull());
                }
            }

            // Assert
            Assert.That(wasCalled.Equals(true));
        }

        [Test]
        [Category("RequiresDatabase")]
        public void InvokeOnRollbackAction()
        {
            // Arrange
            Bootstrapper.Start();

            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();

            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var wasCalled = false;

            // Act
            using (unitOfWork.Start())
            {
                unitOfWork.InvokeOnRollback = () => wasCalled = true;

                unitOfWork.Rollback();
            }

            // Assert
            Assert.That(wasCalled.Equals(true));
        }

        /// <summary>
        /// The child method.
        /// </summary>
        /// <param name="unitOfWorkBatchMode">The unit of work batch mode.</param>
        private void ChildMethod()
        {
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();

            // Assert
            using (unitOfWork.Start())
            {
                Guard.Will.ThrowException("The unit of work did not start!").When(unitOfWork.IsStarted.IsFalse());

                Guard.Will.ThrowException("Expected nest level 2 but was {0}".FormattedWith(unitOfWork.NestLevel)).When(!unitOfWork.NestLevel.Equals(2));

                var foundModel = repository.Find.All.Fetch(x => x.TestChildren).ToList();
            }
        }

        /// <summary>
        /// Parent test method.
        /// </summary>
        /// <param name="unitOfWorkBatchMode">The unit of work batch mode.</param>
        private void ParentMethod()
        {
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();

            // Assert
            using (unitOfWork.Start())
            {
                Guard.Will.ThrowException("The unit of work did not start!").When(unitOfWork.IsStarted.IsFalse());

                Guard.Will.ThrowException("Expected nest level 1 but was {0}".FormattedWith(unitOfWork.NestLevel)).When(!unitOfWork.NestLevel.Equals(1));

                var foundModel = repository.Find.All.Fetch(x => x.TestChildren).ToList();

                this.ChildMethod();
            }
        }
    }
}