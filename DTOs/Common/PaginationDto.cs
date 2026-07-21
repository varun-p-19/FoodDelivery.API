using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.API.DTOs.Common;

public class PaginationDto
{
    [Range(1, int.MaxValue)]
    public int PageNumber { get; set; } = 1;

    [Range(1, 100)]
    public int PageSize { get; set; } = 10;

    public string? Search { get; set; }

    public string? SortBy { get; set; }

    public bool Descending { get; set; }

    public decimal? MinRating { get; set; }

    public decimal? MaxRating { get; set; }

    public string? City { get; set; }
}