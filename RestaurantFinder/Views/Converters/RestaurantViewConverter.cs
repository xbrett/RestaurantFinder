using System;
using RestaurantFinder.Logic.Models;
using RestaurantFinder.Views.Models;

namespace RestaurantFinder.Views.Converters
{
    public class RestaurantViewConverter : IRestaurantViewConverter
    {
        public Models.Restaurant ConvertToRestaurantView(Logic.Models.Restaurant restaurant)
        {
            if (restaurant == null) throw new ArgumentNullException(nameof(restaurant));

            return new Models.Restaurant(
                restaurant.Id,
                restaurant.Name,
                restaurant.Url,
                restaurant.PhoneNumber);
        }
    }
}
