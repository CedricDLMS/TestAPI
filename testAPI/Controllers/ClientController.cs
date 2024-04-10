using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.IServices;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        readonly ExoDbContext _context;
        readonly IClientService _clientService;
        public ClientController(ExoDbContext context, IClientService clientService)
        {
            this._context = context;
            this._clientService = clientService;
        }

        // GET BY ID 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var c = await _clientService.Get(id);
            if (c == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(await _clientService.Get(id));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var c = await _clientService.Get(name);
                return Ok(c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var c = await _context.Clients.ToListAsync<Client>();
            return Ok(c);
        }
        [HttpPost]

        public async Task<IActionResult> Create(string firstName, string lastName)
        {
            var c = await _clientService.Create(firstName, lastName);
            return Ok(c);
        }
        // Delete

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clientService.Delete(id);
                return Ok("Client supprimé avec succés");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
