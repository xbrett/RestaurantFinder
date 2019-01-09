using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantFinder.Data.Models;

namespace RestaurantFinder.Data
{
    public interface IRestaurantDataAccess
    {
        Task<Restaurant> GetRestaurant(int id);
        Task<List<Restaurant>> GetRestaurantsWithSimilarName(String name);
        Task<List<Restaurant>> GetAllRestaurants();
    }
}
