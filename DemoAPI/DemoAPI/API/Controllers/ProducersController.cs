using DemoApp.RequestModels;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducersController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_producerService.Get());
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
                return Ok(_producerService.Get(id));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(Producer producer)
        {
            try
            {
                _producerService.Create(producer);
                return Created("~/producers/" + producer.Id, producer);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(Producer producer)
        {
            try
            {
                _producerService.Update(producer);
                return Ok(_producerService.Get(producer.Id));
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
                _producerService.Delete(id);
                return Ok("Sucessfully Deleted");
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
    }
}
