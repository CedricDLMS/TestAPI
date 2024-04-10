using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testAPI.IServices;
using testAPI.Models;
using testAPI.Services;

namespace testAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExoRouteController : ControllerBase
    {
        readonly IRandomService randomService;
        public ExoRouteController(IRandomService randomService)
        {
            this.randomService = randomService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello world");
        }
        
        [HttpGet]
        public IActionResult Get999()
        {

            return StatusCode(999);
        }
        [HttpGet]
        public IActionResult GetImage()
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "ERREUR.jpg");
            var imageFileStream = System.IO.File.OpenRead(imagePath);
            return File(imageFileStream, "image/jpeg");
        }
        [HttpGet("{name}")]
        public IActionResult GetName(string name)
        {
            return Ok("Hello " + name);
        }
        [HttpGet("{firstName} {lastName}")]
        public IActionResult GetFullName(string firstName, string lastName)
        {
            return Ok($"Hello {firstName} {lastName}");
        }
        [HttpPost]
        public IActionResult Post(Client client)
        {
            return Ok($"Hello {client.FirstName} {client.LastName}");
        }
        [HttpGet]
        public IActionResult GetRandom(int min, int max)
        {
            return Ok("Voila le nombre tiré" + randomService.GetRandom(min, max));
        }
    }
}
