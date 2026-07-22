using System.ComponentModel.DataAnnotations;
namespace FoodDelivery.API.DTOs.Review
{
    public class CreateReviewDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Range(1, 5)]
        public int Rating { get; set; }
        [MaxLength(500)]
        public string? Comment { get; set; }
        public int RestaurantId { get; set; }
    }
}
