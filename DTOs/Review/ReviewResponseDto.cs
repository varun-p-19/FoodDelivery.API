namespace FoodDelivery.API.DTOs.Review
{
    public class ReviewResponseDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RestaurantId { get; set; }


    }
}
