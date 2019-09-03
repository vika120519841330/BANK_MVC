using BANK_MVC_ONION_DI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace BANK_MVC_ONION_DI.Mappers
{
    public static class Bill_Domain_View
    {
        public static Bill_ViewModel BillFromDomainToView(this Bill_DomainModel @this)
        {
            if (@this != null)
            {
                return new Bill_ViewModel()
                {
                    Id = @this.Id,
                    BillNumber = @this.BillNumber,
                    BillBalance = @this.BillBalance,
                    Client_ViewModelId = @this.Client_DomainModelId,
                    //ClientOwnerOfBill = @this.ClientOwnerOfBill.ClientFromDomainToView()
                };
            }
            else
            {
                return null;
            }
        }
        public static Bill_DomainModel BillFromViewToDomain(this Bill_ViewModel @this)
        {
            if (@this != null)
            {
                return new Bill_DomainModel()
                {
                    Id = @this.Id,
                    BillNumber = @this.BillNumber,
                    BillBalance = @this.BillBalance,
                    Client_DomainModelId = @this.Client_ViewModelId,
                    //ClientOwnerOfBill = @this.ClientOwnerOfBill.ClientFromViewToDomain()
                };
            }
            else
            {
                return null;
            }
        }
    }
}
