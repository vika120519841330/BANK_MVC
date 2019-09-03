using BANK_MVC_ONION_DI.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BANK_MVC_ONION_DI.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
    }
}