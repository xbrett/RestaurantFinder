using RestaurantFinder.Views.Models;

namespace RestaurantFinder.Views.Converters
{
    public interface IRestaurantViewConverter
    {
        Restaurant ConvertToRestaurantView(Logic.Models.Restaurant restaurant);
    }
}
