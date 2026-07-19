using System.ComponentModel.DataAnnotations;
namespace FoodDelivery.API.DTOs.Restaurant
{
    public class CreateRestaurantDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Range(0, 5)]
        public decimal Rating { get; set; }

        [Required]
        public TimeOnly OpeningTime { get; set; }
        [Required]
        public TimeOnly ClosingTime { get; set; }
        [Url]
        public string? ImageUrl { get; set; }


    }
}
