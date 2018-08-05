using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Giangbb.Controllers
{
    public class RentalController : Controller
    {
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
    }
}