// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System.Collections.Generic;

namespace LeadPipe.Net.Data.NHibernate.Tests.RepositoryTests
{
    /// <summary>
    /// The Repository Update method tests.
    /// </summary>
    [TestFixture]
    public class UpdateShould
    {
        /// <summary>
        /// Tests that Update updates a list of existing objects.
        /// </summary>
        [Test]
        public void UpdateAListOfExistingObjects()
        {
            // Arrange
            Bootstrapper.Start();
            const string KeyA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string KeyB = "ZKJWDFLKJLSKDJFLKJLSKJSLDK";

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var modelList = new List<TestModel>();

            using (unitOfWork.Start())
            {
                modelList.Add(new TestModel(KeyA) { MutableTestProperty = "FOO" });
                modelList.Add(new TestModel(KeyB) { MutableTestProperty = "FOO" });

                repository.Create(modelList);

                unitOfWork.Commit();
            }

            // Act
            using (unitOfWork.Start())
            {
                foreach (TestModel testModel in modelList)
                {
                    testModel.MutableTestProperty = "BAR";
                }

                repository.Update(modelList);

                unitOfWork.Commit();
            }
        }
    }
}