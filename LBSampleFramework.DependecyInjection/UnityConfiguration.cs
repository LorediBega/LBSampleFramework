using LBSampleFramework.Domain.Concrete;
using LBSampleFramework.Domain.Interface;
using System;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace LBSampleFramework.DependecyInjection
{
    public static class UnityConfiguration
    {
        public static HttpConfiguration AddDependencyConfigurations(this HttpConfiguration config)
        {
            //var container = new UnityContainer();
            //container.RegisterType<ITestDomain, TestDomain>(new HierarchicalLifetimeManager());
            //config.DependencyResolver = new UnityResolver(container);

            return config;
        }
    }
}
