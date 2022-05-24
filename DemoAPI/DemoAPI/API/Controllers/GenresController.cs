using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                id = 1,
                name = "Genre 1"
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int ID)
        {
            return Ok(new
            {
                id = ID,
                name = "Genre " + ID
            });
        }

        [HttpPost]
        public IActionResult Add()
        {
            return Created("~/genres/", new { id = 1, name = "Genre 1" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int ID)
        {
            return Ok(new { id = ID, name = "Updated Genre " + ID });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int ID)
        {
            return Ok(new { id = ID, name = "Genre " + ID });
        }
    }
}
