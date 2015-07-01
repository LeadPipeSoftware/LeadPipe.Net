// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using NUnit.Framework;
using StructureMap;

namespace LeadPipe.Net.Data.NHibernate.Tests.RepositoryTests
{
	/// <summary>
	/// The Repository Update method tests.
	/// </summary>
	[TestFixture]
	public class UpdateShould
	{
		#region Public Methods and Operators

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

			var repository = ObjectFactory.GetInstance<Repository<TestModel>>();
			var unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();
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

		#endregion
	}
}