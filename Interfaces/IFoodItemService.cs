using FoodDelivery.API.DTOs.FoodItem;

namespace FoodDelivery.API.Interfaces;

public interface IFoodItemService
{
    Task<FoodItemResponseDto?> CreateFoodItemAsync(CreateFoodItemDto dto);

    Task<IEnumerable<FoodItemResponseDto>> GetAllFoodItemsAsync();

    Task<FoodItemResponseDto?> GetFoodItemByIdAsync(int id);

    Task<FoodItemResponseDto?> UpdateFoodItemAsync(int id, UpdateFoodItemDto dto);

    Task<bool> DeleteFoodItemAsync(int id);
}