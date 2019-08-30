using System.Linq;
using System.Web.Mvc;
using Unity.AspNet.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BANK_MVC_ONION_DI.UnityMvcActivator), nameof(BANK_MVC_ONION_DI.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(BANK_MVC_ONION_DI.UnityMvcActivator), nameof(BANK_MVC_ONION_DI.UnityMvcActivator.Shutdown))]

namespace BANK_MVC_ONION_DI
{
    public static class UnityMvcActivator
    {
        public static void Start() 
        {
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.Container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));
        }
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}