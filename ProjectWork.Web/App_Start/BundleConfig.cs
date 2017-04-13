using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace ProjectWork.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/ThirdParty/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
            //    "~/Scripts/knockout-{version}.js",
            //    "~/Scripts/knockout.validation.js"));
            bundles.Add(new ScriptBundle("~/bundles/ThirdParty").Include(
                "~/Scripts/ThirdParty/jquery-{version}.js",
                "~/Scripts/ThirdParty/bootstrap.js",
                "~/Scripts/ThirdParty/toastr.js",
                "~/Scripts/ThirdParty/jquery.raty.js",
                "~/Scripts/ThirdParty/respond.js",
                //"~/Scripts/ThirdParty/respond.src.js",
                "~/Scripts/ThirdParty/angular.js",
                "~/Scripts/ThirdParty/angular-route.js",
                "~/Scripts/ThirdParty/angular-cookies.js",
                "~/Scripts/ThirdParty/angular-validator.js",
                "~/Scripts/ThirdParty/angular-base64.js",
                "~/Scripts/ThirdParty/angular-file-upload.js",
                "~/Scripts/ThirdParty/angucomplete-alt.min.js",
                "~/Scripts/ThirdParty/ui-bootstrap-tpls.js",
                "~/Scripts/ThirdParty/underscore.js",
                "~/Scripts/ThirdParty/raphael.js",
                "~/Scripts/ThirdParty/morris.js",
                "~/Scripts/ThirdParty/jquery.fancybox.js",
                "~/Scripts/ThirdParty/jquery.fancybox-media.js",
                "~/Scripts/ThirdParty/loading-bar.js"));




            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/app/common.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Scripts/app/home.viewmodel.js",
                "~/Scripts/app/_run.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/Site.css"));
        }
    }
}
