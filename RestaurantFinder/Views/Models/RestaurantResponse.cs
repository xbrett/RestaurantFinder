using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RestaurantFinder.Views.Models
{
    [DataContract]
    public class RestaurantResponse
    {
        public RestaurantResponse(List<Restaurant> restaurants)
        {
            Restaurants = restaurants ?? throw new ArgumentNullException(nameof(restaurants));
        }

        public RestaurantResponse(Restaurant restaurant) : this(new List<Restaurant> { restaurant })
        {
            if (restaurant == null) throw new ArgumentNullException(nameof(restaurant));
        }

        [DataMember(Name = "restaurants")]
        public List<Restaurant> Restaurants { get; }
    }
}
