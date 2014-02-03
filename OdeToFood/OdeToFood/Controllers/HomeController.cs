using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;
using System.Configuration;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        IOdeToFoodDb _db;

        public HomeController()
        {
            _db = new OdeToFoodDb();
        }

        public HomeController(IOdeToFoodDb db)
        {
            _db = db;
        }

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Query<Restaurant>()
                .Where(x => x.Name.StartsWith(term))
                .Take(10)
                .Select(x => new {
                    label = x.Name 
                });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //[OutputCache(CacheProfile="Short")]
        [OutputCache(Duration = 60, VaryByHeader = "X-Requested-With;Accept-Language", Location = OutputCacheLocation.Server)]
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            int pageSize = 10;
            var model = _db.Query<Restaurant>()
                .OrderByDescending(r => r.Reviews.Average(x => x.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Select(r => new RestaurantListViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count()
                })
                .ToPagedList(page, pageSize);

            if (Request.IsAjaxRequest()) {
                return PartialView("_Restaurants", model);
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            ViewBag.Mailserver = ConfigurationManager.AppSettings["Mailserver"];
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

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
