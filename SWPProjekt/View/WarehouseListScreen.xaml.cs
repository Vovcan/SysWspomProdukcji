using SWPProjekt.ViewModel;
using System.Windows.Controls;

namespace SWPProjekt.View
{
    /// <summary>
    /// Interaction logic for WarehouseList.xaml
    /// </summary>
    public partial class WarehouseListScreen : UserControl
    {
        public WarehouseListScreen()
        {
            InitializeComponent();
            WarehouseListScreenViewModel viewModel = new WarehouseListScreenViewModel();
            DataContext = viewModel;
        }
    }
}
