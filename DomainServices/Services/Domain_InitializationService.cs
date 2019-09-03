using Domain.Interfaces;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Services
{
    public class Domain_InitializationService : IDomain_InitializationService
    {
        private readonly IInitializationService _InitializationService;

        public Domain_InitializationService(IInitializationService InitializationService)
        {
            _InitializationService = InitializationService;
        }

        public void Initialize()
        {
            _InitializationService.Initialize();
        }
    }
}
