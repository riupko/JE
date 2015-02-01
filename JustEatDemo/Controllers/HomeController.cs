using JustEatDemo.Services;
using JustEatDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JustEatDemo.Controllers
{
    [AjaxHandleError]
    public class HomeController : Controller
    {
        private IRestaurantService _client;

        public HomeController(IRestaurantService client)
        {
            this._client = client;
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Find all restaurant by postcode
        /// </summary>
        /// <param name="postcodeModel">Postcode model includes postcode value</param>
        /// <returns>Partial view of restaurant list</returns>
        public async Task<ActionResult> Restaurants(PostcodeModel postcodeModel)
        {
            var restaurants = new List<RestaurantModel>();
            if (ModelState.IsValid)
            { 
                //get restautrants by postcode and order by avarage rating desc
                restaurants = await _client.GetRestaurantsAsync(postcodeModel.Postcode)
                                           .ContinueWith(t=>t.Result.OrderByDescending(r => r.RatingStars).ToList());
            }
            return PartialView(restaurants);
        }

        /// <summary>
        /// Get list of restaurant products
        /// </summary>
        /// <param name="Id">Restaurant Id</param>
        /// <returns>Partial view of the product list</returns>
        public async Task<ActionResult> Products(int Id)
        {
            var products = await _client.GetProductsAsync(Id);
            return PartialView(products);
        }
    }
}