using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];
            string message = string.Format("{0}::{1} {2}", controller, action, id);
            string message1 = "Modify this template to jump-start your ASP.NET MVC application.";

            ViewBag.Message = message;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            AboutModel model = new AboutModel();
            model.Name = "David";
            model.Location = "Maryland USA";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
