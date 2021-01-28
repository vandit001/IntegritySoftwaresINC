﻿using System;
using System.Configuration;
using System.Web.Optimization;

namespace IntegrityWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = string.IsNullOrEmpty(ConfigurationManager.AppSettings["UseMinifyJs"]) ? false : Convert.ToBoolean(ConfigurationManager.AppSettings["UseMinifyJs"]);

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/FrontCss").Include(
                     "~/Content/lib.css",
                     "~/Content/style.css",
                     "~/Content/responsive.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Frontjs").Include(
                       "~/Scripts/jquery-3.4.1.min.js",
                       "~/Scripts/lib.js",
                       "~/Scripts/functions.js",
                       "~/Scripts/calendlywidget.js",
                       "~/Scripts/custom.js"));
        }
    }
}
