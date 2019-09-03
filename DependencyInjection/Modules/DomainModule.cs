using DependencyInjection.Interfaces;
using Domain.Interfaces;
using DomainServices.Services;
using Unity;
using Unity.Lifetime;

namespace DependencyInjection.Modules
{
    public class DomainModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IBill, Bill_Service>(
                //new HierarchicalLifetimeManager()
                );
            container.RegisterType<IClient, Client_Service>(
                //new HierarchicalLifetimeManager()
                );

            //для работы с фейк-репозиторием
            container.RegisterType<IDomain_InitializationService, Domain_InitializationService>(
                //new HierarchicalLifetimeManager()
                );
        }
    }
}
