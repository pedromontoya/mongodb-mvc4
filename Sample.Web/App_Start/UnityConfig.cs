using Microsoft.Practices.Unity;
using Sample.Core.Implementation.MongoDb;
using Sample.Core.Implementation.Repositories;
using Sample.Core.Models;
using Sample.Core.MongoDb;
using Sample.Core.Repositories;
using System.Web.Http;
using System.Web.Mvc;

namespace Sample.Web.App_Start
{
    public static class UnityConfig
    {
        public static void Initialize(HttpConfiguration config)
        {
            //Get unity container instance with configured type mappings
            var container = GetConfiguredContainer();

            //Configure MVC dependency resolver
            var mvcDependencyResolver = new Unity.Mvc3.UnityDependencyResolver(container);
            DependencyResolver.SetResolver(mvcDependencyResolver);

            //Configure WebApi dependency resolver
            var apiDependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            config.DependencyResolver = apiDependencyResolver;
        }

        private static UnityContainer GetConfiguredContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IMongoDbContext, MongoContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IGenericMongoRepository<Note>, GenericMongoRepository<Note>>(new HierarchicalLifetimeManager(), 
                new InjectionConstructor(new ResolvedParameter<IMongoDbContext>()));

            return container;
        }
    }
}