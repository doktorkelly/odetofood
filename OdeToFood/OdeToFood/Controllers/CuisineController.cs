using OdeToFood.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/

        [HttpPost]
        public ActionResult Search(string name)
        {
            var action = RouteData.Values["action"];
            string message = Server.HtmlEncode(
                "action: " + action +
                ", name: " + name +
                ", method: post");
            return Content(message);
            //return File(Server.MapPath("~/Content/Site.css"), "text/css");
            //return Json(new { Message = message, Name = name}, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //[Authorize]
        //[Log]
        public ActionResult Search()
        {
            throw new Exception("terribles");

            var action = RouteData.Values["action"];
            string message = Server.HtmlEncode(
                "action: " + action +
                ", method: get");
            return Content(message);
        }
    }
}
