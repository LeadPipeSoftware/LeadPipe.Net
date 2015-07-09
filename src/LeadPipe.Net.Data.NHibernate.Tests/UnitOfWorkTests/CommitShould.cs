// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommitShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using LeadPipe.Net.Extensions;
using NHibernate.Linq;
using NUnit.Framework;
using StructureMap;

namespace LeadPipe.Net.Data.NHibernate.Tests.UnitOfWorkTests
{
	/// <summary>
	/// The Unit of Work Commit method tests.
	/// </summary>
	[TestFixture]
	public class CommitShould
	{
		#region Public Methods and Operators

        /// <summary>
        /// Tests that Commit increments and decrements the nest level appropriately.
        /// </summary>
        /// <param name="unitOfWorkBatchMode">The unit of work batch mode.</param>
        [TestCase(UnitOfWorkBatchMode.Singular)]
        [TestCase(UnitOfWorkBatchMode.Nested)]
        public void IncrementAndDecrementNestLevelWhenStartingMultipleUnitsOfWork(UnitOfWorkBatchMode unitOfWorkBatchMode)
        {
            // Arrange
            Bootstrapper.Start();

            var unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork(unitOfWorkBatchMode);
            var repository = ObjectFactory.GetInstance<Repository<TestModel>>();

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

		#endregion

        #region Private Methods

        /// <summary>
        /// Parent test method.
        /// </summary>
        /// <param name="unitOfWorkBatchMode">The unit of work batch mode.</param>
        private void ParentMethod()
	    {
            var unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var repository = ObjectFactory.GetInstance<Repository<TestModel>>();

            // Assert
            using (unitOfWork.Start())
            {
                Guard.Will.ThrowException("The unit of work did not start!").When(unitOfWork.IsStarted.IsFalse());

                Guard.Will.ThrowException("Expected nest level 1 but was {0}".FormattedWith(unitOfWork.NestLevel)).When(!unitOfWork.NestLevel.Equals(1));

                var foundModel = repository.Find.All.Fetch(x => x.TestChildren).ToList();

                this.ChildMethod();
            }
	    }

        /// <summary>
        /// The child method.
        /// </summary>
        /// <param name="unitOfWorkBatchMode">The unit of work batch mode.</param>
        private void ChildMethod()
        {
            var unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            var repository = ObjectFactory.GetInstance<Repository<TestModel>>();

            // Assert
            using (unitOfWork.Start())
            {
                Guard.Will.ThrowException("The unit of work did not start!").When(unitOfWork.IsStarted.IsFalse());

                Guard.Will.ThrowException("Expected nest level 2 but was {0}".FormattedWith(unitOfWork.NestLevel)).When(!unitOfWork.NestLevel.Equals(2));

                var foundModel = repository.Find.All.Fetch(x => x.TestChildren).ToList();
            }
        }

        #endregion
    }
}