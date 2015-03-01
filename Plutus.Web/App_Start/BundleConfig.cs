using System.Web;
using System.Web.Optimization;

namespace Plutus.Web {
    public class BundleConfig {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                          "~/Scripts/jquery.validate.js",
                          "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/site.css",
                      "~/Content/GeneralDisplay.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                                        "~/Content/themes/base/core.css",
                                        "~/Content/themes/base/resizable.css",
                                        "~/Content/themes/base/selectable.css",
                                        "~/Content/themes/base/accordion.css",
                                        "~/Content/themes/base/autocomplete.css",
                                        "~/Content/themes/base/button.css",
                                        "~/Content/themes/base/dialog.css",
                                        "~/Content/themes/base/slider.css",
                                        "~/Content/themes/base/tabs.css",
                                        "~/Content/themes/base/datepicker.css",
                                        "~/Content/themes/base/progressbar.css",
                                        "~/Content/themes/base/theme.css"));


            bundles.Add(new StyleBundle("~/Content/jQRangeSlider").Include(
                                        "~/Content/jQRangeSlider/iThing.css",
                                        "~/Content/jQRangeSlider/jQRangeSlider-ovverides.css"));

            bundles.Add(new StyleBundle("~/bundles/jQRangeSlider").Include(
                                        "~/Scripts/jQRangeSlider/jQAllRangeSliders-min.js",
                                        "~/Scripts/jQRangeSlider/jQAllRangeSliders-withRuler-min.js",
                                        "~/Scripts/jQRangeSlider/jQDateRangeSlider-withRuler-min.js",
                                        "~/Scripts/jQRangeSlider/jQEditRangeSlider-min.js",
                                        "~/Scripts/jQRangeSlider/jQEditRangeSlider-withRuler-min.js",
                                        "~/Scripts/jQRangeSlider/jQRangeSlider-withRuler-min.js",
                                        "~/Scripts/jQRangeSlider/jQRangeSlider-min.js"));


            bundles.Add(new ScriptBundle("~/bundles/d3").Include(
                                         "~/Scripts/d3/d3.js"));

            bundles.Add(new ScriptBundle("~/bundles/entries").Include(
                                         "~/Scripts/entries/graph.js",
                                         "~/Scripts/entries/barChart.js"));

            bundles.Add(new ScriptBundle("~/bundles/generalDisplay").Include(
                                         "~/Scripts/GeneralDisplay/filter.js"));

            //https://github.com/ConnorDoyle/jquery.polartimer.js
            bundles.Add(new ScriptBundle("~/bundles/filtering").Include(
                                         "~/Scripts/Filtering/jquery.polartimer.js"));



            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
