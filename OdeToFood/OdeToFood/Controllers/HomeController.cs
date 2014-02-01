using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Restaurants
                .Where(x => x.Name.StartsWith(term))
                .Take(10)
                .Select(x => new {
                    label = x.Name 
                });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //[OutputCache(Duration=60, VaryByHeader="X-Requested-With;Accept-Language", Location=OutputCacheLocation.Server)]
        [OutputCache(CacheProfile="Short")]
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            int pageSize = 10;
            var model = _db.Restaurants
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
