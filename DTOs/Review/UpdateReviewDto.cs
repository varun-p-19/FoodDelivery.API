using System.ComponentModel.DataAnnotations; ;
namespace FoodDelivery.API.DTOs.Review
{
    public class UpdateReviewDto
    {
        [Range(1,5)]
        public int Rating { get; set; }
        public string? Comment { get; set; }

    }
}
