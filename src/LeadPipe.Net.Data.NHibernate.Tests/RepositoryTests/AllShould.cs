// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AllShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using NHibernate.Linq;
using NUnit.Framework;
using StructureMap;

namespace LeadPipe.Net.Data.NHibernate.Tests.RepositoryTests
{
	/// <summary>
	/// The Repository All property tests.
	/// </summary>
	[TestFixture]
	public class AllShould
	{
		#region Public Methods and Operators

		/// <summary>
		/// Tests that All property returns matching objects when using Fetch.
		/// </summary>
		[Test]
		public void ReturnAllMatchingObjectsGivenFetch()
		{
			// Arrange
			Bootstrapper.Start();
			const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			var repository = ObjectFactory.GetInstance<Repository<TestModel>>();
			var unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();
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

		#endregion
	}
}