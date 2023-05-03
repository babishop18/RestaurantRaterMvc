using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantRaterMVC.Data;
using RestaurantRaterMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Services.RestaurantService
{
    public class RestaurantService : IRestaurantService
    {
        private RestaurantDbContext _context;
        public RestaurantService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<RestaurantListItem>> GetAllRestaurantsAsync()
        {
            List<RestaurantListItem> restaurants = await _context.Restaurants.Include(r => r.Ratings)
            .Select(listItem => new RestaurantListItem()
            {
                RestaurantId = listItem.RestaurantId,
                RestaurantName = listItem.RestaurantName,
                AverageScore = listItem.AverageScore
            }).ToListAsync();

            return restaurants;
        }

        // public async Task<bool> CreateRestaurant(RestaurantCreate model)
        // {

        // }

        // public async Task<RestaurantDetail> GetRestaurantById(int id)
        // {

        // }

        // public async Task<bool> UpdateRestaurant(RestaurantEdit model)
        // {

        // }

        // public async Task<bool> DeleteRestaurant(int id)
        // {

        // }
    }
}