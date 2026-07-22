using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.API.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(300)]
    public string? Description { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = null!;
    public ICollection<FoodItem> FoodItems { get; set; }= new List<FoodItem>();
}