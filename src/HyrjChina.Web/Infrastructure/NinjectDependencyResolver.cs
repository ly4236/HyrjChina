using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Concrete;
using HyrjChina.Web.Infrastructure.Abstract;
using HyrjChina.Web.Infrastructure.Concrete;

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
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<IUserRepository>().To<EFUserRepository>();
            kernel.Bind<ISessionContext>().To<SessionContext>();
            kernel.Bind<ICategoryRepository>().To<EFCategoryRepository>();
            kernel.Bind<IMenuItemRepository>().To<EFMenuItemRepository>();

            //kernel.Bind<IMenuItemRepository>().To<EFMenuItemRepository>();
            kernel.Bind<IUserAddressRepository>().To<EFUserAddressRepository>();

            kernel.Bind<IOrderRepository>().To<EFOrderRepository>();
            //kernel.Bind<IAddressRepository>().To<EFAddressRepository>();
            kernel.Bind<IAddressRepository>().To<EFAddressRepository>();
            kernel.Bind<IRegionRepository>().To<EFRegionRepository>();
            kernel.Bind<IOrderItemRepository>().To<EFOrderItemRepository>();

            //kernel.Bind<IMenuItemRepository>().To<EFMenuItemRepository>();
            //kernel.Bind<IMenuItemRepository>().To<EFMenuItemRepository>();
            //kernel.Bind<IMenuItemRepository>().To<EFMenuItemRepository>();
            //kernel.Bind<IMenuItemRepository>().To<EFMenuItemRepository>();
        }
    }
}