using System.Web;
using System.Web.Optimization;

namespace SIS_Ga2
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            BundleTable.EnableOptimizations = false;

            bundles.Add(new StyleBundle("~/Content/css").Include(
                                "~/Content/bootstrap.min.css",
                                "~/Content/bootstrap.css",
                                "~/Content/font-awesome.min.css",
                                "~/Content/fontastic.css",
                                "~/Content/Poppins.css",
                                "~/Content/style.default.css",
                                "~/Content/custom.css",
                                "~/Content/img/favicon.ico",
                                "~/Content/bootstrap-datepicker.min.css"));



            bundles.Add(new ScriptBundle("~/Content/js").Include(
                                "~/Scripts/jquery.min.js",
                                "~/Scripts/popper.min.js",
                                "~/Scripts/bootstrap.js",
                                "~/Scripts/bootstrap.min.js",
                                "~/Scripts/jquery.cookie.js",
                                "~/Scripts/jquery-3.3.1.slim.js",
                                "~/Scripts/jquery-3.3.1.slim.min.js",
                                "~/Scripts/Chart.min.js",
                                "~/Scripts/jquery-validation/jquery.validate.min.js",
                                "~/Scripts/charts-home.js",
                                "~/Scripts/jquery-3.3.1.js",
                                "~/Scripts/jquery-ui.js",
                                "~/Scripts/front.js",
                                "~/Scripts/bootstrap-datepicker.min.js"));


        }
    }
}
