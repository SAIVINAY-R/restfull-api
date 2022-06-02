using DemoApp.Models;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_movieService.Get());
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_movieService.Get(id));
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            try
            {
                _movieService.Create(movie);
                return Created("~/actors/" + movie.Id, movie);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Movie movie)
        {
            movie.Id = id;
            try
            {
                _movieService.Update(movie);
                return Ok(_movieService.Get(movie.Id));
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _movieService.Delete(id);
                return Ok();
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }
    }
}
