using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantFinder.Logic.Models;

namespace RestaurantFinder.Logic
{
    public interface IRestaurantLogic
    {
        Task<Restaurant> GetRestaurant(int id);
        Task<Restaurant> GetRandomRestaurant();
        Task<List<Restaurant>> GetRestaurantsWithSimilarName(String name);
        Task<List<Restaurant>> GetAllRestaurants();
    }
}
