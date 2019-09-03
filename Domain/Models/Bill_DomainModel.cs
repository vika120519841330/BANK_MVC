using System;
namespace Domain.Models
{
    public class Bill_DomainModel
    {
        public int Id { get; set; }
        public string BillNumber { get; set; }
        public double BillBalance { get; set; }
        public int Client_DomainModelId { get; set; }
        //public Client_DomainModel ClientOwnerOfBill { get; set; }
    }
}
