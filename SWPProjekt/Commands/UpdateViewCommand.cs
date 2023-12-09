using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using SWPProjekt.Model;
using SWPProjekt.ViewModel;

namespace SWPProjekt.Commands
{
    internal class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;
        User Login;

        public UpdateViewCommand(MainViewModel viewModel, User LoginUser)
        {
            this.viewModel = viewModel;
            Login = LoginUser;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter.ToString() == "WarehouseList")
            {
                viewModel.SelectedViewModel = new WarehouseListScreenViewModel(viewModel, Login);
            }else if(parameter.ToString() == "ProductionList")
            {
                viewModel.SelectedViewModel = new ProductionListScreenViewModel(viewModel, Login);
            }
            else if (parameter.ToString() == "ComplaintsListScreen")
            {
                viewModel.SelectedViewModel = new ComplaintsListScreenViewModel(viewModel, Login);
            }
            else if (parameter.ToString() == "EmployeeListScreen")
            {
                if(Login.JobTitleid == 5)
                {
                    MessageBox.Show("Nie masz dostępu do tego komponentu");
                }
                else
                {
                    viewModel.SelectedViewModel = new EmployeeListScreenViewModel(viewModel, Login);
                }
            }
            else if (parameter.ToString() == "HoursScreen")
            {
                if (Login.JobTitleid == 2)
                {
                    viewModel.SelectedViewModel = new HoursScreenViewModel(viewModel);
                    
                }
                else
                {
                    MessageBox.Show("Nie masz dostępu do tej strony!");
                }
                
            }
            else if (parameter.ToString() == "HistoryHoursScreen")
            {
                viewModel.SelectedViewModel = new HistoryHoursScreenViewModel(viewModel);
            }
            else if (parameter.ToString() == "ProjectsScreen")
            {
                viewModel.SelectedViewModel = new ProjectsScreenViewModel(viewModel, Login);
            }
            else if (parameter.ToString() == "TasksScreen")
            {
                if (Login.JobTitleid == 2 || Login.JobTitleid == 5)
                {
                    viewModel.SelectedViewModel = new TaskListScreenViewModel(viewModel, Login);
                }
                else
                {
                    MessageBox.Show("Nie masz dostępu do tego ekranu!");
                }
            }
            else if (parameter.ToString() == "SaleScreen")
            {
                viewModel.SelectedViewModel = new SaleScreenViewModel(viewModel);
            }
            else if (parameter.ToString() == "SettingsScreen")
            {
                viewModel.SelectedViewModel = new SettingsScreenViewModel(viewModel);
            }
            else if (parameter.ToString() == "OdzyskanieHasla")
            {
                viewModel.SelectedViewModel = new OdzyskanieHaslaViewModel();
            }
            else if (parameter is BaseViewModel)
            {
                viewModel.SelectedViewModel = (BaseViewModel)parameter;
            }
            else if (parameter.ToString() == "EmployeeScreen")
            {
                viewModel.SelectedViewModel = new EmployeeScreenViewModel(Login,viewModel, Login);
            }
            else if (parameter.ToString() == "ArchiveListScreen")
            {
                if (Login.JobTitleid == 2 || Login.JobTitleid == 3 || Login.JobTitleid == 4)
                {
                    viewModel.SelectedViewModel = new ArchiveListScreenViewModel(viewModel);
                }
                else
                {
                    MessageBox.Show("Nie masz dostępu do tego ekranu!");
                }
            }
            else if (parameter.ToString() == "LostProducts")
            {
                viewModel.SelectedViewModel = new LostProductsViewModel(viewModel);
            }
        }        
    }
}
