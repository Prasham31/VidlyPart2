using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //In order to use attribute routing we need to enable it
            routes.MapMvcAttributeRoutes();

            #region comments for extra information
            //currently this file has same amount of code but in real time project this file will have grow and will
            //have huge data and over time it become a mess
            //Plus you have to go back and fourth with your custom routes
            //If we change the action name in controller class it will not update in route.config file because of magic string
            //so when we rename controller or action we have to remember to change the name as well.

            #endregion

            //Defining a custom route
            routes.MapRoute(
                name: "MoviesByReleaseDate",
                url: "movies/released/{year}/{month}",
                new { controller = "Movies", action = "ByRelaeaseDate" },
                new {year = @"\d{4}", month = @"\d{2}" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
