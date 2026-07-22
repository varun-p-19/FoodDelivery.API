using FoodDelivery.API.DTOs.Review;

namespace FoodDelivery.API.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewResponseDto?> CreateReviewAsync(CreateReviewDto dto);
        Task<ReviewResponseDto?> UpdateReviewAsync(int id,UpdateReviewDto dto);
        Task<IEnumerable<ReviewResponseDto>> GetAllReviewsAsync();
        Task<bool> DeleteReviewAsync(int id);
        Task<ReviewResponseDto?> GetReviewByIdAsync(int id);

    }
}
