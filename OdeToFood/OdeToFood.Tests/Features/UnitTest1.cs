using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.Tests.Features
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ComputeRating_forOneReview()
        {
            //arrange
            var data = BuildRestaurantAndReviews(new[] { 4 });
           
            //act
            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);

            //assert
            Assert.AreEqual(4, result.Rating);
        }

        [TestMethod]
        public void ComputeRating_forTwoReviews()
        {
            //arrange
            var data = BuildRestaurantAndReviews(new[] { 4, 8 });

            //act
            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);

            //assert
            Assert.AreEqual(6, result.Rating);
        }

        private Restaurant BuildRestaurantAndReviews(params int[] ratings)
        {
            var restaurant = new Restaurant();
            restaurant.Reviews = ratings
                .Select(x => new RestaurantReview() { Rating = x })
                .ToList();
            return restaurant;
        }
    }
}
