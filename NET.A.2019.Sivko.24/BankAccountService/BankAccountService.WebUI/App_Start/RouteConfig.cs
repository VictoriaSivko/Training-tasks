﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BankAccountService.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "BankAccount",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
