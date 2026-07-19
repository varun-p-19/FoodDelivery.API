using FoodDelivery.API.DTOs.Restaurant;
using FoodDelivery.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }
    [HttpPost]
    public async Task<ActionResult<RestaurantResponseDto>> CreateRestaurant(CreateRestaurantDto dto)
    {
        var restaurant = await _restaurantService.CreateRestaurantAsync(dto);

        return CreatedAtAction(
            nameof(GetRestaurantById),
            new { id = restaurant.Id },
            restaurant);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<RestaurantResponseDto>> GetRestaurantById(int id)
    {
        var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);

        if (restaurant == null)
        {
            return NotFound();
        }

        return Ok(restaurant);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RestaurantResponseDto>>> GetAllRestaurants()
    {
        var restaurants = await _restaurantService.GetAllRestaurantsAsync();

        return Ok(restaurants);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<RestaurantResponseDto>> UpdateRestaurant(int id, UpdateRestaurantDto dto)
    {
        var restaurant = await _restaurantService.UpdateRestaurantAsync(id, dto);

        if (restaurant == null)
        {
            return NotFound();
        }

        return Ok(restaurant);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant(int id)
    {
        var deleted = await _restaurantService.DeleteRestaurantAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}