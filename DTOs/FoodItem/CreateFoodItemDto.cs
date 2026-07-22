using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.API.DTOs.FoodItem;

public class CreateFoodItemDto
{
    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [Range(1, 100000)]
    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsAvailable { get; set; } = true;

    [Required]
    public int CategoryId { get; set; }
}