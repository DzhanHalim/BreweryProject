using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        // runs when the app starts, register types IOC container
        protected override void Load(ContainerBuilder builder)
        {
            // register managers as services so we can use the services in the webAPI and be able to use manager methods
            // dependency injection for webAPI
            //Business
            builder.RegisterType<BeerManager>().As<IBeerService>().SingleInstance();
            builder.RegisterType<BreweryManager>().As<IBreweryService>().SingleInstance();
            builder.RegisterType<OrdersManager>().As<IOrdersService>().SingleInstance();
            builder.RegisterType<WholesalerManager>().As<IWholesalerService>().SingleInstance();
            builder.RegisterType<WholesalerManager>().As<IWholesalerService>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            //DataAccess
            builder.RegisterType<EfBeerDal>().As<IBeerDal>().SingleInstance();
            builder.RegisterType<EfBreweryDal>().As<IBreweryDal>().SingleInstance();
            builder.RegisterType<EfOrdersDal>().As<IOrdersDal>().SingleInstance();
            builder.RegisterType<EfWholesalerDal>().As<IWholesalerDal>().SingleInstance();
            builder.RegisterType<EfWholesalerStockDal>().As<IWholesalerStockDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
