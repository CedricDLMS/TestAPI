using Microsoft.AspNetCore.Mvc;
using testAPI.DTOs.Clients;
using testAPI.Models;

namespace testAPI.IServices
{
    public interface IClientService
    {
        public Task<Client> Get(int id);
        public Task<List<Client>> Get(string name);
        public Task<List<ClientDTO>> GetAll();
        public Task<Client> Create(string firstName,string lastName);
        public Task<Client> Delete(int id);
    }
}
