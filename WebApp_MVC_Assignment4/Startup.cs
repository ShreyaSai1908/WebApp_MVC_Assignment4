using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp_MVC_Assignment4.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using WebApp_MVC_Assignment4.Models.Database;
using WebApp_MVC_Assignment4.Models.Repositorys;
using WebApp_MVC_Assignment4.Models.Services;

namespace WebApp_MVC_Assignment4
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
            services.AddDbContext<PeopleDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            /*People Service*/
            services.AddScoped<IPeopleService, PeopleService>(); //Container setting for IoC
            //services.AddScoped<IPeopleRepo, InMemoryPeopleRepo>(); //Container setting for IoC
            services.AddScoped<IPeopleRepo, DatabasePeopleRepo>(); //Container setting for IoC

            /*City Service*/
            services.AddScoped<ICityService, CityService>(); //Container setting for IoC
            //services.AddScoped<ICityRepo, InMemoryCityRepo>(); //Container setting for IoC
            services.AddScoped<ICityRepo, DatabaseCityRepo>(); //Container setting for IoC

            /*City Service*/
            services.AddScoped<ICountryService, CountryService>(); //Container setting for IoC
            //services.AddScoped<ICountryRepo, InMemoryCountryRepo>(); //Container setting for IoC
            services.AddScoped<ICountryRepo, DatabaseCountryRepo>(); //Container setting for IoC
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                /*endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");*/

                endpoints.MapControllerRoute(
                     name: "Route_1",
                     pattern: "{controller}/{action}/{id?}",
                     defaults: new { controller = "People", action = "Add_View_People" });
            });
        }
    }
}
