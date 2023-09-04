using System.Windows;
using System.Windows.Controls;

namespace SWPProjekt.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)   //metoda wyświetlająca odpowieni ekran zależnie od wybranego przycisku
        {
            MenuItem item = (MenuItem)sender;
            UserControl? screen=null;
            ContentGrid.Children.Clear();

            switch (item.Name)
            {
                case "WarehouseListBtn":
                    screen = new WarehouseListScreen();
                    break;
                case "ProductionScreenBtn":
                    screen = new ProductionScreen();
                    break;
                case "TaskListBtn":
                    screen = new TaskListScreen();
                    break;
                case "TaskCreationBtn":
                    screen = new TaskCreationScreen();
                    break;
                case "ProjectsBtn":
                    screen = new ProjectsScreen();
                    break;
                case "EmployeeListBtn":
                    screen = new EmployeeListScreen();
                    break;
                case "SaleBtn":
                    screen = new SaleScreen();
                    break;
                case "ArchiveBtn":
                    screen = new ArchiveScreen();
                    break;
                case "ComplaintsBtn":
                    screen = new ComplaintsScreen();
                    break;
                case "HoursBtn":
                    screen = new HoursScreen();
                    break;
                case "SettingsBtn":
                    screen = new SettingsScreen();
                    break;
            }
            
            if(screen!=null)
            ContentGrid.Children.Add(screen);
        }
    }
}
