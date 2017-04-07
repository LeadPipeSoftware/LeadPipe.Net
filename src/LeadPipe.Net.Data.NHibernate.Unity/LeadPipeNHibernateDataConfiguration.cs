// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using LeadPipe.Net.Extensions;
using Microsoft.Practices.Unity;
using System;
using System.CodeDom;
using LeadPipe.Net.Commands;

namespace LeadPipe.Net.Data.NHibernate.Unity
{
    /// <summary>
    /// The LeadPipe.Net NHibernate configuration.
    /// </summary>
    public class LeadPipeNHibernateDataConfiguration
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="LeadPipeNHibernateDataConfiguration"/> class from being created.
        /// </summary>
        private LeadPipeNHibernateDataConfiguration()
        {
        }

        /// <summary>
        /// Initializes the configuration.
        /// </summary>
        /// <param name="container">The Unity container.</param>
        /// <param name="sessionFactoryBuilder">The session factory builder type.</param>
        public static void Initialize(UnityContainer container, Type sessionFactoryBuilder)
        {
            container.RegisterType(typeof(IClock), typeof(Clock));
            container.RegisterType(typeof(ICommandMediator), typeof(CommandMediator), new ContainerControlledLifetimeManager());
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
    }
}