using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducersController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                id = 1,
                name = "Producer 1"
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int ID)
        {
            return Ok(new
            {
                id = ID,
                name = "Producer " + ID
            });
        }

        [HttpPost]
        public IActionResult Add()
        {
            return Created("~/producers/", new { id = 1, name = "Producer 1" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int ID)
        {
            return Ok(new { id = ID, name = "Updated Producer " + ID });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int ID)
        {
            return Ok(new { id = ID, name = "Producer " + ID });
        }
    }
}
