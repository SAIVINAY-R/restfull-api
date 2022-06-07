using DemoApp.RequestModels;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_genreService.Get());
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
                return Ok(_genreService.Get(id));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(Genre genre)
        {
            try
            {
                _genreService.Create(genre);
                return Created("~/genres/" + genre.Id, genre);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(Genre genre)
        {
            try
            {
                _genreService.Update(genre);
                return Ok(_genreService.Get(genre.Id));
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

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _genreService.Delete(id);
                return Ok("Sucessfully Deleted");
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
    }
}
