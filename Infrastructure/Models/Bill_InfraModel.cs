using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class Bill_InfraModel
    {
        public int Id { get; set; }
        public string BillNumber { get; set; }
        public double BillBalance { get; set; }
        [ForeignKey("Client_InfraModel")]
        public int Client_InfraModelId { get; set; }
        //public Client_InfraModel ClientOwnerOfBill { get; set; }
    }
}
