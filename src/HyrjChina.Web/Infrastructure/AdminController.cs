using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HyrjChina.Web.Infrastructure
{
    /// <summary>
    /// Base controller for all Admin area
    /// </summary>
    [Authorize(Roles = "Admin")]
    public abstract class AdminController : Controller { }
}