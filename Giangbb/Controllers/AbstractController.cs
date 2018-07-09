using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Giangbb.Controllers
{
    public class AbstractController : Controller
    {
        public void SetFlash(string message, string type)
        {
            Response.Cookies.Add(new HttpCookie("FlashMessage", message) { Path = "/" });
            Response.Cookies.Add(new HttpCookie("FlashType", type) { Path = "/" });
        }

        //testgit
    }
}