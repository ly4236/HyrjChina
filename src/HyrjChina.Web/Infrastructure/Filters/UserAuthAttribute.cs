using System.Web;
using System.Web.Mvc;

namespace HyrjChina.Web.Infrastructure.Filters
{
    public class UserAuthAttribute : AuthorizeAttribute
    {
        private bool localAllowed;
        public UserAuthAttribute(bool allowedParam)
        {
            localAllowed = allowedParam;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsLocal)
            {
                return localAllowed;
            }
            else {
                return true;
            }
        }
    }
}