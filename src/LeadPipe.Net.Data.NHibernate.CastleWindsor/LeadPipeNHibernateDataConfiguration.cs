// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LeadPipeNHibernateDataConfiguration.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using LeadPipe.Net.Domain;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.Data.NHibernate.CastleWindsor
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
        /// <param name="container">The Castle Windsor container.</param>
        /// <param name="sessionFactoryBuilder">The session factory builder type.</param>
        public static void Initialize(WindsorContainer container, Type sessionFactoryBuilder)
        {
            container.Register(Component.For(typeof(ISessionFactoryBuilder)).ImplementedBy(sessionFactoryBuilder));
            container.Register(Component.For(typeof(IDataSessionProvider<>)).ImplementedBy(typeof(DataSessionProvider)));
            container.Register(Component.For(typeof(IActiveDataSessionManager<>)).ImplementedBy(typeof(ActiveDataSessionManager)));
            container.Register(Component.For(typeof(IDataCommandProvider)).ImplementedBy(typeof(DataCommandProvider)));
            container.Register(Component.For(typeof(IObjectFinder<>)).ImplementedBy(typeof(ObjectFinder<>)));
            container.Register(Component.For(typeof(IUnitOfWorkFactory)).ImplementedBy(typeof(UnitOfWorkFactory)).LifestyleSingleton());
            container.Register(Component.For(typeof(IQueryRunner<>)).ImplementedBy(typeof(QueryRunner<>)));
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)));
        }

        /// <summary>
        /// Adds a repository registration.
        /// </summary>
        /// <typeparam name="T">The repository type.</typeparam>
        /// <param name="container">The Castle Windsor container.</param>
        /// <param name="repositoryType">Type of the repository.</param>
        public static void RegisterRepository<T>(WindsorContainer container, Type repositoryType) where T : class
        {
            Guard.Will.ThrowExceptionOfType<LeadPipeNetDataException>("The container has not been initialized. Did you call the LeadPipeNHibernateDataConfiguration.Initialize method first?").When(container.IsNull());

            container.Register(Component.For(typeof(IRepository<T>)).ImplementedBy(repositoryType));
        }

        #endregion
    }
}