// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using StructureMap;
using StructureMap.Pipeline;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
	/// <summary>
	/// The bootstrapper.
	/// </summary>
	public class Bootstrapper
	{
		#region Constructors and Destructors

		/// <summary>
		/// Prevents a default instance of the <see cref="Bootstrapper"/> class from being created.
		/// </summary>
		private Bootstrapper()
		{
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// The start.
		/// </summary>
		/// <returns>
		/// The started bootstrapper.
		/// </returns>
		public static Bootstrapper Start()
		{
			var bootstrapper = new Bootstrapper();

			ObjectFactory.Initialize(
				x =>
				{
					x.For<ISessionFactoryBuilder>().Singleton().Use<UnitTestSessionFactoryBuilder>();
					x.For(typeof(IDataSessionProvider<>)).Use(typeof(NHibernate.DataSessionProvider));
					x.For(typeof(IActiveDataSessionManager<>)).Use(typeof(NHibernate.ActiveDataSessionManager));
					x.For<IDataCommandProvider>().Use<DataCommandProvider>();
					x.For(typeof(IObjectFinder<>)).Use(typeof(ObjectFinder<>));
					x.For<IUnitOfWorkFactory>().Singleton().Use<UnitOfWorkFactory>();
                    x.For(typeof(IQueryRunner<>)).Use(typeof(QueryRunner<>));
				});

			return bootstrapper;
		}

		#endregion
	}
}