using DemoApp.Models;
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
            try
            {
                return Ok(_actorService.Get());
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
                return Ok(_actorService.Get(id));
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Add(Actor actor)
        {
            try
            {
                _actorService.Create(actor);
                return Created("~/actors/" + actor.Id, actor);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id,Actor actor)
        {
            actor.Id = id;
            try
            {
                _actorService.Update(actor);
                return Ok(_actorService.Get(actor.Id));
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
                _actorService.Delete(id);
                return Ok();
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }
    }
}
