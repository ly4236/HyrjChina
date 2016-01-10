using System.Web.Optimization;

namespace HyrjChina.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new StyleBundle("∼/Content/css").Include("∼/Content/*.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/scripts/jquery-1.*"));
           //bundles.Add(new
           // ScriptBundle("∼/bundles/clientfeaturesscripts")
           // .Include("∼/Scripts/jquery-{version}.js",
           // "∼/Scripts/jquery.validate.js",
           // "∼/Scripts/jquery.validate.unobtrusive.js",
           // "∼/Scripts/jquery.unobtrusive-ajax.js"));
        }
    }
}