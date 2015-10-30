// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AsDynamicListShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using NUnit.Framework;

namespace LeadPipe.Net.Data.NHibernate.Tests.NHibernateExtensionsTests
{
    /// <summary>
    /// The AsDynamicList extension method tests.
    /// </summary>
    [TestFixture]
    public class AsDynamicListShould
    {
        [Test]
        public void ReturnResultsAsDynamicList()
        {
            // Arrange
            Bootstrapper.Start();

            var unitOfWorkFactory = Bootstrapper.AmbientContainer.GetInstance<IUnitOfWorkFactory>();

            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            var repository = Bootstrapper.AmbientContainer.GetInstance<Repository<TestModel>>();

            const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var testModel = new TestModel(Key);

            IList<dynamic> results;

            // Act
            using (unitOfWork.Start())
            {
                repository.Create(testModel);

                unitOfWork.Commit();

                results = unitOfWork.CurrentSession().CreateSQLQuery("SELECT Key FROM TestModel").AsDynamicList();
            }

            // Assert
            Assert.That(results[0].Key.Equals(Key));
        }
    }
}