using FoodDelivery.API.DTOs.Restaurant;

namespace FoodDelivery.API.Interfaces
{
    public interface IRestaurantService
    {
        Task<RestaurantResponseDto> CreateRestaurantAsync(CreateRestaurantDto dto);
        Task<IEnumerable<RestaurantResponseDto>> GetAllRestaurantsAsync();
        Task<RestaurantResponseDto?> GetRestaurantByIdAsync(int id);
        Task<RestaurantResponseDto?> UpdateRestaurantAsync(int id, UpdateRestaurantDto dto);


    }
}
