using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustEatDemo.Models.Dtos
{
    public class Category
    {
        public bool Bogof { get; set; }
        public bool Bogohp { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public object BackgroundImageUrl { get; set; }
        public int Sort { get; set; }
        public int Columns { get; set; }
    }

    public class CategoriesResponse
    {
        public List<Category> Categories { get; set; }
    }
}