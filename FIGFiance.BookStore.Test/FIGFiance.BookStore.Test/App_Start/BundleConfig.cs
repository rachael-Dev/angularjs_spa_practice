using System.Web;
using System.Web.Optimization;

namespace FIGFiance.BookStore.Test
{
    /// <summary>
    /// 
    /// </summary>
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/angulars/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/angulars").Include(
                "~/Scripts/angulars/jquery.js",
                "~/Scripts/angulars/bootstrap.js",
                "~/Scripts/angulars/toastr.js",
                "~/Scripts/angulars/jquery.raty.js",
                "~/Scripts/angulars/respond.src.js",
                "~/Scripts/angulars/angular.js",
                "~/Scripts/angulars/angular-route.js",
                "~/Scripts/angulars/angular-cookies.js",
                "~/Scripts/angulars/angular-validator.js",
                "~/Scripts/angulars/angular-base64.js",
                "~/Scripts/angulars/angular-file-upload.js",
                "~/Scripts/angulars/angucomplete-alt.min.js",
                "~/Scripts/angulars/ui-bootstrap-tpls-0.13.1.js",
                "~/Scripts/angulars/underscore.js",
                "~/Scripts/angulars/raphael.js",
                "~/Scripts/angulars/morris.js",
                "~/Scripts/angulars/jquery.fancybox.js",
                "~/Scripts/angulars/jquery.fancybox-media.js",
                "~/Scripts/angulars/loading-bar.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/figbooks").Include(
                "~/Scripts/figbooks/modules/common.core.js",
                "~/Scripts/figbooks/modules/common.ui.js",

                "~/Scripts/figbooks/app.js",
                "~/Scripts/figbooks/services/apiService.js",
                "~/Scripts/figbooks/services/notificationService.js",                
                
                //"~/Scripts/figbooks/layout/customPager.directive.js",                
                
                //"~/Scripts/figbooks/home/rootCtrl.js",
                //"~/Scripts/figbooks/home/indexCtrl.js",
                
                "~/Scripts/figbooks/books/books.controller.js",                
                "~/Scripts/figbooks/books/bookdetail.controller.js"                            
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/content/css/site.css",
                "~/content/css/bootstrap.css",
                "~/content/css/bootstrap-theme.css",
                 "~/content/css/font-awesome.css",
                "~/content/css/morris.css",
                "~/content/css/toastr.css",
                "~/content/css/jquery.fancybox.css",
                "~/content/css/loading-bar.css"));

            BundleTable.EnableOptimizations = false;
        }
        /*
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }*/
    }
}
