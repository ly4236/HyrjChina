using System;
using System.Linq;
using System.Web.Routing;

namespace HyrjChina.Web.HtmlHelpers
{
    public static class RequestHelper
    {
        public static bool IsCurrentRoute(this RequestContext context, String areaName,
           String controllerName, params String[] actionNames)
        {
            var routeData = context.RouteData;
            var routeArea = routeData.DataTokens["area"] as String;
            var current = false;

            if (((String.IsNullOrEmpty(routeArea) && String.IsNullOrEmpty(areaName)) ||
                  (routeArea == areaName)) &&

                 ((String.IsNullOrEmpty(controllerName)) ||
                  (routeData.GetRequiredString("controller") == controllerName)) &&

                 ((actionNames == null) ||
                   actionNames.Contains(routeData.GetRequiredString("action"))))
            {
                current = true;
            }

            return current;
        }
    }
}