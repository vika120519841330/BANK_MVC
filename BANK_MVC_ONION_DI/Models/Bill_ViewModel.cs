using BANK_MVC_ONION_DI.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BANK_MVC_ONION_DI.Models
{
    [BillModelAttribute]
    public class Bill_ViewModel
    {
        [Key]
        [Display(Name = "ID р/с:")]
        public int Id { get; set; }
        [Display(Name = "Номер р/с:")]
        public string BillNumber { get; set; }
        [Display(Name = "Баланс р/с:")]
        public double BillBalance { get; set; }
        [Display(Name = "Владелец р/с:")]
        //[ForeignKey]
        public int Client_ViewModelId { get; set; }
        //public Client_ViewModel ClientOwnerOfBill { get; set; }
        //можно добавить валюту р/с
    }
}