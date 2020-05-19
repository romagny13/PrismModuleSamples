using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleB
{
    [Module(ModuleName = "ModuleB", OnDemand = true)]
    public class ModuleBModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewB>("ViewB");
        }
    }
}