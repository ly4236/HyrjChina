using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HyrjChina.Web.HtmlHelpers
{
    public static class UrlExtensions
    {
        public static bool IsCurrent(this UrlHelper urlHelper, String areaName,
           String controllerName, params String[] actionNames)
        {
            return urlHelper.RequestContext.IsCurrentRoute(areaName, controllerName, actionNames);
        }

        public static string Selected(this UrlHelper urlHelper, String areaName,
            String controllerName, params String[] actionNames)
        {
            return urlHelper.IsCurrent(areaName, controllerName, actionNames)
                ? "selected" : String.Empty;
        }
    }
}