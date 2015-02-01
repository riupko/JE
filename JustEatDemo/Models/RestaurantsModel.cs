using JustEatDemo.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustEatDemo.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public double RatingStars { get; set; }
        public string LogoUrl { get; set; }
        public string Products { get; set; }
    }
}