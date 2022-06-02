using DemoApp.Models;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_movieService.Get(id));
            }
            catch (Exception)
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
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(Movie movie)
        {
            try
            {
                _movieService.Update(movie);
                return Ok(_movieService.Get(movie.Id));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
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
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}
