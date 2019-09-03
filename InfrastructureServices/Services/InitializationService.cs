using Infrastructure.Interfaces;
using InfrastructureServices.Context;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureServices.Services
{
    public class InitializationService : IInitializationService
    {
        private readonly MyContext _context;
        private readonly IClient_Provider _clProvider;
        private readonly IBill_Provider _blProvider;

        public InitializationService(MyContext context, IClient_Provider clProvider, IBill_Provider blProvider)
        {
            _context = context;
            _clProvider = clProvider;
            _blProvider = blProvider;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();

            using (var transaction = _context.Database.BeginTransaction())
            {
                // Инициализация таблицы  Clients
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Clients] ON");
                _context.Clients.RemoveRange(_context.Clients);
                _context.Clients.AddRange(_clProvider.GetClients());
                _context.SaveChanges();
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Clients] OFF");

                // Инициализация таблицы  Bills

                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Bills] ON");
                _context.Bills.RemoveRange(_context.Bills);
                _context.Bills.AddRange(_blProvider.GetBills());
                _context.SaveChanges();
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Bills] OFF");

                transaction.Commit();
            }
        }
    }
}

