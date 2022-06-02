using DemoApp.Models;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;

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
                return Ok(_genreService.Get(id));
            }
            catch (System.Exception)
            {

                return NotFound();
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
            catch (System.Exception)
            {

                return BadRequest();
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
            catch (System.ArgumentNullException)
            {
                return BadRequest();
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
                _genreService.Delete(id);
                return Ok();
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }
    }
}
