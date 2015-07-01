// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetQueryResultShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using LeadPipe.Net.Domain;
using NUnit.Framework;
using StructureMap;

namespace LeadPipe.Net.Data.NHibernate.Tests.QueryRunnerTests
{
	/// <summary>
	/// The QueryRunner GetQueryResult tests.
	/// </summary>
	[TestFixture]
	public class GetQueryResultShould
	{
		#region Public Methods and Operators

		/// <summary>
		/// Tests that all matching objects are returned.
		/// </summary>
		[Test]
		public void ReturnAllMatchingObjects()
		{
			// Arrange
			Bootstrapper.Start();

		    var queryRunner = ObjectFactory.GetInstance<IQueryRunner<IEnumerable<TestModel>>>();
            var repository = ObjectFactory.GetInstance<Repository<TestModel>>();
            var unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();
		    var dataCommandProvider = ObjectFactory.GetInstance<IDataCommandProvider>();
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
				var foundModel = queryRunner.GetQueryResult(new TestModelsWithTestPropertiesThatStartWithABC(dataCommandProvider));

				Assert.That(foundModel.Count().Equals(2));
			}
		}

		#endregion
	}
}