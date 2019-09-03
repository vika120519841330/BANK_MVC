using Infrastructure.Interfaces;
using Infrastructure.Models;
using InfrastructureServices.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureServices.Repositories
{
    public class Client_Repository : IClient_Repository
    {
        private readonly MyContext context;
        public Client_Repository(MyContext _context)
        {
            //this.context = new ApplicationDbContext
            this.context = _context;
        }
        public IList<Client_InfraModel> GetAllCl()
        {
            var clients = context.Clients
                  .ToList()
                  ;
            return clients;
        }
        public Client_InfraModel GetCl(int id)
        {
            var client = context.Clients
                //.Include(_=>_.BillsOfClient.Select(t => t.BillNumber))
                .FirstOrDefault(_ => _.Id == id)
                ;
            return client;
        }

        public void CreateCl(Client_InfraModel inst)
        {
            context.Clients.Add(inst);
            context.SaveChanges();
        }

        public void UpdateCl(Client_InfraModel inst)
        {
            context.Entry(inst).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteCl(int id)
        {
            var tmp = context.Clients.Find(id);
            context.Clients.Remove(tmp);
            context.SaveChanges();
        }
    }
}
