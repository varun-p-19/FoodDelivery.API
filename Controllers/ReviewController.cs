using FoodDelivery.API.DTOs.Review;
using FoodDelivery.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpPost]
    public async Task<ActionResult<ReviewResponseDto>> CreateReview(CreateReviewDto dto)
    {
        var review = await _reviewService.CreateReviewAsync(dto);

        if (review == null)
        {
            return NotFound("Restaurant not found.");
        }

        return CreatedAtAction(
            nameof(GetReviewById),
            new { id = review.Id },
            review);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReviewResponseDto>>> GetAllReviews()
    {
        var reviews = await _reviewService.GetAllReviewsAsync();

        return Ok(reviews);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewResponseDto>> GetReviewById(int id)
    {
        var review = await _reviewService.GetReviewByIdAsync(id);

        if (review == null)
        {
            return NotFound();
        }

        return Ok(review);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReviewResponseDto>> UpdateReview(
        int id,
        UpdateReviewDto dto)
    {
        var review = await _reviewService.UpdateReviewAsync(id, dto);

        if (review == null)
        {
            return NotFound();
        }

        return Ok(review);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
        var deleted = await _reviewService.DeleteReviewAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}