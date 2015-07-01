// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using NUnit.Framework;
using StructureMap;

namespace LeadPipe.Net.Data.NHibernate.Tests.RepositoryTests
{
	/// <summary>
	/// The Repository Create method tests.
	/// </summary>
	[TestFixture]
	public class CreateShould
	{
		#region Public Methods and Operators

		/// <summary>
		/// Tests that Create persists an object.
		/// </summary>
		[Test]
		public void PersistNewObject()
		{
			// Arrange
			Bootstrapper.Start();
			const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			var repository = ObjectFactory.GetInstance<Repository<TestModel>>();
			var unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();
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
				var foundModel = repository.Find.One(x => x.Key.Equals(Key));

				Assert.That(foundModel != null);
			}
		}

		/// <summary>
		/// Tests that Create persists an object with a lazy reference to another mapped object.
		/// </summary>
		[Test]
		public void PersistNewObjectWithLazyReference()
		{
			// Arrange
			Bootstrapper.Start();
			const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			var repository = ObjectFactory.GetInstance<Repository<TestModel>>();
			var unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();
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

				var foundModel = repository.Find.One(x => x.Key.Equals(Key));

				Assert.That(foundModel.TestChild == testChild);

				Debug.WriteLine(string.Format("D UnitTest in Local.Data exists: {0}", Local.Data["UnitTest"] == null));
			}
		}

		/// <summary>
		/// Tests that Create does persist an object if the unit of work is not committed.
		/// </summary>
		[Test]
		public void NotPersistGivenUnitOfWorkNotCommitted()
		{
			// Arrange
			Bootstrapper.Start();
			const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			var repository = ObjectFactory.GetInstance<Repository<TestModel>>();
			var unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();
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
				var foundModel = repository.Find.One(x => x.Key.Equals(Key));

				Assert.That(foundModel == null);
			}
		}

		/// <summary>
		/// Tests that Create does persist an object if the unit of work is rolled back.
		/// </summary>
		[Test]
		public void NotPersistGivenUnitOfWorkRolledBack()
		{
			// Arrange
			Bootstrapper.Start();
			const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			var repository = ObjectFactory.GetInstance<Repository<TestModel>>();
			var unitOfWorkFactory = ObjectFactory.GetInstance<IUnitOfWorkFactory>();
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
				var foundModel = repository.Find.One(x => x.Key.Equals(Key));

				Assert.That(foundModel == null);
			}
		}

		/// <summary>
		/// Tests that Create throws an exception if not in a Unit of Work.
		/// </summary>
		[Test]
		[ExpectedException(typeof(LeadPipeNetDataException), ExpectedMessage = "There is no NHibernate session. Did you start a Unit of Work?")]
		public void ThrowExceptionGivenNoUnitOfWork()
		{
			// Arrange
			Bootstrapper.Start();
			const string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			var repository = ObjectFactory.GetInstance<Repository<TestModel>>();

			var testModel = new TestModel(Key);

			// Assert
			repository.Create(testModel);
		}

		#endregion
	}
}