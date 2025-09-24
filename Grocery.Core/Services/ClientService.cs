using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Helpers;

namespace Grocery.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        
        public Client? Get(string email)
        {
            return _clientRepository.Get(email);
        }

        public Client? Get(int id)
        {
            return _clientRepository.Get(id);
        }

        public List<Client> GetAll()
        {
            List<Client> clients = _clientRepository.GetAll();
            return clients;
        }

        public Client? Add(string email,string rawPassword, string? name = null)
        {
            string hash = PasswordHelper.HashPassword(rawPassword);
            if (Get(email) != null)
                throw new InvalidOperationException("Dit e-mailadres is al geregistreerd.");
            var client = new Client(
                id: 0,
                name: string.IsNullOrWhiteSpace(name) ? "Anoniem" : name,
                emailAddress: email,
                password: hash
            );
            _clientRepository.Add(client);
            return client;
        }
    }
}
