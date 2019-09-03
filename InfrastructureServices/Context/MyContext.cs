using Infrastructure.Models;
using InfrastructureServices.Configurations;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureServices.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<Client_InfraModel> Clients { get; set; }
        public DbSet<Bill_InfraModel> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Client_InfraModel c1 = new Client_InfraModel
            {
                Id = 1,
                ClientTitle = "Иванов Иван Иванович",
                ClientMarkJuridical = false,
                ClientPhone = "+375-44-458-77-33",
                ClientEMail = "12google@com",
                ClientTaxpayNum = "MP1234145"
            };
            Client_InfraModel c2 = new Client_InfraModel
            {
                Id = 2,
                ClientTitle = "Модная Галактика",
                ClientMarkJuridical = true,
                ClientPhone = "+375-33-345-99-36",
                ClientEMail = "zhzh6@tut.by",
                ClientTaxpayNum = "127124783"
            };
            
            Bill_InfraModel b1 = new Bill_InfraModel
            {
                Id = 1,
                BillBalance = 120,
                BillNumber = "12345611111112225841",
                Client_InfraModelId = 1,
                //ClientOwnerOfBill = c1
            };
            Bill_InfraModel b2 = new Bill_InfraModel
            {
                Id = 2,
                BillBalance = 158880,
                BillNumber = "12345612345678921782",
                Client_InfraModelId = 2,
                //ClientOwnerOfBill = c2
            };
            Bill_InfraModel b3 = new Bill_InfraModel
            {
                Id = 3,
                BillBalance = 1100,
                BillNumber = "12345125874563216783",
                Client_InfraModelId = 2,
                //ClientOwnerOfBill = c2
            };

            modelBuilder.Entity<Client_InfraModel>().HasData(c1, c2);
            modelBuilder.Entity<Bill_InfraModel>().HasData(b1, b2, b3);

            modelBuilder.ApplyConfiguration<Client_InfraModel>(new Client_Configuration());
            modelBuilder.ApplyConfiguration<Bill_InfraModel>(new Bill_Configuration());

            base.OnModelCreating(modelBuilder);
        }
    }
}