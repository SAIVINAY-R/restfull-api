using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("movies/{movieId}/[controller]")]
    public class ReviewsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                id = 1,
                name = "Review 1"
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int ID)
        {
            return Ok(new
            {
                id = ID,
                name = "Review " + ID
            });
        }

        [HttpPost]
        public IActionResult Add()
        {
            return Created("~/movies/{movieId}/reviews/", new { id = 1, name = "review 1" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int ID)
        {
            return Ok(new { id = ID, name = "Updated Review " + ID });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int ID)
        {
            return Ok(new { id = ID, name = "Review " + ID });
        }
    }
}
