using DemoApp.RequestModels;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("movies/{movieId}/[controller]")]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult Get(int movieId)
        {
            try
            {
                return Ok(_reviewService.Get(movieId));
            }
            catch(Exception e)
            { 
                return NotFound(e.Message); 
            }
        }

        [HttpGet("{reviewId:int}")]
        public IActionResult Get(int movieId, int reviewId)
        {
            try
            {
                return Ok(_reviewService.Get(movieId, reviewId));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(Review review)
        {
            try
            {
                _reviewService.Create(review);
                return Created("~/reviews/" + review.Id, review);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{reviewId:int}")]
        public IActionResult Update(Review review)
        {
            try
            {
                _reviewService.Update(review);
                return Ok(_reviewService.Get(review.MovieId,review.Id));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{reviewId:int}")]
        public IActionResult Delete(int movieId, int reviewId)
        {
            try
            {
                _reviewService.Delete(movieId, reviewId);
                return Ok("Sucessfully Deleted");
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
    }
}
