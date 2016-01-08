using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Concrete;
using HyrjChina.Web.Infrastructure.Abstract;
using HyrjChina.Web.Concrete;

namespace HyrjChina.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
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
            kernel.Bind<IProductRespository>().To<EFProductRepository>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}