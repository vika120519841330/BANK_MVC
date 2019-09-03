using Infrastructure.Interfaces;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureServices.Repositories
{
    public class FakeRepository : IBill_Repository, IClient_Repository, IBill_Provider, IClient_Provider
    {
        public Bill_InfraModel b1, b2, b3;
        public static List<Bill_InfraModel> DB_Bills = new List<Bill_InfraModel>();

        public Client_InfraModel c1, c2;
        public static List<Client_InfraModel> DB_Clients = new List<Client_InfraModel>();

        public FakeRepository()
        {
            // Инициализация клиентов
            #region
            c1 = new Client_InfraModel
            {
                Id = 1,
                ClientTitle = "Иванов Иван Иванович",
                ClientMarkJuridical = false,
                ClientPhone = "+375-44-458-77-33",
                ClientEMail = "12google@com",
                ClientTaxpayNum = "MP1234145"
            };
            DB_Clients.Add(c1);
            c2 = new Client_InfraModel
            {
                Id = 2,
                ClientTitle = "Модная Галактика",
                ClientMarkJuridical = true,
                ClientPhone = "+375-33-345-99-36",
                ClientEMail = "zhzh6@tut.by",
                ClientTaxpayNum = "127124783"
            };
            DB_Clients.Add(c2);
            #endregion

            // Инициализация р/с
            #region
            b1 = new Bill_InfraModel
            {
                Id = 1,
                BillBalance = 120,
                BillNumber = "12345611111112225841",
                Client_InfraModelId = 1,
                ClientOwnerOfBill = c1

            };
            DB_Bills.Add(b1);
            b2 = new Bill_InfraModel
            {
                Id = 2,
                BillBalance = 158880,
                BillNumber = "12345612345678921782",
                Client_InfraModelId = 2,
                ClientOwnerOfBill = c2
            };
            DB_Bills.Add(b2);
            b3 = new Bill_InfraModel
            {
                Id = 3,
                BillBalance = 1100,
                BillNumber = "12345125874563216783",
                Client_InfraModelId = 2,
                ClientOwnerOfBill = c2
            };
            DB_Bills.Add(b3);
            #endregion
        }

        public IList<Client_InfraModel> GetAllCl()
        {
            return DB_Clients;
        }

        public IList<Bill_InfraModel> GetAllBills()
        {
            return DB_Bills;
        }
        public Client_InfraModel GetCl(int id)
        {
            var temp = DB_Clients.FirstOrDefault(_ => _.Id == id);
            return temp;
        }
        public Bill_InfraModel GetBill(int id)
        {
            var temp = DB_Bills.FirstOrDefault(_ => _.Id == id);
            return temp;
        }

        public void CreateCl(Client_InfraModel inst)
        {
            DB_Clients.Add(inst);
        }

        public void CreateBill(Bill_InfraModel inst)
        {
            DB_Bills.Add(inst);
        }

        public void UpdateCl(Client_InfraModel inst)
        {
            var temp = DB_Clients.FirstOrDefault(_ => _.Id == inst.Id);
            temp = inst;
        }
        public void UpdateBill(Bill_InfraModel inst)
        {
            var temp = DB_Bills.FirstOrDefault(_ => _.Id == inst.Id);
            temp = inst;
        }
        public void DeleteCl(int id)
        {
            var temp = DB_Clients.FirstOrDefault(_ => _.Id == id);
            DB_Clients.Remove(temp);
        }
        public void DeleteBill(int id)
        {
            var temp = DB_Bills.FirstOrDefault(_ => _.Id == id);
            DB_Bills.Remove(temp);
        }
       
        public IList<Client_InfraModel> GetClients()
        {
            return DB_Clients.ToList();
        }
        public IList<Bill_InfraModel> GetBills()
        {
            return DB_Bills.ToList();
        }
    }
}
