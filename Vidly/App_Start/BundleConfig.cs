using System.Web;
using System.Web.Optimization;

namespace Vidly
{
    public class BundleConfig
    {
        //If we want to add our own bootstrap file we need to refere here

        //This is the file where we define bundle of client side assets.
        //We can combine multiple css and javascripts files into a bundle and this way we reduce no of http requests
        //required to get this assets when the page is loaded and this results in faster page load

        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/bundles/bootstrap").Include(
                        "~/Scripts/bootbox.js",  //reference to bootbox
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap.js"));

            //Below is Jquery bundle
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(    
            //            "~/Scripts/jquery-{version}.js"));

            //Below is Jquery validation bundle
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //Below is for modernizr
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //Below is for bootstrap
            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //            "~/Scripts/bootbox.js",  //reference to bootbox
            //          "~/Scripts/bootstrap.js"));

            //Below is for CSS
            //  instaed of "~/Content/bootstrap.css" we are using  "~/Content/bootstrap-lumen.css"
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/datatables/css/datatables.bootstrap.css"));
        }
    }
}
