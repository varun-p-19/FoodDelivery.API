using FoodDelivery.API.Data;
using FoodDelivery.API.DTOs.Category;
using FoodDelivery.API.Interfaces;
using FoodDelivery.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.API.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly FoodDeliveryDbContext _context;
        private ILogger<CategoryService> _logger;
        public CategoryService(FoodDeliveryDbContext context, ILogger<CategoryService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<CategoryResponseDto> CreateCategoryAsync(CreateCategoryDto dto)
        {
            var restaurant = await _context.Restaurants
                .FindAsync(dto.RestaurantId);

            if (restaurant == null)
            {
                throw new KeyNotFoundException("Restaurant not found.");
            }

            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description,
                RestaurantId = dto.RestaurantId
            };

            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Category {CategoryId} created for Restaurant {RestaurantId}",
                category.Id,
                category.RestaurantId);

            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                RestaurantId = category.RestaurantId
            };
        }

    }
}
