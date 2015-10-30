using System.Collections.Generic;
using EbayModule.eBaySvc;
using EbayModule.enums;
using MonlithDS.DAL;
using MonlithDS.DAL.Models;
using MonlithDS.DAL.Repositories.Ebay;
using MonolithDS.Domain;
using MonolithDS.Domain.Abstract;
using MonolithDS.Domain.Ebay;
using MonolithDS.Domain.Entities;
using Moq;
using EbayModule = MonolithDS.DependancyResolution.EbayModule;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MonolithDS.WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MonolithDS.WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace MonolithDS.WebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {   
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static IKernel kernel;

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            kernel = new StandardKernel(
                new DependancyResolution.EbayModule());
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var mockProducts = new Mock<IProductRepository>();
            mockProducts.Setup(m => m.Products).Returns(new List<Product>()
            {
                new Product() { Asin = "B00K3EYT4Q", Brand = "Hasbro", Description = "This is the bomb"},
                new Product() { Asin = "B00POZJ4U8", Brand = "Hasbro", Description = "This is the bomb 2"}
            });
            kernel.Bind<IProductRepository>().ToConstant(mockProducts.Object);
            //kernel.Bind<IEbayBaseRepository>().To<EbayBaseRepository>()
                //.WithConstructorArgument("mode", Modes.Live)
                //.WithConstructorArgument("siteCode", SiteCodeType.UK);
            kernel.Bind<IUnitOfWork>().To<DSEntities>();
            //kernel.Bind<IEbayManagementRepository>().To<EbayManagementRepositroy>();
        }        
    }
}
