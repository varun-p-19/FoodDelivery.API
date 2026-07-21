using FoodDelivery.API.DTOs.Category;
using FoodDelivery.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpPost]
    public async Task<ActionResult<CategoryResponseDto>> CreateCategory(CreateCategoryDto dto)
    {
        var category = await _categoryService.CreateCategoryAsync(dto);

        if (category == null)
        {
            return NotFound("Restaurant not found.");
        }

        return CreatedAtAction(
            nameof(GetCategoryById),
            new { id = category.Id },
            category);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryResponseDto>> GetCategoryById(int id)
    {
        return Ok();
    }
}