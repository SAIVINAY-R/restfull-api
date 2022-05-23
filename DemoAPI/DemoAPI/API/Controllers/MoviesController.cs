using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                id = 1,
                name = "Movie 1"
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int ID)
        {
            return Ok(new
            {
                id = ID,
                name = "Movie " + ID
            });
        }

        [HttpPost]
        public IActionResult Add()
        {
            return Created("~/movies/", new { id = 1, name = "Movie 1" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int ID)
        {
            return Ok(new { id = ID, name = "Updated Movie " + ID });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int ID)
        {
            return Ok(new { id = ID, name = "Movie " + ID });
        }
    }
}
