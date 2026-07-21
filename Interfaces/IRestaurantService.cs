using FoodDelivery.API.DTOs.Common;
using FoodDelivery.API.DTOs.Restaurant;

namespace FoodDelivery.API.Interfaces
{
    public interface IRestaurantService
    {
        Task<RestaurantResponseDto> CreateRestaurantAsync(CreateRestaurantDto dto);
        Task<IEnumerable<RestaurantResponseDto>>GetAllRestaurantsAsync(PaginationDto pagination);
        Task<RestaurantResponseDto?> GetRestaurantByIdAsync(int id);
        Task<RestaurantResponseDto?> UpdateRestaurantAsync(int id, UpdateRestaurantDto dto);
        Task<bool> DeleteRestaurantAsync(int id);
        Task<RestaurantWithCategoriesDto?> GetRestaurantWithCategoriesAsync(int id);


    }
}
