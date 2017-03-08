using System.Web;
using System.Web.Optimization;

namespace epsi
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/css/rsplugin").Include(
                              "~/Content/lib/rs-plugin/css/settings.css"));
            bundles.Add(new ScriptBundle("~/css/bootexpert").Include(
                        "~/Content/css/lib/bootexpert-compose.css"));
            bundles.Add(new ScriptBundle("~/css/slick").Include(
                        "~/Content/lib/slick/slick.css",
                        "~/Content/lib/slick/slick-theme.css"));

            bundles.Add(new ScriptBundle("~/js/modernizr").Include(
                        "~/Content/js/lib/modernizr-*"));
            bundles.Add(new ScriptBundle("~/js/core").Include(
                        "~/Content/js/core.js"));
            bundles.Add(new ScriptBundle("~/js/slick").Include(
                        "~/Content/lib/slick/slick.min.js"));
            bundles.Add(new ScriptBundle("~/js/prettyPhoto").Include(
                        "~/Content/lib/prettyPhoto/js/jquery.prettyPhoto.js"));
        }
    }
}
