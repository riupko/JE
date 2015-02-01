﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustEatDemo.Models.Dtos
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Url { get; set; }
        public bool IsOpenNow { get; set; }
        public bool IsSponsored { get; set; }
        public bool IsNew { get; set; }
        public bool IsTemporarilyOffline { get; set; }
        public string ReasonWhyTemporarilyOffline { get; set; }
        public string UniqueName { get; set; }
        public bool IsCloseBy { get; set; }
        public bool IsHalal { get; set; }
        public int DefaultDisplayRank { get; set; }
        public bool IsOpenNowForDelivery { get; set; }
        public bool IsOpenNowForCollection { get; set; }
        public double RatingStars { get; set; }
        public List<Logo> Logo { get; set; }
        public int NumberOfRatings { get; set; }

        public string LogoUrl
        {
            get { return Logo.FirstOrDefault().StandardResolutionURL; }
        }
    }

    public class Logo
    {
        public string StandardResolutionURL { get; set; }
    }

    public class RestaurantsResponse
    {
        public string ShortResultText { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}