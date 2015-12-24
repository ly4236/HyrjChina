using HyrjChina.Web.Filters;
using HyrjChina.Web.Services.Customers;
using HyrjChina.Web.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HyrjChina.Web.Controllers
{
    [CustomerAuthorizationAttribute]
    public class ProfileController : Controller
    {
        #region private

        private readonly IProfileService _profileService = new ProfileService();

        #endregion

        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
    }
}