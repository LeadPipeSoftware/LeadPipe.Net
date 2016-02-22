// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LeadPipeNHibernateDataConfiguration.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using LeadPipe.Net.Domain;
using LeadPipe.Net.Extensions;
using Microsoft.Practices.Unity;

namespace LeadPipe.Net.Data.NHibernate.Unity
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
        /// <param name="container">The Unity container.</param>
        /// <param name="sessionFactoryBuilder">The session factory builder type.</param>
        public static void Initialize(UnityContainer container, Type sessionFactoryBuilder)
        {
            container.RegisterType(typeof(ISessionFactoryBuilder), sessionFactoryBuilder, new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IDataSessionProvider<>), typeof(DataSessionProvider));
            container.RegisterType(typeof(IActiveDataSessionManager<>), typeof(ActiveDataSessionManager));
            container.RegisterType<IDataCommandProvider, DataCommandProvider>();
            container.RegisterType(typeof(IObjectFinder<>), typeof(ObjectFinder<>));
            container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactory>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
        }

        /// <summary>
        /// Adds a repository registration.
        /// </summary>
        /// <typeparam name="T">The repository type.</typeparam>
        /// <param name="container">The Unity container.</param>
        /// <param name="repositoryType">Type of the repository.</param>
        public static void RegisterRepository<T>(UnityContainer container, Type repositoryType) where T : class
        {
            Guard.Will.ThrowExceptionOfType<LeadPipeNetDataException>("The container has not been initialized. Did you call the LeadPipeNHibernateDataConfiguration.Initialize method first?").When(container.IsNull());

            container.RegisterType(typeof(IRepository<T>), repositoryType);
        }

        #endregion
    }
}