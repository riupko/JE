using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustEatDemo.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Synonym { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Menu { get; set; }
    }
}