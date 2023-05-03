using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantRaterMVC.Models.Restaurant;
using RestaurantRaterMVC.Services.RatingService;
using RestaurantRaterMVC.Services.RestaurantService;

namespace RestaurantRaterMVC.Controllers
{
    [Route("[controller]")]
    public class RestaurantController : Controller
    {
        private readonly ILogger<RestaurantController> _logger;
        private readonly IRestaurantService _restaurantService;
        private readonly IRatingService _ratingService;

        public RestaurantController(ILogger<RestaurantController> logger, IRestaurantService restaurantService, IRatingService ratingService)
        {
            _logger = logger;
            _restaurantService = restaurantService;
            _ratingService = ratingService;
        }

        public async Task<IActionResult> Index()
        {
            List<RestaurantListItem> restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return View(restaurants);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }


    }
}