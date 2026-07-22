using FoodDelivery.API.Data;
using FoodDelivery.API.DTOs.Review;
using FoodDelivery.API.Interfaces;
using FoodDelivery.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.API.Services;

public class ReviewService : IReviewService
{
    private readonly FoodDeliveryDbContext _context;
    private readonly ILogger<ReviewService> _logger;

    public ReviewService(
        FoodDeliveryDbContext context,
        ILogger<ReviewService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ReviewResponseDto?> CreateReviewAsync(CreateReviewDto dto)
    {
        var restaurant = await _context.Restaurants.FindAsync(dto.RestaurantId);

        if (restaurant == null)
        {
            return null;
        }

        var review = new Review
        {
            UserName = dto.UserName,
            Rating = dto.Rating,
            Comment = dto.Comment,
            RestaurantId = dto.RestaurantId,
            CreatedAt = DateTime.UtcNow
        };

        _context.Reviews.Add(review);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Review {ReviewId} created successfully for Restaurant {RestaurantId}.",
            review.Id,
            review.RestaurantId);

        return new ReviewResponseDto
        {
            Id = review.Id,
            UserName = review.UserName,
            Rating = review.Rating,
            Comment = review.Comment,
            CreatedAt = review.CreatedAt,
            RestaurantId = review.RestaurantId
        };
    }

    public async Task<IEnumerable<ReviewResponseDto>> GetAllReviewsAsync()
    {
        var reviews = await _context.Reviews.ToListAsync();

        return reviews.Select(review => new ReviewResponseDto
        {
            Id = review.Id,
            UserName = review.UserName,
            Rating = review.Rating,
            Comment = review.Comment,
            CreatedAt = review.CreatedAt,
            RestaurantId = review.RestaurantId
        });
    }

    public async Task<ReviewResponseDto?> GetReviewByIdAsync(int id)
    {
        var review = await _context.Reviews.FindAsync(id);

        if (review == null)
        {
            return null;
        }

        return new ReviewResponseDto
        {
            Id = review.Id,
            UserName = review.UserName,
            Rating = review.Rating,
            Comment = review.Comment,
            CreatedAt = review.CreatedAt,
            RestaurantId = review.RestaurantId
        };
    }

    public async Task<ReviewResponseDto?> UpdateReviewAsync(int id, UpdateReviewDto dto)
    {
        var review = await _context.Reviews.FindAsync(id);

        if (review == null)
        {
            return null;
        }

        review.Rating = dto.Rating;
        review.Comment = dto.Comment;

        await _context.SaveChangesAsync();

        _logger.LogInformation("Review {ReviewId} updated successfully.",review.Id);

        return new ReviewResponseDto
        {
            Id = review.Id,
            UserName = review.UserName,
            Rating = review.Rating,
            Comment = review.Comment,
            CreatedAt = review.CreatedAt,
            RestaurantId = review.RestaurantId
        };
    }

    public async Task<bool> DeleteReviewAsync(int id)
    {
        var review = await _context.Reviews.FindAsync(id);

        if (review == null)
        {
            return false;
        }

        _context.Reviews.Remove(review);

        await _context.SaveChangesAsync();

        _logger.LogInformation("Review {ReviewId} deleted successfully.",review.Id);

        return true;
    }
}