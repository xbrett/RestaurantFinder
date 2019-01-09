using System;
using System.Data;
using RestaurantFinder.Data.Models;

namespace RestaurantFinder.Data.Converters
{
    public class RestaurantDataConverter : IRestaurantDataConverter
    {
        public Restaurant ConvertToRestaurantData(IDataReader dataReader)
        {
            if (dataReader == null) throw new ArgumentNullException(nameof(dataReader));

            throw new NotImplementedException();
        }
    }
}
