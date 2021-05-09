using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace LBSampleFramework.DependencyInjection
{
    public class Factory : IFactory
    {
        private IUnityContainer _container;
        public Factory(IUnityContainer container)
        {
            _container = container;
        }
        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            return _container.Resolve<TRepository>();
        }
        public TDomain GetDomain<TDomain>() where TDomain : class
        {
            return _container.Resolve<TDomain>();
        }
    }
}
