using ModuleA.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ModuleA.Views
{
    public partial class ViewA : UserControl
    {
        public ViewA()
        {
            InitializeComponent();

            this.Loaded += ViewA_Loaded;
        }

        private void ViewA_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as ViewAViewModel).OnLoaded();
        }
    }
}
