using FoodDelivery.API.Data;
using FoodDelivery.API.DTOs.Restaurant;
using FoodDelivery.API.Interfaces;
using FoodDelivery.API.Models;
using Microsoft.EntityFrameworkCore;
namespace FoodDelivery.API.Services;

public class RestaurantService : IRestaurantService
{
    private readonly FoodDeliveryDbContext _context;

    public RestaurantService(FoodDeliveryDbContext context)
    {
        _context = context;
    }

    public async Task<RestaurantResponseDto> CreateRestaurantAsync(CreateRestaurantDto dto)
    {
        var restaurant = new Restaurant
        {
            Name = dto.Name,
            Description = dto.Description,
            Address = dto.Address,
            PhoneNo = dto.PhoneNumber,
            OpeningTime = dto.OpeningTime,
            ClosingTime = dto.ClosingTime,
            ImageUrl = dto.ImageUrl,
            Rating = 0
        };
        _context.Restaurants.Add(restaurant);

        await _context.SaveChangesAsync();
        return new RestaurantResponseDto
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Description = restaurant.Description,
            Address = restaurant.Address,
            PhoneNumber = restaurant.PhoneNo,
            Rating = restaurant.Rating,
            OpeningTime = restaurant.OpeningTime,
            ClosingTime = restaurant.ClosingTime,
            ImageUrl = restaurant.ImageUrl
        };
    }
    public async Task<IEnumerable<RestaurantResponseDto>> GetAllRestaurantsAsync()
    {
        var restaurants = await _context.Restaurants.ToListAsync();

        return restaurants.Select(r => new RestaurantResponseDto
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description,
            Address = r.Address,
            PhoneNumber = r.PhoneNo,
            Rating = r.Rating,
            OpeningTime = r.OpeningTime,
            ClosingTime = r.ClosingTime,
            ImageUrl = r.ImageUrl
        });
    }
    public async Task<RestaurantResponseDto?> GetRestaurantByIdAsync(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);

        if (restaurant == null)
        {
            return null;
        }

        return new RestaurantResponseDto
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Description = restaurant.Description,
            Address = restaurant.Address,
            PhoneNumber = restaurant.PhoneNo,
            Rating = restaurant.Rating,
            OpeningTime = restaurant.OpeningTime,
            ClosingTime = restaurant.ClosingTime,
            ImageUrl = restaurant.ImageUrl
        };
    }
    public async Task<RestaurantResponseDto?> UpdateRestaurantAsync(int id, UpdateRestaurantDto dto)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);

        if (restaurant == null)
        {
            return null;
        }

        restaurant.Name = dto.Name;
        restaurant.Description = dto.Description;
        restaurant.Address = dto.Address;
        restaurant.PhoneNo = dto.PhoneNumber;
        restaurant.Rating = dto.Rating;
        restaurant.OpeningTime = dto.OpeningTime;
        restaurant.ClosingTime = dto.ClosingTime;
        restaurant.ImageUrl = dto.ImageUrl;

        await _context.SaveChangesAsync();

        return new RestaurantResponseDto
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Description = restaurant.Description,
            Address = restaurant.Address,
            PhoneNumber = restaurant.PhoneNo,
            Rating = restaurant.Rating,
            OpeningTime = restaurant.OpeningTime,
            ClosingTime = restaurant.ClosingTime,
            ImageUrl = restaurant.ImageUrl
        };
    }
    public async Task<bool> DeleteRestaurantAsync(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);

        if (restaurant == null)
        {
            return false;
        }

        _context.Restaurants.Remove(restaurant);

        await _context.SaveChangesAsync();

        return true;
    }
}