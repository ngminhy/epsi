using System.Web;
using System.Web.Optimization;

namespace epsi_static
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/css/bootstrap").Include(
                      "~/Content/css/lib/bootstrap.min.css"));
            bundles.Add(new ScriptBundle("~/css/style").Include(
                      "~/Content/css/epsi-*"));
            bundles.Add(new ScriptBundle("~/css/fontawesome").Include(
                        "~/Content/css/lib/font-awesome.min.css"));
            bundles.Add(new ScriptBundle("~/css/rsplugin").Include(
                        "~/Content/lib/rs-plugin/css/settings.css"));
            bundles.Add(new ScriptBundle("~/css/bootexpert").Include(
                        "~/Content/css/lib/bootexpert-compose.css"));
            bundles.Add(new ScriptBundle("~/css/slick").Include(
                        "~/Content/lib/slick/slick.css",
                        "~/Content/lib/slick/slick-theme.css"));

            bundles.Add(new ScriptBundle("~/js/modernizr").Include(
                        "~/Content/js/lib/modernizr-*"));
            bundles.Add(new ScriptBundle("~/js/jquery").Include(
                        "~/Content/js/lib/jquery-2.1.1.min.js",
                        "~/Content/js/jquery-ui/jquery-ui.js"));
            bundles.Add(new ScriptBundle("~/js/bootstrap").Include(
                        "~/Content/js/lib/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/js/rsplugin").Include(
                        "~/Content/lib/rs-plugin/js/jquery.themepunch.tools.min.js",
                        "~/Content/lib/rs-plugin/js/jquery.themepunch.revolution.min.js",
                        "~/Content/lib/rs-plugin/rs.home.js"));
            bundles.Add(new ScriptBundle("~/js/core").Include(
                        "~/Content/js/core.js"));
            bundles.Add(new ScriptBundle("~/js/ntm").Include(
                        "~/Content/lib/ntm/jquery.ntm.js"));
            bundles.Add(new ScriptBundle("~/js/chosen").Include(
                        "~/Content/lib/chosen/chosen.jquery.js",
                        "~/Content/lib/chosen/chosen.proto.min.js"));
            bundles.Add(new ScriptBundle("~/js/slick").Include(
                        "~/Content/lib/slick/slick.min.js"));
            bundles.Add(new ScriptBundle("~/js/prettyPhoto").Include(
                        "~/Content/lib/prettyPhoto/js/jquery.prettyPhoto.js"));
        }
    }
}
