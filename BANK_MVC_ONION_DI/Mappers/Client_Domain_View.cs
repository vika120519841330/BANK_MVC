using BANK_MVC_ONION_DI.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BANK_MVC_ONION_DI.Mappers
{
    public static class Client_Domain_View
    {
        public static Client_ViewModel ClientFromDomainToView(this Client_DomainModel @this)
        {
            if (@this != null)
            {
                return new Client_ViewModel()
                {
                    Id = @this.Id,
                    ClientTitle = @this.ClientTitle,
                    ClientMarkJuridical = @this.ClientMarkJuridical,
                    ClientTaxpayNum = @this.ClientTaxpayNum,
                    ClientPhone = @this.ClientPhone,
                    ClientEMail = @this.ClientEMail
                };
            }
            else
            {
                return null;
            }
        }
        public static Client_DomainModel ClientFromViewToDomain(this Client_ViewModel @this)
        {
            if (@this != null)
            {
                return new Client_DomainModel()
                {
                    Id = @this.Id,
                    ClientTitle = @this.ClientTitle,
                    ClientMarkJuridical = @this.ClientMarkJuridical,
                    ClientTaxpayNum = @this.ClientTaxpayNum,
                    ClientPhone = @this.ClientPhone,
                    ClientEMail = @this.ClientEMail
                };
            }
            else
            {
                return null;
            }
        }
    }
}

