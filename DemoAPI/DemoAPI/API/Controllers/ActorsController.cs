using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_actorService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int ID)
        {
            return Ok(new
            {
                id = ID,
                name = "Actor " + ID
            });
        }

        [HttpPost]
        public IActionResult Add()
        {
            return Created("~/actors/", new { id = 1, name = "Actor 1" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int ID)
        {
            return Ok(new { id = ID, name = "Updated Actor " + ID });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int ID) 
        { 
            return Ok(new { id = ID, name = "Actor " + ID });
        }
    }
}
