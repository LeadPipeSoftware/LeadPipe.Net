// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LeadPipeNHibernateDataConfiguration.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using LeadPipe.Net.Domain;
using LeadPipe.Net.Extensions;
using StructureMap;

namespace LeadPipe.Net.Data.NHibernate.StructureMap
{
    /// <summary>
    /// The LeadPipe.Net NHibernate configuration.
    /// </summary>
    public class LeadPipeNHibernateDataConfiguration
    {
        #region Constructors and Destructors

        /// <summary>
        /// Prevents a default instance of the <see cref="LeadPipeNHibernateDataConfiguration"/> class from being created.
        /// </summary>
        private LeadPipeNHibernateDataConfiguration()
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Initializes the configuration.
        /// </summary>
        /// <param name="container">The StructureMap container.</param>
        /// <param name="sessionFactoryBuilder">The session factory builder type.</param>
        public static void Initialize(Container container, Type sessionFactoryBuilder)
        {
            container.Configure(c =>
            {
                c.For(typeof(ISessionFactoryBuilder)).Singleton().Use(sessionFactoryBuilder);
                c.For(typeof(IDataSessionProvider<>)).Use(typeof(DataSessionProvider));
                c.For(typeof(IActiveDataSessionManager<>)).Use(typeof(ActiveDataSessionManager));
                c.For<IDataCommandProvider>().Use<DataCommandProvider>();
                c.For(typeof(IObjectFinder<>)).Use(typeof(ObjectFinder<>));
                c.For<IUnitOfWorkFactory>().Singleton().Use<UnitOfWorkFactory>();
                c.For(typeof(IRepository<>)).Use(typeof(Repository<>));
            });
        }

        /// <summary>
        /// Adds a repository registration.
        /// </summary>
        /// <typeparam name="T">The repository type.</typeparam>
        /// <param name="container">The StructureMap container.</param>
        /// <param name="repositoryType">Type of the repository.</param>
        public static void RegisterRepository<T>(Container container, Type repositoryType) where T : class
        {
            Guard.Will.ThrowExceptionOfType<LeadPipeNetDataException>("The container has not been initialized. Did you call the LeadPipeNHibernateDataConfiguration.Initialize method first?").When(container.IsNull());

            container.Configure(c =>
            {
                c.For(typeof(IRepository<T>)).Use(repositoryType);
            });
        }

        #endregion
    }
}