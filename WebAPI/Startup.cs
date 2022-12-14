using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

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
        // Bu y?ntem ?al??ma zaman? taraf?ndan ?a?r?l?r. Kapsay?c?ya hizmet eklemek i?in bu y?ntemi kullan?n.
        public void ConfigureServices(IServiceCollection services)
        {
            //Autofac, Ninject, CastleWindsor, StructureMap, L,ghtInject, DryInject Mimarileri --> IoC Container.
            //AOP.
            //Autofac bize AOP imkan? sunuyor.
            //Postsharp --> Autofac'in daha geli?mi? hali
            services.AddControllers();
            //Arkaplanda new'leyrek bize verir (Instance ?retmek) !!Alttaki 2 sat?r!!
            //services.AddSingleton<IProductService, ProductManager>(); //E?er sen bir ba??ml?l?k(IProductService) g?r?rsen onun kar??l??? budur(ProductManager)
            //services.AddSingleton<IProductDal, EfProductDal>(); //E?er biri senden IProductDal'? isterse ona EfProductDal'? ver
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Bu y?ntem ?al??ma zaman? taraf?ndan ?a?r?l?r.HTTP istek ard???k d?zenini yap?land?rmak i?in bu y?ntemi kullan?n.
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
