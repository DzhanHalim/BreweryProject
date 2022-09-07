using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             
            services.AddControllers();
            // addsingleton = even if we get thousands of requests, only creates one refferance in the memory and uses that one for everything
            // can only be used for classes that doesnt contain any data, but only logic
            // if someone uses Iproductservice, give him product manager
            // built in IoC container
            services.AddSingleton<IBeerService, BeerManager>();
            services.AddSingleton<IBeerDal, EfBeerDal>();
            services.AddSingleton<IWholesalerStockService, WholesalerStockManager>();
            services.AddSingleton<IWholesalerStockDal, EfWholesalerStockDal>();

            services.AddSingleton<IWholesalerService, WholesalerManager>();
            services.AddSingleton<IWholesalerDal, EfWholesalerDal>();
            services.AddSingleton<IBreweryService, BreweryManager>();
            services.AddSingleton<IBreweryDal, EfBreweryDal>();
            services.AddSingleton<IOrdersService, OrdersManager>();
            services.AddSingleton<IOrdersDal, EfOrdersDal>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
