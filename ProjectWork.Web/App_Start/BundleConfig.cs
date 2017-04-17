﻿using System;
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
            bundles.Add(new ScriptBundle("~/bundles/ThirdParty").Include(
                "~/Scripts/ThirdParty/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/ThirdParty").Include(
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
                "~/Scripts/ThirdParty/angular-cookies.min.js",
                "~/Scripts/ThirdParty/angular-validator.js",
                "~/Scripts/ThirdParty/angular-base64.js",
                "~/Scripts/ThirdParty/angular-file-upload.js",
                "~/Scripts/ThirdParty/angucomplete-alt.min.js",
                "~/Scripts/ThirdParty/ui-bootstrap-tpls.js",
                "~/Scripts/ThirdParty/underscore.js",
                //"~/Scripts/ThirdParty/raphael.js",
                //"~/Scripts/ThirdParty/morris.js",
                "~/Scripts/ThirdParty/jquery.fancybox.js",
                "~/Scripts/ThirdParty/jquery.fancybox-media.js",
                "~/Scripts/ThirdParty/loading-bar.js",
                //"~/Scripts/OAuthComponents/auth0-lock/build/lock.js",
                //"~/Scripts/OAuthComponents/angular-jwt/dist/angular-jwt.js",
                //"~/Scripts/OAuthComponents/angular-lock/dist/angular-lock.js",
                "~/Scripts/ThirdParty/platform.js"));


            bundles.Add(new ScriptBundle("~/bundles/Application").Include(
                "~/Scripts/Application/Modules/common.core.js",
                "~/Scripts/Application/Modules/common.ui.js",
                "~/Scripts/Application/app.js",
                "~/Scripts/Application/services/apiService.js",
                "~/Scripts/Application/services/notificationService.js",
                "~/Scripts/Application/services/membershipService.js",
                "~/Scripts/Application/Layout/sideBar.directive.js",
                "~/Scripts/Application/Layout/topBar.directive.js",
                "~/Scripts/Application/home/rootCtrl.js",
                "~/Scripts/Application/home/indexCtrl.js",
                "~/Scripts/Application/account/loginCtrl.js",
                "~/Scripts/Application/account/registerCtrl.js"
                ));


            //bundles.Add(new ScriptBundle("~/bundles/app").Include(
            //    "~/Scripts/sammy-{version}.js",
            //    "~/Scripts/app/common.js",
            //    "~/Scripts/app/app.datamodel.js",
            //    "~/Scripts/app/app.viewmodel.js",
            //    "~/Scripts/app/home.viewmodel.js",
            //    "~/Scripts/app/_run.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/ThirdParty/modernizr").Include(
                "~/Scripts/ThirdParty/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/content/css/Site.css",
                "~/content/css/bootstrap.css",
                "~/content/css/bootstrap-theme.css",
                "~/content/css/font-awesome.css",
                //"~/content/css/morris.css",
                "~/content/css/toastr.css",
                "~/content/css/jquery.fancybox.css",
                "~/content/css/loading-bar.css"));
            BundleTable.EnableOptimizations = false;
        }
    }
}
