using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HyrjChina.Domain.Abstarct;
namespace HyrjChina.Web.Controllers
{
    public class CommonController : Controller
    {
        IAddressRepository _address;

        public CommonController(IAddressRepository address)
        {
            address = _address;
        }
        public ViewResult Address()
        {
            return View();
        }
    }
}