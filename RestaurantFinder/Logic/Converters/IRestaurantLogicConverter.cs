
namespace RestaurantFinder.Logic.Converters
{
    public interface IRestaurantLogicConverter
    {
        Logic.Models.Restaurant ConvertToLogicRestaurant(Data.Models.Restaurant restaurant);
    }
}
