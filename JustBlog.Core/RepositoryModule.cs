using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Web.Common;
using Ninject.Modules;
using NHibernate.Cache;
using NHibernate;
using JustBlog.Core.Object;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace JustBlog.Core
{
  public  class RepositoryModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ISessionFactory>().ToMethod(
                e=>Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c=>c.FromConnectionStringWithKey("JustBlogDbConnString")))
                .Cache(c=>c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
                .Mappings(m=>m.FluentMappings.AddFromAssemblyOf<Post>())
                .ExposeConfiguration(cfg=>new SchemaExport(cfg).Execute(true,true,false))
                .BuildConfiguration ()
                .BuildSessionFactory()
            ).InSingletonScope();

            Bind<ISession>().ToMethod(
               (ctx)=>ctx.Kernel.Get<ISessionFactory>().OpenSession() 

            ).InRequestScope();
        }

    }
}
