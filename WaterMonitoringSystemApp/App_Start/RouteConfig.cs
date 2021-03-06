﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WaterMonitoringSystemApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "reportSensors",
                url: "FlowDataSensors/reportSensors/{dateSince}/{dateUntil}/{idEq}/",
                defaults: new
                {
                    controller = "FlowDataSensors",
                    action = "reportSensors",
                    dateSince = UrlParameter.Optional,
                    dateUntil = UrlParameter.Optional,
                    idEq = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "addRole",
                url: "UserRol/addRole/{idUser}/{idRol}/",
                defaults: new
                {
                    controller = "UserRol",
                    action = "addRole",
                    idUser = UrlParameter.Optional,
                    idRol = UrlParameter.Optional
                }
            );

        }
    }
}
