using System.Web;
using System.Web.Optimization;

namespace Giangbb
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //////////////////////////////////////MATERIAL DASHBOARD//////////////////////////////////////////

            bundles.Add(new StyleBundle("~/Bootstrap/css").Include(
                "~/Content/material-dashboard/bootstrap.min.css"

            ));
            bundles.Add(new StyleBundle("~/Bootstrap/js").Include(
                "~/Scripts/material-dashboard/bootstrap.min.js"

            ));

            bundles.Add(new ScriptBundle("~/JQuery/js").Include(
                "~/Scripts/material-dashboard/jquery-3.1.1.min.js",
                "~/Scripts/material-dashboard/jquery-ui.min.js"
            ));

            bundles.Add(new StyleBundle("~/MaterialDashboard/font").Include(
                "~/Content/fonts/font-awesome.min.css",
                "~/Content/fonts/material-icons.css"

            ));

            bundles.Add(new StyleBundle("~/MaterialDashboard/css").Include(
                "~/Content/material-dashboard/material-dashboard.css"
//                "~/Content/material-dashboard/material-dashboard.css.map"

                ));

            bundles.Add(new StyleBundle("~/Views/css").Include(
                "~/Content/views/common.css"

            ));


            bundles.Add(new ScriptBundle("~/MaterialDashboard/js").Include(
                "~/Scripts/material-dashboard/material.min.js",
                "~/Scripts/material-dashboard/perfect-scrollbar.jquery.min.js",
                "~/Scripts/material-dashboard/jquery.validate.min.js",

                "~/Scripts/material-dashboard/moment.min.js",
                "~/Scripts/material-dashboard/chartist.min.js",
                "~/Scripts/material-dashboard/jquery.bootstrap-wizard.js",
                "~/Scripts/material-dashboard/bootstrap-notify.js",
                "~/Scripts/material-dashboard/bootstrap-datetimepicker.js",
                "~/Scripts/material-dashboard/jquery-jvectormap.js",
                "~/Scripts/material-dashboard/nouislider.min.js",
                "~/Scripts/material-dashboard/jquery.select-bootstrap.js",
                "~/Scripts/material-dashboard/jquery.datatables.js",
                "~/Scripts/material-dashboard/sweetalert2.js",
                "~/Scripts/material-dashboard/jasny-bootstrap.min.js",
                "~/Scripts/material-dashboard/fullcalendar.min.js",
                "~/Scripts/material-dashboard/jquery.tagsinput.js",               
                "~/Scripts/material-dashboard/material-dashboard.js",
                "~/Scripts/material-dashboard/jquery-cookie.js"


                ));
            bundles.Add(new ScriptBundle("~/MaterialDashboardDemo/js").Include(
                "~/Scripts/material-dashboard/demo.js"
            ));
            bundles.Add(new StyleBundle("~/MaterialDashboardDemo/css").Include(
                "~/Content/material-dashboard/demo.css"
            ));

            //////////////////////////////////////VIEW//////////////////////////////////////////
            bundles.Add(new ScriptBundle("~/Notification/js").Include(
                "~/Scripts/material-dashboard/show-notification.js"
            ));

            //////////////////////////////////////CUSTOMER
            bundles.Add(new ScriptBundle("~/View/customers/index/js").Include(
                "~/Scripts/views/customers/index.js"
            ));
        
            bundles.Add(new ScriptBundle("~/View/customers/new/js").Include(
                "~/Scripts/views/customers/new2.js"
            ));
        }
    }
}
