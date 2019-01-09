using System;

namespace RestaurantFinder.Data.Models
{
    public class Restaurant
    {
        public Restaurant(int id, String name, String url, String phoneNumber)
        {
            if (id < 0)
            {
                throw new ArgumentException($"{0} must be a natural number", nameof(id));
            }
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{0} must not be null or whitespace", nameof(name));
            }

            Id = id;
            Name = name;
            Url = url;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; }
        public String Name { get; }
        public String Url { get; }
        public String PhoneNumber { get; }
    }
}
