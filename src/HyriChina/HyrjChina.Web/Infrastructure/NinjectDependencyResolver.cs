using HyrjChina.Domain.Abstract;
using HyrjChina.Domain.Concrete;
using HyrjChina.Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HyrjChina.Web.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
    
}
