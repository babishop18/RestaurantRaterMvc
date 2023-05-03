using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterMVC.Models.Restaurant
{
    public class RestaurantListItem
    {
        [Display(Name = "Restaurant Id")]
        public int RestaurantId { get; set; }

         [Display(Name = "Restaurant Name")]
        public string RestaurantName { get; set; }
        
        [Display(Name = "Average Score")]
        public double AverageScore { get; set; }

    }
}