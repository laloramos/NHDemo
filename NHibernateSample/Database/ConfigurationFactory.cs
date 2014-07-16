using System;
using System.Data;
using System.Linq;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernateSample.Domain.Entities;

namespace NHibernateSample.Database
{
    public class ConfigurationFactory
    {
        public Configuration CreateConfiguration()
        {
            var nhConfiguration = ConfigureNHibernate();
            var mappings = GenerateMappings();
            nhConfiguration.AddDeserializedMapping(mappings, "Demo");
            return nhConfiguration;
        }


        private HbmMapping GenerateMappings()
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetAssembly(typeof(Movie)).GetExportedTypes());
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            return mapping;
        }

        private Configuration ConfigureNHibernate()
        {
            var configure = new Configuration();
            configure.SessionFactoryName("Demo");

            configure.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2008Dialect>();
                db.Driver<SqlClientDriver>();
                db.IsolationLevel = IsolationLevel.Snapshot;
                if (System.Environment.GetEnvironmentVariable("db_connstring") != null)
                {
                    db.ConnectionString = System.Environment.GetEnvironmentVariable("db_connstring");
                }
                else
                {
                    db.ConnectionStringName = "DemoDB";
                }
                db.Timeout = 10;
                db.BatchSize = 100;
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.LogFormattedSql = true;
            });
           
            return configure;
        }
    }
}