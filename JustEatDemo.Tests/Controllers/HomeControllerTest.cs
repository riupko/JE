using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JustEatDemo;
using JustEatDemo.Controllers;
using JustEatDemo.Services;
using Moq;
using JustEatDemo.Models;
using System.Threading.Tasks;
using System.Reflection;

namespace JustEatDemo.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IRestaurantService> _restaurantService = new Mock<IRestaurantService>();
        
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(_restaurantService.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetRestaurants()
        {
            // Arrange
            _restaurantService.Setup(x => x.GetRestaurantsAsync(It.IsAny<string>())).ReturnsAsync(new List<RestaurantModel>()
            {
                new RestaurantModel() { Name = "Rest1" },
                new RestaurantModel() { Name = "Rest2" },
            });
            HomeController controller = new HomeController(_restaurantService.Object);

            // Act
            PartialViewResult result = controller.Restaurants(new PostcodeModel() { Postcode = It.IsAny<string>() }).Result as PartialViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(((List<RestaurantModel>)result.Model).Count(), 2);
        }

        [TestMethod]
        public void GetRestaurants_HasAjaxHandleErrorAttribute()
        {
            // Arrange
            var expected = "PartialError";
            MethodInfo method = typeof(HomeController).GetMethod("Restaurants",
                new Type[] { typeof(PostcodeModel) });

            // Act
            var attributes = method.GetCustomAttributes(typeof(AjaxHandleErrorAttribute), true);
            if (attributes.Count() == 0)
                attributes = typeof(HomeController).GetCustomAttributes(typeof(AjaxHandleErrorAttribute), true);
            // Assert
            var errorAttribute = (AjaxHandleErrorAttribute)attributes[0];
            var actual = errorAttribute.PartialViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRestaurants_Error()
        {
            // Arrange
            _restaurantService.Setup(x => x.GetRestaurantsAsync(It.IsAny<string>())).ThrowsAsync(new Exception(It.IsAny<string>()));
            HomeController controller = new HomeController(_restaurantService.Object);

            Exception exc = null;
            // Act
            try
            {
                var result = controller.Restaurants(new PostcodeModel() { Postcode = It.IsAny<string>() }).Result;
            }
            catch (Exception ex)
            {
                exc = ex;
            }
            // Assert
            Assert.IsNotNull(exc);
        }
    }
}
