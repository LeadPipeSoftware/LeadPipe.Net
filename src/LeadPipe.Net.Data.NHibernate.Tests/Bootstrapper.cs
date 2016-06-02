// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Data.NHibernate.StructureMap;
using StructureMap;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
    /// <summary>
    /// The bootstrapper.
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="Bootstrapper"/> class from being created.
        /// </summary>
        private Bootstrapper()
        {
        }

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static Container AmbientContainer { get; protected set; }

        /// <summary>
        /// The start.
        /// </summary>
        /// <returns>
        /// The started bootstrapper.
        /// </returns>
        public static Bootstrapper Start()
        {
            var bootstrapper = new Bootstrapper();

            AmbientContainer = new Container();

            LeadPipeNHibernateDataConfiguration.Initialize(AmbientContainer, typeof(UnitTestSessionFactoryBuilder));

            /*
             * It's only necessary to register repositories if you have custom implementations that
             * extend the base Repository class. If you do nothing, you'll simply get the generic
             * repository implementation.
             */

            LeadPipeNHibernateDataConfiguration.RegisterRepository<TestModel>(AmbientContainer, typeof(TestModelRepository));
            //LeadPipeNHibernateDataConfiguration.RegisterRepository<AggregateRootTestModel>(AmbientContainer, typeof (Repository<AggregateRootTestModel>));

            return bootstrapper;
        }
    }
}