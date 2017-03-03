﻿using System.Web;
using System.Web.Optimization;

namespace epsi
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/css/botstrap").Include(
                     "~/Content/bootstrap.css",                    
                     "~/Content/bootexpert-compose.css"));

            bundles.Add(new StyleBundle("~/bundles/css/epsi").Include(                  
                      "~/Content/epsi-*"));

            bundles.Add(new StyleBundle("~/bundles/css/lib").Include(                     
                     "~/Scripts/lib/rs-plugin/css/settings.css"));

            bundles.Add(new ScriptBundle("~/bundles/js/lib").Include(                                      
                      "~/Scripts/lib/prettyPhoto/js/jquery.prettyPhoto.js",
                      "~/Scripts/lib/rs-plugin/rs.home.js",
                      "~/Scripts/lib/chosen/chosen.jquery.js"));



        }
    }
}
