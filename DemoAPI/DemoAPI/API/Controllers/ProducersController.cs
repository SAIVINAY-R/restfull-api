using DemoApp.Models;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;

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
                return Ok(_producerService.Get(id));
            }
            catch (System.Exception)
            {

                return NotFound();
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
            catch (System.Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Producer producer)
        {
            producer.Id = id;
            try
            {
                _producerService.Update(producer);
                return Ok(_producerService.Get(producer.Id));
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
                _producerService.Delete(id);
                return Ok();
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }
    }
}
