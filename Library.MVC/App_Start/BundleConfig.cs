using System.Web;
using System.Web.Optimization;

namespace Library.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
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

            bundles.Add(new StyleBundle("~/Content/fontawesomeCss").Include(
                      "~/Content/fontawesome/css/fonts/fontawesome.min.css"));

            bundles.Add(new ScriptBundle("~/Content/fontawesomeJs").Include(
                      "~/Content/fontawesome/js/fontawesome.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/appScripts").Include(
                      "~/Scripts/ApplicationScripts/General.js",
                      "~/Scripts/ApplicationScripts/Books.js",
                      "~/Scripts/ApplicationScripts/Authors.js"
                ));
        }
    }
}
