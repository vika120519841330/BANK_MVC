using Domain.Models;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Mappers
{
    public static class Bill_Infra_Domain
    {
        public static Bill_DomainModel BillFromInfraToDomain(this Bill_InfraModel @this)
        {
            if (@this != null)
            {
                return new Bill_DomainModel()
                {
                    Id = @this.Id,
                    BillNumber = @this.BillNumber,
                    BillBalance = @this.BillBalance,
                    Client_DomainModelId = @this.Client_InfraModelId,
                    //ClientOwnerOfBill = @this.ClientOwnerOfBill.ClientFromInfraToDomain()
                };
            }
            else
            {
                return null;
            }
        }
        public static Bill_InfraModel BillFromDomainToInfra(this Bill_DomainModel @this)
        {
            if (@this != null)
            {
                return new Bill_InfraModel()
                {
                    Id = @this.Id,
                    BillNumber = @this.BillNumber,
                    BillBalance = @this.BillBalance,
                    Client_InfraModelId = @this.Client_DomainModelId,
                    //ClientOwnerOfBill = @this.ClientOwnerOfBill.ClientFromDomainToInfra()
                };
            }
            else
            {
                return null;
            }
        }
    }
}

