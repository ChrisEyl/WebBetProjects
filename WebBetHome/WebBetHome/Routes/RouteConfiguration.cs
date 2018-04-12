using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBetHome.Routes
{
    public class RouteConfiguration
    {
        internal static void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
              name: "apropos",
              template: "a-propos-de",
              defaults: new { controller = "Home", action = "About" }
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
