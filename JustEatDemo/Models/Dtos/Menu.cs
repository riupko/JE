using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustEatDemo.Models.Dtos
{
    public class Menu
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double DeliveryCostBelowThreshold { get; set; }
        public double DeliveryCostAboveThreshold { get; set; }
        public double DeliveryThresholdOrderAmount { get; set; }
        public string ClosingWorkTime { get; set; }
        public object DeliveryCostExamples { get; set; }
        public object CustomerReviewsSummary { get; set; }
        public object Categories { get; set; }
        public object Products { get; set; }
    }

    public class MenusResponse
    {
        public List<Menu> Menus { get; set; }
    }
}