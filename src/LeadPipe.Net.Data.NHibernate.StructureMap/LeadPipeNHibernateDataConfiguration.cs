// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using LeadPipe.Net.Extensions;
using StructureMap;
using System;
using LeadPipe.Net.Commands;

namespace LeadPipe.Net.Data.NHibernate.StructureMap
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
        /// <param name="container">The StructureMap container.</param>
        /// <param name="sessionFactoryBuilder">The session factory builder type.</param>
        public static void Initialize(Container container, Type sessionFactoryBuilder)
        {
            container.Configure(c =>
            {
                c.For(typeof(IClock)).Use(typeof(Clock));
                c.For(typeof(ICommandMediator)).Singleton().Use(typeof(CommandMediator));
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
                c.For(typeof(Repository<T>)).Use(repositoryType);
            });
        }
    }
}