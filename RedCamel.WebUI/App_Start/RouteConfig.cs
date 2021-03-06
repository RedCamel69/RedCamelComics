﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RedCamel.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(null,
             "",
             new { controller = "Home", action = "Index" });


            routes.MapRoute(null,
                 "", 
                 new { controller = "Product", action = "List", category = (string)null, page = 1 });

            routes.MapRoute(null, 
                "Page{page}", 
                new { controller = "Product", action = "List", category = (string)null }, new { page = @"\d+" });


            routes.MapRoute(null,
               "Page{page}",
               new { controller = "Product", action = "List", subject=(int?)null, category = (string)null }, new { page = @"\d+" });

            routes.MapRoute(null, "{category}", new { controller = "Product", action = "List", page = 1 });

            routes.MapRoute(null, 
                "{category}/Page{page}", 
                new { controller = "Product", action = "List" }, 
                new { page = @"\d+" }); routes.MapRoute(null, "{controller}/{action}");

            
        }
    }
}
