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
using NHibernate;

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
        /// <param name="scoped">if set to <c>true</c> the registration will be scoped.</param>
        public static void Initialize(WindsorContainer container, Type sessionFactoryBuilder, bool scoped = false)
        {
            if (scoped)
            {
                container.Register(
                    Component.For(typeof (ISessionFactoryBuilder))
                        .ImplementedBy(sessionFactoryBuilder)
                        .LifestyleScoped());
                container.Register(
                    Component.For(typeof (IDataSessionProvider<ISession>))
                        .ImplementedBy(typeof (DataSessionProvider))
                        .LifestyleScoped());
                container.Register(
                    Component.For(typeof (IActiveDataSessionManager<ISession>))
                        .ImplementedBy(typeof (ActiveDataSessionManager))
                        .LifestyleScoped());
                container.Register(
                    Component.For(typeof (IDataCommandProvider))
                        .ImplementedBy(typeof (DataCommandProvider))
                        .LifestyleScoped());
                container.Register(
                    Component.For(typeof (IObjectFinder<>)).ImplementedBy(typeof (ObjectFinder<>)).LifestyleScoped());
                container.Register(
                    Component.For(typeof (IUnitOfWorkFactory))
                        .ImplementedBy(typeof (UnitOfWorkFactory))
                        .LifestyleSingleton());
                container.Register(
                    Component.For(typeof (IQueryRunner<>)).ImplementedBy(typeof (QueryRunner<>)).LifestyleScoped());
                container.Register(
                    Component.For(typeof (IRepository<>)).ImplementedBy(typeof (Repository<>)).LifestyleScoped());
            }
            else
            {
                container.Register(
                    Component.For(typeof(ISessionFactoryBuilder))
                        .ImplementedBy(sessionFactoryBuilder)
                        .LifestyleTransient());
                container.Register(
                    Component.For(typeof(IDataSessionProvider<ISession>))
                        .ImplementedBy(typeof(DataSessionProvider))
                        .LifestyleTransient());
                container.Register(
                    Component.For(typeof(IActiveDataSessionManager<ISession>))
                        .ImplementedBy(typeof(ActiveDataSessionManager))
                        .LifestyleTransient());
                container.Register(
                    Component.For(typeof(IDataCommandProvider))
                        .ImplementedBy(typeof(DataCommandProvider))
                        .LifestyleTransient());
                container.Register(
                    Component.For(typeof(IObjectFinder<>)).ImplementedBy(typeof(ObjectFinder<>)).LifestyleTransient());
                container.Register(
                    Component.For(typeof(IUnitOfWorkFactory))
                        .ImplementedBy(typeof(UnitOfWorkFactory))
                        .LifestyleSingleton());
                container.Register(
                    Component.For(typeof(IQueryRunner<>)).ImplementedBy(typeof(QueryRunner<>)).LifestyleTransient());
                container.Register(
                    Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());
            }
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

            container.Register(Component.For(typeof(IRepository<T>)).ImplementedBy(repositoryType).LifestyleScoped());
        }

        #endregion
    }
}