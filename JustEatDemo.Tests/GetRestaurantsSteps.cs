using JustEatDemo.Controllers;
using JustEatDemo.Models;
using JustEatDemo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace JustEatDemo.Tests
{
    [Binding]
    public class GetRestaurantsSteps
    {
        private Mock<IRestaurantService> _restaurantService = new Mock<IRestaurantService>();

        private HomeController _homeController;

        private PostcodeModel _postcodeModel;

        private ActionResult _actionResult;
        
        [Given(@"I have entered valid postcode '(.*)' into the textbox")]
        public void GivenIHaveEnteredValidPostcodeIntoTheTextbox(string p0)
        {
            _postcodeModel = new PostcodeModel() { Postcode = p0 };
            _restaurantService.Setup(x => x.GetRestaurantsAsync(It.IsAny<string>())).ReturnsAsync(new List<RestaurantModel>()
            {
                new RestaurantModel() { Name = "Rest1" },
                new RestaurantModel() { Name = "Rest2" },
            });
            _homeController = new HomeController(_restaurantService.Object);
        }

        [Given(@"I have entered invalid postcode '(.*)' into the textbox")]
        public void GivenIHaveEnteredInvalidPostcodeIntoTheTextbox(string p0)
        {
            _postcodeModel = new PostcodeModel() { Postcode = p0 };
            _restaurantService.Setup(x => x.GetRestaurantsAsync(It.IsAny<string>())).ReturnsAsync(new List<RestaurantModel>() { });
            _homeController = new HomeController(_restaurantService.Object);
        }

        [When(@"I press find")]
        public void WhenIPressFind()
        {
            _actionResult = _homeController.Restaurants(_postcodeModel).Result;
        }

        [Then(@"the result should be the list of restaurants")]
        public void ThenTheResultShouldBeTheListOfRestaurants()
        {
            Assert.IsInstanceOfType(_actionResult, typeof(PartialViewResult));
            //if count > 0 then list of restaurants on the page
            Assert.AreEqual(((List<RestaurantModel>)((PartialViewResult)_actionResult).Model).Count, 2);
        }

        [Then(@"the result should be error message")]
        public void ThenTheResultShouldBeErrorMessage()
        {
            Assert.IsInstanceOfType(_actionResult, typeof(PartialViewResult));
            //if count equals 0 then message 'There aren't any restaurants' on the page
            Assert.AreEqual(((List<RestaurantModel>)((PartialViewResult)_actionResult).Model).Count, 0);
        }
    }
}
