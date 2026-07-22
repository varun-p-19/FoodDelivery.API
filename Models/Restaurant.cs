using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.API.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
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
        public string PhoneNo { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Category> Categories { get; set; }= new List<Category>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
