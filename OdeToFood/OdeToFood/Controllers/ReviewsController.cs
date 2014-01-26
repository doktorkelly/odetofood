using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        //
        // GET: /Reviews/

        public ActionResult Index()
        {
            List<RestaurantReview> model = _reviews
                .OrderBy(x => x.Country)
                .ToList();

            return View(model);
        }

        //
        // GET: /Reviews/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Reviews/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Reviews/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Reviews/Edit/5

        public ActionResult Edit(int id)
        {
            RestaurantReview review = _reviews.Single(r => r.Id == id);

            return View(review);
        }

        //
        // POST: /Reviews/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            RestaurantReview review = _reviews.Single(r => r.Id == id);
            if (TryUpdateModel(review))
            {
                // todo: store into db ...
                return RedirectToAction("Index");
            }
            return View(review);
        }

        //
        // GET: /Reviews/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Reviews/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        static List<RestaurantReview> _reviews = new List<RestaurantReview>() {
            new RestaurantReview {
                Id = 1,
                Name = "cinnamon club",
                City = "london",
                Country = "uk",
                Rating = 10
            },
            new RestaurantReview {
                Id = 2,
                Name = "marrakesh",
                City = "<script>alert('css')</script>",
                Country = "usa",
                Rating = 10
            },
            new RestaurantReview {
                Id = 3,
                Name = "the house of elliot",
                City = "ghent",
                Country = "belgium",
                Rating = 10
            }
        };

    }
}
