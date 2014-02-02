using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Tests.Features;
using OdeToFood.Controllers;
using OdeToFood.Models;

namespace OdeToFood.Tests.Controllers
{
    [TestClass]
    public class RestaurantControllerTests
    {
        [TestMethod]
        public void Create_ValidRestaurant_ShouldBeSaved()
        {
            //arrange
            var db = new FakeOdeToFoodDb();
            var controller = new RestaurantController(db);

            //act
            controller.Create(new Restaurant());

            //assert
            Assert.AreEqual(1, db.Added.Count);
            Assert.AreEqual(true, db.Saved);
        }

        [TestMethod]
        public void Create_InValidRestaurant_ShouldNotBeSaved()
        {
            //arrange
            var db = new FakeOdeToFoodDb();
            var controller = new RestaurantController(db);
            controller.ModelState.AddModelError("", "Invalid");

            //act
            controller.Create(new Restaurant());

            //assert
            Assert.AreEqual(0, db.Added.Count);
        }

    }
}
