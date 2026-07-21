using FoodDelivery.API.DTOs.Category;
namespace FoodDelivery.API.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto> CreateCategoryAsync(CreateCategoryDto dto);

        Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync();

        Task<CategoryResponseDto?> GetCategoryByIdAsync(int id);

        Task<CategoryResponseDto?> UpdateCategoryAsync(int id, UpdateCategoryDto dto);

        Task<bool> DeleteCategoryAsync(int id);
    }
}
