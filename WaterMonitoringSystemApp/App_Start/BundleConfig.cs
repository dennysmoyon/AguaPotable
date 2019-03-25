using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace WaterMonitoringSystemApp
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.numeric.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/app/common.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Scripts/app/home.viewmodel.js",
                "~/Scripts/app/_run.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios.  De esta manera estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/fusionCharts/fusioncharts.js",
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/moment.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-datetimepicker.js",
                "~/Scripts/respond.js"));

            //bundle para generacion de graficas
            bundles.Add(new ScriptBundle("~/bundles/fusioncharts").Include(
                "~/Scripts/fusionCharts/fusioncharts.charts.js",
                "~/Scripts/fusionCharts/fusioncharts.widgets.js",
                "~/Scripts/fusionCharts/jquery-fusioncharts.js",
                "~/Scripts/fusionCharts/fusioncharts.theme.*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/bootstrap-datetimepicker.css",
                 "~/Content/Site.css"));

        }
    }
}
