using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _message;
        private readonly IRegionManager regionManager;
        private readonly IModuleManager moduleManager;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel(IRegionManager regionManager, IModuleManager moduleManager)
        {
            if (regionManager is null)
                throw new ArgumentNullException(nameof(regionManager));
            if (moduleManager is null)
                throw new ArgumentNullException(nameof(moduleManager));

            Message = "View A from your Prism Module";
            this.regionManager = regionManager;
            this.moduleManager = moduleManager;
        }

        public void OnLoaded()
        {
           // moduleManager.LoadModule("ModuleB");

            regionManager.RequestNavigate("ChildRegion", "ViewB");
        }
    }
}
