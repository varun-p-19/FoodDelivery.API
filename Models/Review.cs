using System.ComponentModel.DataAnnotations;
namespace FoodDelivery.API.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; } = string.Empty;
        [Range(1,5)]
        public int Rating { get; set; }
        [MaxLength(500)]
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;

    }
    
}
