using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Client_InfraModel
    {
        public int Id { get; set; }
        public string ClientTitle { get; set; }
        public bool ClientMarkJuridical { get; set; }
        public string ClientTaxpayNum { get; set; }
        public string ClientPhone { get; set; }
        public string ClientEMail { get; set; }
    }
}
