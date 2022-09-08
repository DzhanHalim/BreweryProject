using Autofac;
using Business.Abstract;
using Business.Concrete;
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

            //DataAccess
            builder.RegisterType<EfBeerDal>().As<IBeerDal>().SingleInstance();
            builder.RegisterType<EfBreweryDal>().As<IBreweryDal>().SingleInstance();
            builder.RegisterType<EfOrdersDal>().As<IOrdersDal>().SingleInstance();
            builder.RegisterType<EfWholesalerDal>().As<IWholesalerDal>().SingleInstance();
            builder.RegisterType<EfWholesalerStockDal>().As<IWholesalerStockDal>().SingleInstance();
        }
    }
}
