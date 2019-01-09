using System.Data;
using RestaurantFinder.Data.Models;

namespace RestaurantFinder.Data.Converters
{
    public interface IRestaurantDataConverter
    {
        Restaurant ConvertToRestaurantData(IDataReader dataReader);
    }
}
