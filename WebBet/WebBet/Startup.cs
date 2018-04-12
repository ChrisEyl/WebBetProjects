using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebBet.Datas;

namespace WebBet
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvcCore();

            services.AddDbContext<WebBetDbContext>(dbContextOption =>
            {
                dbContextOption.UseSqlServer(ConfigurationManager.ConnectionStrings["WebBetConnection"].ConnectionString);
            });

            services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(int.Parse(ConfigurationManager.AppSettings ["SessionTimeOut"])));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        
            // charge la localisation
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(
                    culture: "fr-FR", 
                    uiCulture: "fr-FR")
            });

            // charge la page de test dans wwwRoot
            app.UseStaticFiles();

            // charge le module de gestion des sessions
            app.UseSession();

            // configuration des routes
            app.UseMvc(ConfigureRoute);

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
        
        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                name: "apropos",
                template: "a-propos-de",
                defaults:new { controller = "Home", action = "About"}
                );

            routeBuilder.MapRoute(
               name: "sinscrire",
               template: "inscription",
               defaults: new { controller = "Users", action = "Create" }
               );

            routeBuilder.MapRoute(
               name: "home",
               template: "",
               defaults: new { controller = "Home", action = "Index" }
               );

            routeBuilder.MapRoute(
                  name: "areas", // area 
                  template: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
                );

            // La route par default est obligatoire en MVC 6
            routeBuilder.MapRoute(
                name: "Default",
                template: "{controller=home}/{action=index}/{id?}"
                );
        }
    }
}
