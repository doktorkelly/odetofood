namespace OdeToFood.Migrations
{
    using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "sabatinos", City = "new york", Country = "usa" },
                new Restaurant { Name = "great lake", City = "chicago", Country = "usa" },
                new Restaurant {
                    Name = "smaka",
                    City = "gothenburg",
                    Country = "sweden",
                    Reviews = new List<RestaurantReview> {
                        new RestaurantReview { Rating = 9, Body = "great food", ReviewerName = "David" }
                    }
                });
            //not working:
            //context.Reviews.AddOrUpdate(v => v.Id,
            //    new RestaurantReview { Id = 1, Rating = 8, Body = "great food", ReviewerName = "David" });
        }
    }
}
