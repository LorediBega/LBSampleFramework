//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Web.Http.Dependencies;
//using Unity;

//namespace LBSampleFramework.DependecyInjection
//{
//    public class UnityResolver: IDependencyResolver
//    {
//        protected IUnityContainer container;

//        public UnityResolver(IUnityContainer container)
//        {
//            if(container == null)
//            {
//                throw new ArgumentNullException(nameof(container));
//            }

//            this.container = container;
//        }

//        public IDependencyScope BeginScope()
//        {
//            var child = container.CreateChildContainer();
//            return new UnityResolver(child);
//        }

//        public void Dispose()
//        {
//            container.Dispose();
//        }

//        public object GetService(Type serviceType)
//        {
//            try
//            {
//                return container.Resolve(serviceType);
//            }
//            catch (ResolutionFailedException exception)
//            {
//                throw new InvalidOperationException($"Unable to resolve service for type {serviceType}.", exception);
//            }
//        }

//        public IEnumerable<object> GetServices(Type serviceType)
//        {
//            try
//            {
//                return container.ResolveAll(serviceType);
//            }
//            catch (ResolutionFailedException exception)
//            {
//                throw new InvalidOperationException($"Unable to resolve service for type {serviceType}.", exception);
//            }
//        }
//    }
//}
