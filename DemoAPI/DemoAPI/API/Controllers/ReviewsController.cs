using DemoApp.Models;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;

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
            catch (System.Exception)
            {

                return NotFound(); 
            }
        }

        [HttpGet("{reviewId:int}")]
        public IActionResult Get(int movieId, int reviewId)
        {
            try
            {
                return Ok(_reviewService.Get(movieId, reviewId));
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Add(int movieID,Review review)
        {
            review.MovieId = movieID;
            try
            {
                _reviewService.Create(review);
                return Created("~/reviews/" + review.Id, review);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{reviewId:int}")]
        public IActionResult Update(int movieId, int reviewId, Review review)
        {
            review.MovieId = movieId;
            review.Id = reviewId;
            try
            {
                _reviewService.Update(review);
                return Ok(_reviewService.Get(review.MovieId,review.Id));
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{reviewId:int}")]
        public IActionResult Delete(int movieId, int reviewId)
        {
            try
            {
                _reviewService.Delete(movieId, reviewId);
                return Ok();
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }
    }
}
