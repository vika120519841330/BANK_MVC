using Domain.Models;
using Infrastructure.Models;

namespace DomainServices.Mappers
{
    public static class Client_Infra_Domain
    {
        public static Client_DomainModel ClientFromInfraToDomain(this Client_InfraModel @this)
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
        public static Client_InfraModel ClientFromDomainToInfra(this Client_DomainModel @this)
        {
            if (@this != null)
            {
                return new Client_InfraModel()
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

