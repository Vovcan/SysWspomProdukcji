using System.Windows;
using SWPProjekt.Model;
using SWPProjekt.ViewModel;

namespace SWPProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(User Loginuser)
        {
            InitializeComponent();
            DataContext = new MainViewModel(Loginuser);

        }
    }
}
