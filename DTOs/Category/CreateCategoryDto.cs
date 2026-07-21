using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.API.DTOs.Category;

public class CreateCategoryDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(300)]
    public string? Description { get; set; }

    [Required]
    public int RestaurantId { get; set; }
}
