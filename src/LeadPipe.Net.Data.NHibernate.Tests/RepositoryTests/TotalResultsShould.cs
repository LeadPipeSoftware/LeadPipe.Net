// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TotalResultsShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using NUnit.Framework;
using StructureMap;

namespace LeadPipe.Net.Data.NHibernate.Tests.RepositoryTests
{
	/// <summary>
	/// The Repository TotalResults property tests.
	/// </summary>
	[TestFixture]
	public class TotalResultsShould
	{
		#region Public Methods and Operators

		/// <summary>
		/// Tests that TotalResults is the same as the number of returned objects.
		/// </summary>
		[Test]
		[Ignore("The TotalResults property is not supported at this time.")]
		public void ReturnCountEqualToLastQueryResultCount()
		{
			// Arrange
			Bootstrapper.Start();

			var repository = ObjectFactory.GetInstance<Repository<TestModel>>();
			var unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();
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

				Assert.That(repository.Find.TotalResults.Equals(foundModel.Count));
			}
		}

		/// <summary>
		/// Tests that TotalResults returns zero if no objects matched.
		/// </summary>
		[Test]
		[Ignore("The TotalResults property is not supported at this time.")]
		public void ReturnTotalNumberOfObjectsGivenNoMatchingObjects()
		{
			// Arrange
			Bootstrapper.Start();

			var repository = ObjectFactory.GetInstance<Repository<TestModel>>();
			var unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();
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

				Assert.That(repository.Find.TotalResults.Equals(0));
			}
		}

		/// <summary>
		/// Tests that TotalResults is the same as the number of qualifying objects when skip and take are used.
		/// </summary>
		[Test]
		[Ignore("The TotalResults property is not supported at this time.")]
		public void ReturnCountOfAllObjectsGivenSkipAndTake()
		{
			// Arrange
			Bootstrapper.Start();

			var repository = ObjectFactory.GetInstance<Repository<TestModel>>();
			var unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();
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
				var foundModel = repository.Find.AllMatchingSpecification(TestModelSpecifications.TestPropertyStartsWithABC()).Skip(1).Take(1).ToList();

				Assert.That(repository.Find.TotalResults.Equals(2));
			}
		}

		#endregion
	}
}