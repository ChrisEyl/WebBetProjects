using static WebBetHome.Constants.ConfigurationConstants;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using WebBetHome.Routes;

namespace WebBetHome
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvcCore();

            services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(int.Parse(ConfigurationManager.AppSettings[SESSION_TIMEOUT])));
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
            // gardé à titre d'exemple pour charge une page static exempe : page 404 personnalisée
            app.UseStaticFiles();

            // charge le module de gestion des sessions
            app.UseSession();

            app.UseMvc(RouteConfiguration.ConfigureRoute);

            // Ce code par defaut injecte le texte Hello Word dans le DOM
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
