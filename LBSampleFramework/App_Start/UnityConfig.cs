using System.Web.Http;
using Unity;
using Unity.WebApi;
using LBSampleFramework.DependencyInjection;
using LBSampleFramework.Repository.Concrete;
using LBSampleFramework.Repository.Interface;
using LBSampleFramework.Domain.Concrete;
using LBSampleFramework.Domain.Interface;

namespace LBSampleFramework
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IFactory, Factory>();
            container.AddRepositoryRegistry();
            container.AddDomainRegistry();
            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public static void AddRepositoryRegistry(this UnityContainer container)
        {
            container.RegisterType<ITestRepository, TestRepository>();
        }

        public static void AddDomainRegistry(this UnityContainer container)
        {
            container.RegisterType<ITestDomain, TestDomain>();
        }
    }
}