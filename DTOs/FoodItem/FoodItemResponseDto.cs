namespace FoodDelivery.API.DTOs.FoodItem;

public class FoodItemResponseDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsAvailable { get; set; }

    public int CategoryId { get; set; }
}