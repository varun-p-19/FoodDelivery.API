using FoodDelivery.API.DTOs.FoodItem;
using FoodDelivery.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodItemController : ControllerBase
{
    private readonly IFoodItemService _foodItemService;

    public FoodItemController(IFoodItemService foodItemService)
    {
        _foodItemService = foodItemService;
    }

    [HttpPost]
    public async Task<ActionResult<FoodItemResponseDto>> CreateFoodItem(CreateFoodItemDto dto)
    {
        var foodItem = await _foodItemService.CreateFoodItemAsync(dto);

        if (foodItem == null)
        {
            return NotFound("Category not found.");
        }

        return CreatedAtAction(
            nameof(GetFoodItemById),
            new { id = foodItem.Id },
            foodItem);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodItemResponseDto>>> GetAllFoodItems()
    {
        var foodItems = await _foodItemService.GetAllFoodItemsAsync();

        return Ok(foodItems);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FoodItemResponseDto>> GetFoodItemById(int id)
    {
        var foodItem = await _foodItemService.GetFoodItemByIdAsync(id);

        if (foodItem == null)
        {
            return NotFound();
        }

        return Ok(foodItem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<FoodItemResponseDto>> UpdateFoodItem(
        int id,
        UpdateFoodItemDto dto)
    {
        var foodItem = await _foodItemService.UpdateFoodItemAsync(id, dto);

        if (foodItem == null)
        {
            return NotFound();
        }

        return Ok(foodItem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFoodItem(int id)
    {
        var deleted = await _foodItemService.DeleteFoodItemAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}