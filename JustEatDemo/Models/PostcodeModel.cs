using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JustEatDemo.Models
{
    public class PostcodeModel
    {
        [Required]
        public string Postcode { get; set; }
    }
}