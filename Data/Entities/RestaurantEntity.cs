using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterMVC.Data.Entities
{
    public class RestaurantEntity
    {
        [Key]
        public int RestaurantId { get; set; }
        [Required]
        [MaxLength(100)]
        public string RestaurantName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }
         public virtual List<RatingEntity> Ratings { get; set; } = new List<RatingEntity>();
         public double AverageFoodScore
        {
            get
            {
                return Ratings.Count > 0 ? Ratings.Select(r => r.FoodScore).Sum() / Ratings.Count : 0;
            }
        }
        public double AverageCleanlinessScore
        {
            get
            {
                return Ratings.Count > 0 ? Ratings.Select(r => r.CleanlinessScore).Sum() / Ratings.Count : 0;
            }
        }
        public double AverageAtmosphereScore
        {
            get
            {
                return Ratings.Count > 0 ? Ratings.Select(r => r.AtmosphereScore).Sum() / Ratings.Count : 0;
            }
        }
        public double AverageScore
        {
            get
            {
                return (AverageFoodScore + AverageCleanlinessScore + AverageAtmosphereScore) / 3;
            }
        }
    }
}