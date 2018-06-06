using System.Web;
using System.Web.Optimization;

namespace testagat
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Scripts").Include(
                        "~/Scripts/jquery-1.11.1.js"));

            bundles.Add(new StyleBundle("~/Content").Include(
                      "~/Content/bootstrap.min.css"));
                      ;
        }
    }
}
