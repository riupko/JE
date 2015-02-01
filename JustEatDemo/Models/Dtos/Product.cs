using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustEatDemo.Models.Dtos
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Synonym { get; set; }
        public string Description { get; set; }
        public int RestaurantMenuNumber { get; set; }
        public string RestaurantMenuNumberCode { get; set; }
        public double Price { get; set; }
        public bool HasComboOptions { get; set; }
        public bool HasAccessories { get; set; }
        public bool HasRequiredAccessories { get; set; }
        public object ComboOptions { get; set; }
        public object Accessories { get; set; }
        public bool ContainsNuts { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsSpicy { get; set; }
        public bool RequireOtherProducts { get; set; }
    }

    public class ProductsResponse
    {
        public List<Product> Products { get; set; }
    }
}