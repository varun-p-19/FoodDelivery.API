namespace FoodDelivery.API.DTOs.Category;

public class CategoryResponseDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int RestaurantId { get; set; }
}