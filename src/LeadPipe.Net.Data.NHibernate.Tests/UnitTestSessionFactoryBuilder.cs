// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
    /// <summary>
    /// The unit test session factory builder.
    /// </summary>
    public class UnitTestSessionFactoryBuilder : ISessionFactoryBuilder
    {
        /// <summary>
        /// The NHibernate map document name.
        /// </summary>
        private const string MapDocumentName = "NHibernateMap";

        /// <summary>
        /// The session factory.
        /// </summary>
        private ISessionFactory sessionFactory;

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        public global::NHibernate.Cfg.Configuration Configuration { get; protected set; }

        /// <summary>
        /// Builds a configured session factory.
        /// </summary>
        /// <returns>
        /// The configured session factory.
        /// </returns>
        public ISessionFactory Build()
        {
            if (this.sessionFactory != null)
            {
                return this.sessionFactory;
            }

            this.Configuration = this.Configure();
            var mapping = this.Map();
            this.Configuration.AddDeserializedMapping(mapping, MapDocumentName);

            this.sessionFactory = this.Configuration.BuildSessionFactory();

            new SchemaExport(this.Configuration).Create(false, true);

            return this.sessionFactory;
        }

        /// <summary>
        /// Configures NHibernate.
        /// </summary>
        /// <returns>
        /// The NHibernate configuration.
        /// </returns>
        private global::NHibernate.Cfg.Configuration Configure()
        {
            var configuration = new global::NHibernate.Cfg.Configuration();

            configuration.DataBaseIntegration(
                db =>
                    {
                        db.Driver<SQLite20Driver>();
                        db.ConnectionString = "Data Source=:memory:;Version=3;New=True;Pooling=True;Max Pool Size=1";
                        db.Dialect<SQLiteDialect>();
                        db.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
                    });

            return configuration;
        }

        /// <summary>
        /// Gets the NHibernate mapping.
        /// </summary>
        /// <returns>
        /// The NHibernate mapping.
        /// </returns>
        private HbmMapping Map()
        {
            var mapper = new ModelMapper();

            mapper.AddMapping<TestModelMap>();
            mapper.AddMapping<TestChildMap>();
            mapper.AddMapping<AggregateRootTestModelMap>();

            var mapping = mapper.CompileMappingFor(new[] { typeof(TestModel), typeof(TestChildModel), typeof(AggregateRootTestModel) });

            return mapping;
        }
    }
}