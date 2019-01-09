using System;

namespace RestaurantFinder.Logic.Converters
{
    public class RestaurantLogicConverter : IRestaurantLogicConverter
    {
        public Models.Restaurant ConvertToLogicRestaurant(Data.Models.Restaurant restaurant)
        {
            if (restaurant == null) throw new ArgumentNullException(nameof(restaurant));

            return new Models.Restaurant
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Url = restaurant.Url,
                PhoneNumber = restaurant.PhoneNumber
            };
        }
    }
}
