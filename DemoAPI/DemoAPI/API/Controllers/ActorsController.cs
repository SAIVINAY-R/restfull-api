using DemoApp.RequestModels;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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
                return Ok(_actorService.Get(id));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
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
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(Actor actor)
        {
            try
            {
                _actorService.Update(actor);
                return Ok(_actorService.Get(actor.Id));
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
                _actorService.Delete(id);
                return Ok("Sucessfully Deleted");
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
    }
}
