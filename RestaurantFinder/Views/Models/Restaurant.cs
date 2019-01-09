using System;
using System.Runtime.Serialization;

namespace RestaurantFinder.Views.Models
{
    [DataContract]
    public class Restaurant
    {
        [DataMember(Name = "id")]
        public int Id { get; }

        [DataMember(Name = "name")]
        public String Name { get; }

        [DataMember(Name = "url")]
        public String Url { get; }

        [DataMember(Name = "phone_number")]
        public String PhoneNumber { get; }

        public Restaurant(int id, String name, String url, String phoneNumber)
        {
            if (id < 0)
            { 
                throw new ArgumentException($"{0} must be a natural number", nameof(id)); 
            }
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{0} must not be null or contain only whitespace", nameof(name));
            }

            Id = id;
            Name = name;
            Url = url ?? throw new ArgumentNullException(nameof(url));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        }
    }
}
