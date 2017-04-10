using System.Web;
using System.Web.Optimization;

namespace Web.Miratech
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/custom.js",
                        "~/Scripts/app.js",
                        "~/Scripts/plugins/owl-carousel.js",
                        "~/Scripts/plugins/parallax-slider.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Plugins/bootstrap/js/bootstrap.js",
                        "~/Scripts/app.js",
                        "~/Scripts/custom.js",
                        "~/Plugins/back-to-top.js",
                        "~/Plugins/smoothScroll.js",
                        //"~/Plugins/parallax-slider/js/modernizr.js",
                        //"~/Plugins/parallax-slider/js/jquery.cslider.js",
                        "~/Plugins/master-slider/masterslider/masterslider.js",
                        "~/Scripts/plugins/master-slider-fw.js",
                        "~/Plugins/owl-carousel/owl-carousel/owl.carousel.js",
                        "~/Scripts/plugins/owl-carousel.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                //"~/Content/site.css",
                "~/Plugins/bootstrap/css/bootstrap.css",
                "~/Plugins/font-awesome/css/font-awesome.css",
                //"~/Content/plugins/material-design/material.css",
                "~/Content/style.css",
                "~/Content/custom.css",
                "~/Content/headers/header-default.css",
                "~/Content/footers/footer-v6.css",
                "~/Content/theme-colors/default.css",
                "~/Content/theme-skins/dark.css",
                "~/Content/plugins/animate.css",
                "~/Plugins/line-icons/line-icons.css",
                //"~/Plugins/parallax-slider/css/parallax-slider.css",
                "~/Plugins/master-slider/masterslider/style/masterslider.css",
                "~/Plugins/master-slider/masterslider/skins/black-2/style.css",
                "~/Plugins/owl-carousel/owl-carousel/owl.carousel.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}