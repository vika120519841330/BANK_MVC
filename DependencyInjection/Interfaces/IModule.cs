using Unity;

namespace DependencyInjection.Interfaces
{
    public interface IModule
    {
        void Register(IUnityContainer container);
    }
}
