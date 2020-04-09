using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MvcCursus.Models;
using Microsoft.EntityFrameworkCore;

using MvcCursus.MiddleWare;
using Microsoft.AspNetCore.Server.IISIntegration;

namespace MvcCursus
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
            services.AddControllersWithViews();

            // Dependency Injection DI configuratie van de DB
            //services.AddDbContext<MyDbContext>(options => options.UseSqlite("Data Source=cursus.db"));
            services.AddDbContext<MyDbContext>(options =>
                        options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("cursusdb")));
            // De method UseLazyLoading() zit in de NuGet package Microsoft.EntityFrameworkCore.Proxies


            services.AddAuthentication(IISDefaults.AuthenticationScheme);
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

            // Deze aanroep forceert de gebruiker naar de https variant toe
            app.UseHttpsRedirection();

            // Deze aanroep zorgt er voor dat bestanden in wwwroot gevonden kunnen worden
            // Doe je deze aanroep niet dan werkt heel veel wel, maar de CSS kan niet worden gevonden
            app.UseStaticFiles();

            // Nu moeten we ook een aanroep om bestanden uit node_modules te kunnen leveren
            // Dit wordt een extension method
            app.UseNodeModules(env.ContentRootPath);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Hier wordt de ASP.NET Routing geregeld:
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
