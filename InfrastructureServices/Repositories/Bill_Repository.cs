using Infrastructure.Interfaces;
using Infrastructure.Models;
using InfrastructureServices.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace InfrastructureServices.Repositories
{
    public class Bill_Repository : IBill_Repository
    {
        private readonly MyContext context;
        public Bill_Repository(MyContext _context)
        {
            //this.context = new MyContext();
            this.context = _context;
        }
        public IList<Bill_InfraModel> GetAllBills()
        {
            var bills = context.Bills
                .ToList()
                ;
            return bills;
        }

        public Bill_InfraModel GetBill(int id)
        {
            var bill = context.Bills
                .FirstOrDefault(_ => _.Id == id)
                ;
            return bill;
        }

        public void CreateBill(Bill_InfraModel inst)
        {
            context.Bills.Add(inst);
            context.SaveChanges();
        }

        public void UpdateBill(Bill_InfraModel inst)
        {
            //context.Entry(inst).State = EntityState.Modified;
            var tempInst = context.Bills.FirstOrDefault(_ => _.Id == inst.Id);
            //tempInst = inst;
            tempInst.Id = inst.Id;
            tempInst.BillBalance = inst.BillBalance;
            tempInst.BillNumber = inst.BillNumber;
            tempInst.Client_InfraModelId = inst.Client_InfraModelId;
            context.SaveChanges();
        }
        public void DeleteBill(int id)
        {
            var tmp = context.Bills.Find(id);
            context.Bills.Remove(tmp);
            context.SaveChanges();
        }
    }
}
