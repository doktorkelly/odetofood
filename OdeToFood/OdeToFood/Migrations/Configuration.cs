namespace OdeToFood.Migrations
{
    using OdeToFood.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

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

            for (int i = 0; i < 200; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                    new Restaurant { Name = i.ToString(), City = "nowhere", Country = "usa" });
            }
            SeedMemberShip();
        }

        private void SeedMemberShip()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("user01", false) == null)
            {
                membership.CreateUserAndAccount("user01", "user01");
            }
            if (!roles.GetRolesForUser("user01").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] {"user01"}, new[] {"admin"});
            }
        }
    }
}
