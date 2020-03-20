using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.ProductCommands;
using EfCommands.ProductCommands;
using EfDataAccess;
using JsonCommands.ProductCommands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProductManagement
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
            services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            ////To change inmlementation comment/uncomment sql and json commands////

            //ProductSql
            services.AddTransient<IGetProductsCommand, EfGetProductsCommand>();
            services.AddTransient<IGetProductInsertData, EfGetProductInsertData>();
            services.AddTransient<ICreateProductCommand, EfCreateProductCommand>();
            services.AddTransient<IGetProductCommand, EfGetProductCommand>();
            services.AddTransient<IEditProductCommand, EfEditProductCommand>();
          
            //ProductJson
            /*
            services.AddTransient<IGetProductsCommand, JsonGetProductsCommand>();
            services.AddTransient<IGetProductInsertData, JsonGetProductInsertData>();
            services.AddTransient<ICreateProductCommand, JsonCreateProductCommand>();
            services.AddTransient<IGetProductCommand, JsonGetProductCommand>();
            services.AddTransient<IEditProductCommand, JsonEditProductCommand>();
            */

            services.AddControllersWithViews();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
