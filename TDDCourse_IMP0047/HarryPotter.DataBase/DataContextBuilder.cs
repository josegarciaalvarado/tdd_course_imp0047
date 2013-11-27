using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImproveIT.Data;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Configuration;
using HarryPotter.DataBase;

namespace HarryPotter.Database
{
    public static class DataContextBuilder
    {
        public static IDataContext BuildDataContext()
        {
            return new ImproveIT.Data.Hibernate.HibernateDataContext(BuildSession());
        }

        public static NHibernate.ISession BuildSession()
        {
            string cnn = ConfigurationManager.ConnectionStrings["storedb_development"].ConnectionString;
            ISessionFactory factory = Fluently.Configure()
                .Database(
                MsSqlConfiguration.MsSql2008.ConnectionString(cnn)
                )
                .Cache(c => c.ProviderClass<NHibernate.Cache.NoCacheProvider>().UseQueryCache())
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<AuthorsMapper>();
                })
                .BuildSessionFactory();
            NHibernate.ISession session = factory.OpenSession();
            return session;
        }
    }
}