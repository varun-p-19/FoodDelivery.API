using FoodDelivery.API.Data;
using FoodDelivery.API.DTOs.FoodItem;
using FoodDelivery.API.Interfaces;
using FoodDelivery.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.API.Services;

public class FoodItemService : IFoodItemService
{
    private readonly FoodDeliveryDbContext _context;
    private readonly ILogger<FoodItemService> _logger;

    public FoodItemService(
        FoodDeliveryDbContext context,
        ILogger<FoodItemService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<FoodItemResponseDto?> CreateFoodItemAsync(CreateFoodItemDto dto)
    {
        var category = await _context.Categories.FindAsync(dto.CategoryId);

        if (category == null)
        {
            return null;
        }

        var foodItem = new FoodItem
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            ImageUrl = dto.ImageUrl,
            IsAvailable = dto.IsAvailable,
            CategoryId = dto.CategoryId
        };

        _context.FoodItems.Add(foodItem);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Food Item {FoodItemId} created successfully.",
            foodItem.Id);

        return new FoodItemResponseDto
        {
            Id = foodItem.Id,
            Name = foodItem.Name,
            Description = foodItem.Description,
            Price = foodItem.Price,
            ImageUrl = foodItem.ImageUrl,
            IsAvailable = foodItem.IsAvailable,
            CategoryId = foodItem.CategoryId
        };
    }

    public async Task<IEnumerable<FoodItemResponseDto>> GetAllFoodItemsAsync()
    {
        var foodItems = await _context.FoodItems.ToListAsync();

        return foodItems.Select(foodItem => new FoodItemResponseDto
        {
            Id = foodItem.Id,
            Name = foodItem.Name,
            Description = foodItem.Description,
            Price = foodItem.Price,
            ImageUrl = foodItem.ImageUrl,
            IsAvailable = foodItem.IsAvailable,
            CategoryId = foodItem.CategoryId
        });
    }

    public async Task<FoodItemResponseDto?> GetFoodItemByIdAsync(int id)
    {
        var foodItem = await _context.FoodItems.FindAsync(id);

        if (foodItem == null)
        {
            return null;
        }

        return new FoodItemResponseDto
        {
            Id = foodItem.Id,
            Name = foodItem.Name,
            Description = foodItem.Description,
            Price = foodItem.Price,
            ImageUrl = foodItem.ImageUrl,
            IsAvailable = foodItem.IsAvailable,
            CategoryId = foodItem.CategoryId
        };
    }

    public async Task<FoodItemResponseDto?> UpdateFoodItemAsync(int id, UpdateFoodItemDto dto)
    {
        var foodItem = await _context.FoodItems.FindAsync(id);

        if (foodItem == null)
        {
            return null;
        }

        foodItem.Name = dto.Name;
        foodItem.Description = dto.Description;
        foodItem.Price = dto.Price;
        foodItem.ImageUrl = dto.ImageUrl;
        foodItem.IsAvailable = dto.IsAvailable;

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Food Item {FoodItemId} updated successfully.",
            foodItem.Id);

        return new FoodItemResponseDto
        {
            Id = foodItem.Id,
            Name = foodItem.Name,
            Description = foodItem.Description,
            Price = foodItem.Price,
            ImageUrl = foodItem.ImageUrl,
            IsAvailable = foodItem.IsAvailable,
            CategoryId = foodItem.CategoryId
        };
    }

    public async Task<bool> DeleteFoodItemAsync(int id)
    {
        var foodItem = await _context.FoodItems.FindAsync(id);

        if (foodItem == null)
        {
            return false;
        }

        _context.FoodItems.Remove(foodItem);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Food Item {FoodItemId} deleted successfully.",
            foodItem.Id);

        return true;
    }
}