using System;
using System.Threading.Tasks;

namespace RestaurantFinder.Controllers
{
    public interface IController<T>
    {
        Task<T> GetRestaurants();
    }
}
