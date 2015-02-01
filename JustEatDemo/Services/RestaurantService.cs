using AutoMapper;
using JustEatDemo.Models;
using JustEatDemo.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace JustEatDemo.Services
{
    public class RestaurantService : IRestaurantService
    {
        private const string BaseUrl = "http://api-interview.just-eat.com";
        private const string RestaurantsPath = "restaurants?q={0}";
        private const string MenusPath = "restaurants/{0}/menus";
        private const string CategoriesPath = "menus/{0}/productcategories";
        private const string ProductsPath = "menus/{0}/productcategories/{1}/products";

        private readonly Lazy<HttpClient> _lazyHttpClient = new Lazy<HttpClient>(() =>
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-GB"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "VGVjaFRlc3RBUEk6dXNlcjI=");
                client.DefaultRequestHeaders.Add("Accept-Tenant", "uk");
                client.DefaultRequestHeaders.Host = "api-interview.just-eat.com";
                return client;
            }
        );

        private HttpClient _httpClient
        {
            get 
            {
                return _lazyHttpClient.Value;
            }
        }

        /// <summary>
        /// Get response from the remote api
        /// </summary>
        /// <typeparam name="T">Type of returned object</typeparam>
        /// <param name="path">Path to query objects</param>
        /// <returns></returns>
        private async Task<T> GetApiResponse<T>(string path)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<List<RestaurantModel>> GetRestaurantsAsync(string postCode)
        {
            //retrieve restaurants
            var restarants = await GetApiResponse<RestaurantsResponse>(string.Format(RestaurantsPath, postCode))
                                                .ContinueWith(t => t.Result.Restaurants);
            return restarants.Select(r => Mapper.Map<RestaurantModel>(r)).ToList();
        }

        public async Task<List<ProductModel>> GetProductsAsync(int restaurantId)
        {
            //retrieve menus
            var menus = await GetApiResponse<MenusResponse>(string.Format(MenusPath, restaurantId))
                                    .ContinueWith(t => t.Result.Menus);

            var result = new List<ProductModel>();
            foreach (var m in menus)
            {
                //retrieve categories
                var categories = await GetApiResponse<CategoriesResponse>(string.Format(CategoriesPath, m.Id))
                                        .ContinueWith(t => t.Result.Categories);
                foreach (var c in categories)
                {
                    //retrieve products
                    var products = await GetApiResponse<ProductsResponse>(string.Format(ProductsPath, m.Id, c.Id))
                                        .ContinueWith(t => t.Result.Products);
                    
                    //fill menu and category fields of product and add to result range 
                    result.AddRange(products.Select(p => Mapper.Map<ProductModel>(p,
                        o => o.AfterMap((s, d) => { ((ProductModel)d).Category = c.Name; ((ProductModel)d).Menu = m.Title; }))));
                }
            }
            //order products by menu, category, name
            return result.OrderBy(p => p.Menu).OrderBy(p => p.Category).OrderBy(p => p.Name).ToList();
        }
    }
}