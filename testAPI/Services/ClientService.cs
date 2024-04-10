using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using testAPI.IServices;
using testAPI.Models;

namespace testAPI.Services
{
    public class ClientService : IClientService
    {
        readonly ExoDbContext _context;
        public ClientService(ExoDbContext context)
        {
            this._context = context;
        }

        public async Task<Client> Get(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            return client;
        }

        public async Task<List<Client>> Get(string name)
        {
            if (name.IsNullOrEmpty() || name.Contains('/'))
            {
                throw new ArgumentException("Name not valid");
            }
            var client = await _context.Clients.Where(c => c.FirstName.ToLower() == name.ToLower()).ToListAsync();
            if (client == null)
            {
                throw new KeyNotFoundException($"Client not found with name : {name}");
            }
            return client;
        }

        public async Task<List<Client>> GetAll()
        {
            var client = await _context.Clients.ToListAsync();
            return client;
        }
        public async Task<Client> Create(string firstName, string lastName)
        {

            if (firstName.IsNullOrEmpty() || lastName.IsNullOrEmpty())
            {
                
                throw new ArgumentException("Name not valid");
            }
            else
            {
                Client c = new Client() { FirstName = firstName, LastName = lastName };
                await _context.Clients.AddAsync(c);
                await _context.SaveChangesAsync();
                return c;
            }
        }
        public async Task<Client> Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                throw new Exception("Client not found");
            }
            else
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
            return client;
        }
    }
}
