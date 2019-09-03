using Domain.Interfaces;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using DomainServices.Mappers;

namespace DomainServices.Services
{
    public class Bill_Service : IBill
    {
        private readonly IBill_Repository billRepository;
        public Bill_Service(IBill_Repository _billRepository)
        {
            this.billRepository = _billRepository;
        }
        public IList<Bill_DomainModel> GetAll()
        {
            return billRepository.GetAllBills()
                .Select(_ => _.BillFromInfraToDomain())
                .ToList();
        }

        public Bill_DomainModel Get(int id)
        {
            var temp = billRepository.GetBill(id).BillFromInfraToDomain();
            return temp;
        }

        public void Create(Bill_DomainModel inst)
        {
            billRepository.CreateBill(inst.BillFromDomainToInfra());
        }

        public void Update(Bill_DomainModel inst)
        {
            billRepository.UpdateBill(inst.BillFromDomainToInfra());
        }
        public void Delete(int id)
        {
            billRepository.DeleteBill(id);
        }
    }
}