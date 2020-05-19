using Prism.Ioc;
using DependsOnSample.Views;
using System.Windows;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Diagnostics;

namespace DependsOnSample
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            // With App.Config
            return new ConfigurationModuleCatalog();
            // Or 
            // With DirectoryCatalog
            // return new DirectoryModuleCatalog { ModulePath = "Modules" };
        }

        protected override void InitializeModules()
        {
            IModuleManager moduleManager = Container.Resolve<IModuleManager>();
            moduleManager.LoadModuleCompleted += (s, e) =>
            {
                // ModuleB ... ModuleA (ModuleB is loaded first)
                Debug.WriteLine($"Module loaded:'{e.ModuleInfo.ModuleName}'");
            };

            moduleManager.Run();

            // load ModuleA (OnDemand), DependsOn ModuleB
            moduleManager.LoadModule("ModuleA");
        }

        protected override void OnInitialized()
        {
            IRegionManager regionManager = Container.Resolve<IRegionManager>();
            regionManager.RequestNavigate("ContentRegion", "ViewA");

            base.OnInitialized();
        }
    }
}
