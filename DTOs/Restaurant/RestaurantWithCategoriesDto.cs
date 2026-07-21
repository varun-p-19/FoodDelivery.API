using FoodDelivery.API.DTOs.Category;

namespace FoodDelivery.API.DTOs.Restaurant;

public class RestaurantWithCategoriesDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Address { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public decimal Rating { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public List<CategoryResponseDto> Categories { get; set; }= new();
}