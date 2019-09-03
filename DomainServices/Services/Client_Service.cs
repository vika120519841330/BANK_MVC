using Domain.Interfaces;
using Domain.Models;
using DomainServices.Mappers;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Services
{
    public class Client_Service : IClient
    {
        private readonly IClient_Repository clientRepository;
        public Client_Service(IClient_Repository _clientRepository)
        {
            this.clientRepository = _clientRepository;
        }
        public IList<Client_DomainModel> GetAll()
        {
            return clientRepository.GetAllCl()
                .Select(_ => _.ClientFromInfraToDomain())
                .ToList();
        }

        public Client_DomainModel Get(int id)
        {
            var temp = clientRepository.GetCl(id).ClientFromInfraToDomain();
            return temp;
        }

        public void Create(Client_DomainModel inst)
        {
            clientRepository.CreateCl(inst.ClientFromDomainToInfra());
        }

        public void Update(Client_DomainModel inst)
        {
            clientRepository.UpdateCl(inst.ClientFromDomainToInfra());
        }
        public void Delete(int id)
        {
            clientRepository.DeleteCl(id);
        }
    }
}
