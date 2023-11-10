using System.Windows;
using NPOI.HSSF.Record;
using SWPProjekt.Model;
using SWPProjekt.ViewModel;

namespace SWPProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(User Loginuser, bool interfaceChecked)
        {
            InitializeComponent();
            DataContext = new MainViewModel(Loginuser, interfaceChecked);

        }
    }
}
