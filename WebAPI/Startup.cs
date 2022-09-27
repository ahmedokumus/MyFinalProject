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
        // Bu yöntem çalýþma zamaný tarafýndan çaðrýlýr. Kapsayýcýya hizmet eklemek için bu yöntemi kullanýn.
        public void ConfigureServices(IServiceCollection services)
        {
            //Autofac, Ninject, CastleWindsor, StructureMap, L,ghtInject, DryInject Mimarileri --> IoC Container.
            //AOP.
            //Autofac bize AOP imkaný sunuyor.
            //Postsharp --> Autofac'in daha geliþmiþ hali
            services.AddControllers();
            //Arkaplanda new'leyrek bize verir (Instance üretmek) !!Alttaki 2 satýr!!
            //services.AddSingleton<IProductService, ProductManager>(); //Eðer sen bir baðýmlýlýk(IProductService) görürsen onun karþýlýðý budur(ProductManager)
            //services.AddSingleton<IProductDal, EfProductDal>(); //Eðer biri senden IProductDal'ý isterse ona EfProductDal'ý ver
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Bu yöntem çalýþma zamaný tarafýndan çaðrýlýr.HTTP istek ardýþýk düzenini yapýlandýrmak için bu yöntemi kullanýn.
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
