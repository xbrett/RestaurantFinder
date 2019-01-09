using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantFinder.Data;
using RestaurantFinder.Logic.Converters;
using RestaurantFinder.Logic.Models;
using Serilog;

namespace RestaurantFinder.Logic
{
    public class RestaurantLogic : IRestaurantLogic
    {
        private readonly ILogger _logger;
        private readonly IRestaurantDataAccess _dataAccess;
        private readonly IRestaurantLogicConverter _logicConverter;

        public RestaurantLogic(ILogger logger, IRestaurantDataAccess dataAccess, IRestaurantLogicConverter logicConverter)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
            _logicConverter = logicConverter ?? throw new ArgumentNullException(nameof(logicConverter));
        }

        public async Task<Restaurant> GetRestaurant(int id)
        {
            var restaurants = await _dataAccess.GetRestaurant(id);
            return ConvertToLogicRestaurant(restaurants);
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            List<Data.Models.Restaurant> dataRestaurants = await _dataAccess.GetAllRestaurants();

            foreach (var restaurant in dataRestaurants)
            {
                restaurants.Add(ConvertToLogicRestaurant(restaurant));
            }

            return restaurants;
        }

        public async Task<Restaurant> GetRandomRestaurant()
        {
            Random rand = new Random();
            List<Restaurant> restaurants = await GetAllRestaurants();

            for (int i = 0; i < rand.Next(restaurants.Count); i++)
            {
                restaurants.GetEnumerator().MoveNext();
            }

            return restaurants.GetEnumerator().Current;
        }

        public async Task<List<Restaurant>> GetRestaurantsWithSimilarName(string name)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            List<Data.Models.Restaurant> dataRestaurants = await _dataAccess.GetRestaurantsWithSimilarName(name);

            foreach (var restaurant in dataRestaurants)
            {
                restaurants.Add(ConvertToLogicRestaurant(restaurant));
            }

            return restaurants;
        }

        private Restaurant ConvertToLogicRestaurant(Data.Models.Restaurant restaurant)
        {
            try
            {
                return _logicConverter.ConvertToLogicRestaurant(restaurant);
            }
            //TODO: Catch dataException
            catch (ArgumentNullException ex)
            {
                _logger.Error("Argument null", ex);
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.Error("Error", ex);
                throw ex;
            }
        }
    }
}
