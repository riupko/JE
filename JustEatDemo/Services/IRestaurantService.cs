using JustEatDemo.Models;
using JustEatDemo.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace JustEatDemo.Services
{
    public interface IRestaurantService
    {
        /// <summary>
        /// Get list of restaurants by postcode
        /// </summary>
        /// <param name="postCode">Postcode value</param>
        /// <returns>List of restaurants</returns>
        Task<List<RestaurantModel>> GetRestaurantsAsync(string postCode);

        /// <summary>
        /// Get list of restaurant products
        /// </summary>
        /// <param name="restaurantId">Restaurant Id value</param>
        /// <returns>List of products</returns>
        Task<List<ProductModel>> GetProductsAsync(int restaurantId);
    }
}